using Flipers.Data.ProClientHub.Data;
using Flipers.Models;
using Flipers.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Flipers.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public AdminController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Dashboard()
        {
            ViewBag.Projects = _context.Projects.ToList();
            ViewBag.Clients = _context.Clients.ToList();
            ViewBag.Contacts = _context.ContactForms.ToList();
            ViewBag.Subscriptions = _context.Subscriptions.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddProject(Project project, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                string uploads = Path.Combine(_environment.WebRootPath, "uploads");
                string filePath = Path.Combine(uploads, imageFile.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }
                project.ImagePath = "/uploads/" + imageFile.FileName;
            }

            _context.Projects.Add(project);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public IActionResult AddClient(Client client, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                string uploads = Path.Combine(_environment.WebRootPath, "uploads");
                string filePath = Path.Combine(uploads, imageFile.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }
                client.ImagePath = "/uploads/" + imageFile.FileName;
            }

            _context.Clients.Add(client);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
    }
}

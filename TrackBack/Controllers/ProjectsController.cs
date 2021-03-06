﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TrackBack.Data;
using TrackBack.Models;

namespace TrackBack.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly DataContext _context;

        public ProjectsController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard(int id)
        {
            var project = _context.Projects
                .Include(project => project.Bookmarks)
                .Include(project => project.Todos)
                .Where(project => project.Id == id)
                .FirstOrDefault();

            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        public IActionResult Index()
        {
            var projectItems = _context.Projects;
            return View(projectItems);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var projectToEdit = _context.Projects.Find(id);
            if (projectToEdit == null)
            {
                return NotFound();
            }

            return View(projectToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Project project)
        {
            _context.Projects.Update(project);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var projectToDelete = _context.Projects.Find(id);
            if (projectToDelete == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(projectToDelete);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

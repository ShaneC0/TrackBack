using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackBack.Data;
using TrackBack.Models;

namespace TrackBack.Controllers
{
    public class TodosController : Controller
    {
        private readonly DataContext _context;

        public TodosController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(int projectId)
        {
            ViewBag.projectId = projectId;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Todo todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();

            return RedirectToAction("Dashboard", "Projects", new { id = todo.ProjectId });
        }

        public IActionResult Edit(int id)
        {
            var todoToEdit = _context.Todos.Find(id);
            if(todoToEdit == null)
            {
                return NotFound();
            }

            return View(todoToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Todo todo)
        {
            _context.Todos.Update(todo);
            _context.SaveChanges();

            return RedirectToAction("Dashboard", "Projects", new { id = todo.ProjectId });
        }

        public IActionResult Delete(int id)
        {
            var todoToDelete = _context.Todos.Find(id);
            if(todoToDelete == null)
            {
                return NotFound();
            }

            _context.Todos.Remove(todoToDelete);
            _context.SaveChanges();

            return RedirectToAction("Dashboard", "Projects", new { id = todoToDelete.ProjectId });
        }
    }
}

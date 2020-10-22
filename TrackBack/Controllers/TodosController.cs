using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var todoItems = _context.Todos.Include(todo => todo.Project);
            return View(todoItems);
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
            if (todoToEdit == null)
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

        public IActionResult SoftDelete(int id)
        {
            var todoToDelete = _context.Todos.Find(id);
            if (todoToDelete == null)
            {
                return NotFound();
            }

            todoToDelete.Completed = true;

            _context.Todos.Update(todoToDelete);
            _context.SaveChanges();

            return RedirectToAction("Dashboard", "Projects", new { id = todoToDelete.ProjectId });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TrackBack.Data;
using TrackBack.Models;

namespace TrackBack.Controllers
{
    public class BookmarksController : Controller
    {
        private readonly DataContext _context;

        public BookmarksController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Create(int projectId)
        {
            ViewBag.ProjectId = projectId;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Bookmark bookmark)
        {
            _context.Bookmarks.Add(bookmark);
            _context.SaveChanges();

            return RedirectToAction("Dashboard", "Projects", new { id = bookmark.ProjectId });
        }

        public IActionResult Edit(int id)
        {
            var bookmarkToEdit = _context.Bookmarks.Find(id);
            if(bookmarkToEdit == null)
            {
                return NotFound();
            }

            return View(bookmarkToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Bookmark bookmark)
        {
            _context.Bookmarks.Update(bookmark);
            _context.SaveChanges();

            return RedirectToAction("Dashboard", "Projects", new { id = bookmark.ProjectId });
        }

        public IActionResult Delete(int id)
        {
            var bookmarkToDelete = _context.Bookmarks.Find(id);
            if(bookmarkToDelete == null)
            {
                return NotFound();
            }

            _context.Bookmarks.Remove(bookmarkToDelete);
            _context.SaveChanges();

            return RedirectToAction("Dashboard", "Projects", new { id = bookmarkToDelete.ProjectId});
        }
    }
}

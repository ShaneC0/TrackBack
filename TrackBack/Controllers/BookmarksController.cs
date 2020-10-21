using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TrackBack.Data;

namespace TrackBack.Controllers
{
    public class BookmarksController : Controller
    {
        private readonly DataContext _context;

        public BookmarksController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
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

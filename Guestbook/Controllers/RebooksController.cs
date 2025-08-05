using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Guestbook.Models;

namespace Guestbook.Controllers
{
    public class RebooksController : Controller
    {
        private readonly GuestBookContext _context;

        public RebooksController(GuestBookContext context)
        {
            _context = context;
        }

        

        // GET: Rebooks/Create
        public IActionResult Create(string BookID)
        {
            ViewData["BookID"] = BookID;
            return View();

        }

        // POST: Rebooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RebookID,Description,Author,CreateDate,BookID")] Rebook rebook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rebook);
                await _context.SaveChangesAsync();
                return Json(rebook);
                //return RedirectToAction("Display", "PostBooks" , new { id = rebook.BookID });
            }
            //ViewData["BookID"] = new SelectList(_context.Book, "BookID", "BookID", rebook.BookID);
            return Json(rebook);
        }

        public IActionResult GetRebookByViewComponent(string BookID)
        {
            return ViewComponent("VCRebooks", new {bookID= BookID });
        }

      
    }
}

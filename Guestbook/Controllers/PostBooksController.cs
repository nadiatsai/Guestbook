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
    public class PostBooksController : Controller
    {
        private readonly GuestBookContext _context;

        public PostBooksController(GuestBookContext context)
        {
            _context = context;
        }

        // GET: PostBooks
        public async Task<IActionResult> Index()
        {
            var result = await _context.Book.OrderByDescending(s => s.CreateDate).ToListAsync();
            return View(result);
        }

        // GET: PostBooks/Details/5
        public async Task<IActionResult> Display(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.BookID == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: PostBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookID,Title,Description,Author,Photo,CreateDate")] Book book, IFormFile? newPhoto)
        {
            book.CreateDate = DateTime.Now;


            if (newPhoto != null && newPhoto.Length != 0)
            {


                if (newPhoto.ContentType != "image/jpeg" && newPhoto.ContentType != "image/png")
                {
                    ViewData["Error"] = "只允許上傳.jpg 或.png的圖片檔案";
                    return View();
                }


                string fileName = book.BookID + Path.GetExtension(newPhoto.FileName); 

                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Photos", fileName);
               
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    newPhoto.CopyTo(fs);
                }

                book.Photo = fileName;

            }



            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        
     
    }
}

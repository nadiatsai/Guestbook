using Guestbook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Guestbook.Models;

namespace Guestbook.ViewComponents
{
    public class VCRebooks:ViewComponent
    {
        private readonly GuestBookContext _context;
        public VCRebooks(GuestBookContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string bookID)
        {
           var rebook = await _context.Rebook.Where(r => r.BookID==bookID).OrderByDescending(r => r.CreateDate).ToListAsync();


            return View(rebook);
        }

    }
}

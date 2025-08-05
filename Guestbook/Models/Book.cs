using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Guestbook.Models
{
    public partial class Book
    {
      
        public string BookID { get; set; } = null;

       
        public string Title { get; set; } = null;

        
        public string Description { get; set; } = null;

        
        public string Author { get; set; } = null;

        
        public string? Photo { get; set; } = null;

        
        public string? PhotoType { get; set; } = null;

       
        public DateTime CreateDate { get; set; } = DateTime.Now;


        public virtual LinkedList<Rebook>? Rebooks { get; set; }

    }
}

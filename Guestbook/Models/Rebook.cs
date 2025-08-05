using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Guestbook.Models
{
    public partial class Rebook
    {

       
        public string RebookID { get; set; } = null;


        public string Description { get; set; } = null;


        public string Author { get; set; } = null;

        public DateTime CreateDate { get; set; } = DateTime.Now;


        [ForeignKey("Book")]
        public string BookID { get; set; } = null;
        public virtual Book? Book { get; set; } 
    }
}

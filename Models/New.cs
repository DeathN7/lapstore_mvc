using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace testmvc.Models
{
    public class New
    {
        [Key]
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Scontents { get; set; }
        public string Contents { get; set; }
        public string Thump { get; set; }
        public bool Published { get; set; }
        public string Alias { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Author { get; set; }
        public string Tags { get; set; }
        public int? Views { get; set; }
        public New()
        {
        }
    }
}


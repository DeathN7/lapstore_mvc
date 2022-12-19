using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace testmvc.Models
{
	public class Category
	{
        [Key]
        public int CatID { get; set; }
		public string? CatName { get; set; }
		public string? Description { get; set; }
		public int? ParentID { get; set; }
		public int? Levels { get; set; }
		public int? Ordering { get; set; }
		public bool Published { get; set; }
		public string? Thump { get; set; }
		public string? Title { get; set; }
		public string? Alias { get; set; }
		public string? Cover { get; set; }
		public IEnumerable<Product>? Products { get; set; }
        public Category()
		{
		}
	}
}


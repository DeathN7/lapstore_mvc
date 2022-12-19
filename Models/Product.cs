using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace testmvc.Models
{
	public class Product
	{
		[Key]
        public int ProductID { get; set; }
		public string? ProductName { get; set; }
		public string? Description { get; set; }
		public int? CatID { get; set; }
		public double? Price { get; set; } = 0;
		public string? Thump { get; set; }
		public DateTime? CreatedDate { get; set; }
        public bool Active { get; set; }
        public bool HomeFlag { get; set; }
        public string? Tags { get; set; }
        public string? Title { get; set; }
        public string? Alias { get; set; }
		public int? UnitsInStock { get; set; } = 0;
		public Category? Category { get; set; }
		public List<OrderDetail>? OrderDetails { get; set; }
        public Product()
		{
		}
	}
}


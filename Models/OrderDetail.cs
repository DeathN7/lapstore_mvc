using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace testmvc.Models
{
	public class OrderDetail
	{
		[Key]
		public int OrderDetailID { get; set; }
		public int? OrderID { get; set; }
        public int? ProductID { get; set; }
        public int? OrderNumber { get; set; }
        public int? Amount { get; set; }
        public int? Discount { get; set; }
        public int? TotalMoney { get; set; }
        public int? Total { get; set; }
        public int? Price { get; set; }
        public DateTime? CreateDate { get; set; }
        public Order? Order { get; set; }
        public Product? Product { get; set; }
        public OrderDetail()
		{
		}
	}
}


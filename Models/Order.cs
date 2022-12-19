using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace testmvc.Models
{
	public class Order
	{
		[Key]
		public int OrderID { get; set; }
        public int? CustomerID { get; set; }
		public DateTime? OrderDate { get; set; }
		public bool? Deleted { get; set; }
        public bool? Paid { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? PaymentID { get; set; }
        public int? TotalMoney { get; set; }
        public string? Note { get; set; }
		public Customer? Customer { get; set; }
		public List<OrderDetail> OrderDetails { get; set; }
        public Order()
		{
		}
	}
}


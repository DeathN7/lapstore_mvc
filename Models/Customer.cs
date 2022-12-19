using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace testmvc.Models
{
	public class Customer
	{
		[Key]
		public int CustomerID { get; set; }
		public string? FullName { get; set; }
		public DateTime? BirthDay { get; set; }
		public string? Avatar { get; set; }
		public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? LastLogin { get; set; }
		public DateTime? CreateDate { get; set; }
        public string? Password { get; set; }
        public string? Salt { get; set; }
        public bool Active { get; set; }
		public List<Order> Orders { get; set; }
        public Customer()
		{
		}
	}
}


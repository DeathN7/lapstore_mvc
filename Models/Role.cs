using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace testmvc.Models
{
	public class Role
	{
		[Key]
		public int RoleID { get; set; }
		public string? RoleName { get; set; }
        public string? Description { get; set; }
		public List<Account> Accounts { get; set; } = new List<Account>();
		public Role()
		{
		}
	}
}


using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace testmvc.Models
{
	public class Page
	{
		[Key]
		public int PageID { get; set; }
		public string? PageName { get; set; }
		public string? Contents { get; set; }
		public string? Thump { get; set; }
		public bool Published { get; set; }
		public string? Title { get; set; }
        public string? Alias { get; set; }
		public DateTime? CreatedDate { get; set; }
		public int? Ordering { get; set; }

        public Page()
		{
		}
	}
}


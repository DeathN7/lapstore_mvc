using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace testmvc.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountID { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; } 
        public string? Password { get; set; }
        public string? Salt { get; set; }
        public bool Status { get; set; }
        public string? FullName { get; set; }
        public int? RoleID { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? CreateDate { get; set; }
        public  Role? Role { get; set; }
        public Account()
        {
        }
    }
}
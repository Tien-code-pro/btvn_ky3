using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ContactsWeb.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ContactName { get; set; }
        public int ContactNumber { get; set; }
        public string GroupName { get; set; }
        public DateTime Hiredate { get; set; }
        public DateTime Birthday { get; set; }
    }
}
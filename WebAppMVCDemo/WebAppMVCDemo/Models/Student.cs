using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebAppMVCDemo.Models
{
    public class Student
    {
        
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int Gender { get; set; }
        [Required]
        [StringLength(300)]
        public string Major { get; set; }
        [Required]
        public DateTime EntranceDate { get; set; }

    }
}
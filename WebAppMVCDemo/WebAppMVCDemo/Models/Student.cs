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
        public string Name { get; set; }
        public int Gender { get; set; }
        public string Major { get; set; }
        public DateTime EntranceDate { get; set; }

    }
}
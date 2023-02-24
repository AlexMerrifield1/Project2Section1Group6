using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project2Section1Group6.Models
{
    public class Task
    {
        [Key]
        [Required]
        public int TaskID { get; set; }

        [Required]
        //Builds Foreign Key Relationship for Categories
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        [Required]
        public string TaskTitle { get; set; }
        [Required]
        [Range(1,4)]
        public int QuadrantNumber { get; set; }
        //Datetime problem
        public string DueDate { get; set; }

        [MaxLength(200)]
        public string TaskNotes { get; set; }
        public bool Completed { get; set; }

    }
}


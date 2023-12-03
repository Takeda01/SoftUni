using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Models
{
    public class Course
    {
        [Key]
        [Required]
        public int CourseId { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; } = null!;

        public string Description { get; set; } 

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();

        public ICollection<Resource> Resources { get; set; } = new List<Resource>();

        public ICollection<Homework> Homeworks { get; set; } = new List<Homework>();
    }
}

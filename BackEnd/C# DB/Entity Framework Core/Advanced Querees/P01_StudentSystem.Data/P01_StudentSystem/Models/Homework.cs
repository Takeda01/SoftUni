using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Models
{
    public class Homework
    {
        [Key]
        
        public int HomeworkId { get; set; }

        public string Content { get; set; }

        public DateTime SubmitionTime { get; set; }
        public int StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        [Required]
        public Student Student { get; set; } = null!;

        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        [Required]
        public Course Course { get; set; } = null!;
    }
}

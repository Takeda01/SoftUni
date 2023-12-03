

using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Models
{
    public class Student
    {
        [Key]
        [Required]
        public int StudentId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [StringLength(10)]
        public string PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime BirthDate { get; set; }


        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<Homework> Homeworks { get; set; } = new List<Homework>();

    }
}

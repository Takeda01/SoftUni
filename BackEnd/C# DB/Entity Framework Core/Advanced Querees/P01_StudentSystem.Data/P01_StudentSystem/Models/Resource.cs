using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Models
{
    public class Resource
    {
        [Key]
        [Required]
        public int ResourceId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        public string Url { get; set; }

        public ResourceType  ResourceType { get; set; }
        public int CourceId { get; set; }
        [Required]
        [ForeignKey(nameof(CourceId))]
        public Course Cource { get; set; } = null!;
    }
}

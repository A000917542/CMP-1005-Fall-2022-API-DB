using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Models
{
    public class BlogPost
    {
        [Key]
        public Uri? PostUrl { get; set; }

        [Required]
        public string? Title { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        [EmailAddress]
        [Required]
        public string? Author { get; set; }

        [Required]
        public Blog? Blog { get; set; }
    }
}

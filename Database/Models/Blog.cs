using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Models
{
    public class Blog
    {
        [Key]
        public Uri? Url { get; set; }

        [Required]
        public string? Title { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        public ICollection<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();
    }
}

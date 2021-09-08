using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Models
{
    public class PostCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least one character for the Title.")]
        [MaxLength(100, ErrorMessage = "Character limit exceeded.")]
        public string Title { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Post cannot be empty.")]
        [MaxLength(280, ErrorMessage = "Character limit exceeded.")]
        public string Text { get; set; }
    }
}

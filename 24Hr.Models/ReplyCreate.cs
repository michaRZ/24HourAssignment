using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Models
{
    public class ReplyCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Reply cannot be empty")]
        [MaxLength(300, ErrorMessage = "There are too many characters.")]
        public string Text { get; set; }
    }
}

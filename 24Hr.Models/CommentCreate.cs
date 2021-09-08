using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Data
{
    public class CommentCreate
    {
        public int PostId { get; set; }
        [Required]
        [MaxLength(5000, ErrorMessage ="Too many characters.")]
        public string Content { get; set; }
    }
}

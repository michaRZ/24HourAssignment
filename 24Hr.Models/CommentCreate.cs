using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Data
{
    public class CommentCreate
    {
        [Required]
        [MaxLength(5000, ErrorMessage ="Too many characters.")]
        public string Comment { get; set; }
    }
}

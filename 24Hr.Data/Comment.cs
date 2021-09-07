using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        /*[ForeignKey nameof(]*/
        public int PostId { get; set; }
        [Required]
        //display the author name using GUID ***UNIMPLEMENTED***
        //[Display(Name=???)]
        public Guid AuthorId { get; set; }
        [Required]
        [MaxLength(5000, ErrorMessage ="Too many characters.")]
        public string Contents { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}

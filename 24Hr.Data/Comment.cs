using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public string Author { get; set; }
        public string Contents { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }

    }
}

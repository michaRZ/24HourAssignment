using _24Hr.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Models
{
    public class PostListItem
    {
        public Guid AuthorId { get; set; }
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public int NumberOfComments { get; set; }
    }
}

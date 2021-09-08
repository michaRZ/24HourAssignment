﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Data
{
    public class CommentListItem
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public Guid AuthorId { get; set; }
        public string Contents { get; set; }
        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}

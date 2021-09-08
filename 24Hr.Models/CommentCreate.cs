﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Data
{
    //This comment is to be deleted
    public class CommentCreate
    {
        [Required]
        [MaxLength(5000, ErrorMessage ="Too many characters.")]
        public string Content { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.CommentModels
{
    public class CommentEdit
    {
        public string Content { get; set; }
        [Required]
        public int CommentId { get; set; }
        [Required]
        public int PostId { get; set; }
    }
}

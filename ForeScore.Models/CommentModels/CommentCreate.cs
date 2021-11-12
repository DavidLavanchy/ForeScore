using ForeScore.Models.PostModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.CommentModels
{
    public class CommentCreate
    {
        [Required]
        public string Content{ get; set; }
        [Required]
        public int PostId { get; set; }
        public PostDetail PostDetail { get; set; }
    }
}

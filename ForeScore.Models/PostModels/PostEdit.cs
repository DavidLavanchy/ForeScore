using ForeScore.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.PostModels
{
    public class PostEdit
    {
        [Required]
        public int PostId { get; set; }
        public string Title { get; set; }
        public int RoundId { get; set; }
        public string Content { get; set; }
    }
}

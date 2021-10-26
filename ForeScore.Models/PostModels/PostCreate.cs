using ForeScore.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.PostModels
{
    public class PostCreate
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public int RoundId { get; set; }
    }
}

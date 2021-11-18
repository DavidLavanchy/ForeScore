using ForeScore.Data;
using ForeScore.Models.CommentModels;
using ForeScore.Models.RoundModels;
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
        public DateTimeOffset? Modified { get; set; }
        public ICollection<CommentListItem> Comments { get; set; }
        public RoundDetail RoundDetail { get; set; }
        public string OwnerId { get; set; }
    }
}

using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Data
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        [ForeignKey(nameof(Round))]
        public int RoundId { get; set; }
        public virtual Round Round { get; set; }
        public string Content { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Modified { get; set; }
        public string OwnerId { get; set; }
    }
}

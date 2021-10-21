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
        public Guid OwnerId { get; set; }
        public string Title { get; set; }
        public Round Round { get; set; }
        public string Content { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Modified { get; set; }
        [Required]
        [ForeignKey(nameof(UserCareer))]
        public int CareerUserId { get; set; }
        public virtual UserCareer UserCareer { get; set; }
    }
}

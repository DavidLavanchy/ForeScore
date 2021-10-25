using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public Guid OwnerId { get; set; }
        public string Content { get; set; }
        [Required]
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

    }
}

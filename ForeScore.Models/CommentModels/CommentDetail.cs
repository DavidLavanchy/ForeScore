using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.CommentModels
{
    public class CommentDetail
    {
        public string Content { get; set; }
        public int PostId { get; set; }
        public string Name { get; set; }
        public string OwnerId { get; set; }
    }
}

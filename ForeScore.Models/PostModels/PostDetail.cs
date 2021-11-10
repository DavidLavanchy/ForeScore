using ForeScore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.PostModels
{
    public class PostDetail
    {
        public string Title { get; set; }
        public string Username { get; set; }
        public int? RoundId { get; set; }
        public string Content { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}

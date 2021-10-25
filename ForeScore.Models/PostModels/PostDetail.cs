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
        public Round Round { get; set; }
        public string Content { get; set; }
        public List<Comment> Comments { get; set; }
        //public List<Like> Likes { get; set; }
    }
}

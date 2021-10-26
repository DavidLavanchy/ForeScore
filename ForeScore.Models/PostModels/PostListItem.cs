using ForeScore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.PostModels
{
    public class PostListItem
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<Like> Likes { get; set; }
    }
}

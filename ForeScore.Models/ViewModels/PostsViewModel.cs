using ForeScore.Models.PostModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.ViewModels
{
    public class PostsViewModel
    {
         public List<PostListItem> MyPosts { get; set; }

         public List<PostListItem> UsersFollowingPosts { get; set; }

    }
}

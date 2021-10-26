using ForeScore.Data;
using ForeScore.Models.PostModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Services
{
    public class PostServices
    {
        private readonly string _userId;

        public PostServices(string userId)
        {
            _userId = userId;
        }

        public bool CreatePost(PostCreate model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = new Post
                {
                    Title = model.Title,
                    Content = model.Content,
                    Created = DateTimeOffset.UtcNow,
                    OwnerId = _userId,
                    RoundId = model.RoundId,

                };

                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public PostDetail GetPost(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .Single(e => e.PostId == id);
                    
                    var post = new PostDetail
                    {
                        Comments = entity.Comments,
                        Content = entity.Content,
                        Likes = entity.Likes,
                        RoundId = entity.RoundId,
                        Title = entity.Title
                    };

                return post;
            }
        }

        public IEnumerable<PostListItem> GetAllUsersPosts()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Posts
                    .Where(e => _userId == e.OwnerId)
                    .Select(e =>
                    new PostListItem
                    {
                        Content = e.Content,
                        Likes = e.Likes,
                        Title = e.Title
                    });

                return query.ToArray();
            }
        }

        public IEnumerable<PostListItem> GetFollowingsPosts(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Posts
                    .Where(e => id == e.OwnerId)
                    .Select(e =>
                    new PostListItem
                    {
                        Content = e.Content,
                        Likes = e.Likes,
                        Title = e.Title
                    });

                return query.ToArray();
            }
        }

        public IEnumerable<PostListItem> GetFeed()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Following
                    .Where(e => _userId == e.Id)
                    .Select(e => e.Email);

                List<ApplicationUser> _users = new List<ApplicationUser>();

                foreach(var item in query)
                {
                    var user = ctx.Users.Find(item);
                    _users.Add(user);
                }

                var ids =
                    _users
                    .Select(e => e.Id);

                List<Post> _posts = new List<Post>();

                foreach(var item2 in ids)
                {
                    var post = ctx.Posts.Find(item2);
                    _posts.Add(post);
                }

                var feed =
                    _posts
                    .Select(e =>
                    new PostListItem
                    {
                        Content = e.Content,
                        Likes = e.Likes,
                        Title = e.Title,
                    });

                return feed.ToArray();
                    
            }
        }

        public bool EditPost(PostEdit model)
        {
            using(var ctx =  new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .Single(e => e.PostId == model.PostId);

                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.RoundId = model.RoundId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePost(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .Single(e => e.PostId == id && _userId == e.OwnerId);

                ctx.Posts.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}

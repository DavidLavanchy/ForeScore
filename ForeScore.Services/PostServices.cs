using ForeScore.Data;
using ForeScore.Models.CommentModels;
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

                var name =
                    ctx
                    .Users
                    .Single(e => e.Id == _userId);


                entity.Name = name.FullName;

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
                        
                        Content = entity.Content,
                        RoundId = entity.RoundId,
                        Title = entity.Title,
                        PostId = entity.PostId,
                        Name = entity.Name,
                        OwnerId = _userId,
                    };

                var service = new CommentServices(_userId);
                var comments = service.GetCommentsForPost(id);

                var roundService = new RoundServices(_userId);

                var roundDetail = roundService.GetRoundById(post.RoundId);


                post.Comments = comments.ToArray();
                post.RoundDetail = roundDetail;

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
                        Title = e.Title,
                        Name = e.Name,
                        PostId = e.PostId,
                    });

                return query.ToArray();
            }
        }

        public IEnumerable<PostListItem> GetFollowingsPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Following
                    .Where(e => _userId == e.Id)
                    .Select(e => e.UserId);

                List<PostListItem> _posts = new List<PostListItem>(); 

                foreach (var user in query)
                {
                    var followingsPosts = GetAllFollowingsPosts(user);

                    foreach(var post in followingsPosts)
                    {
                        _posts.Add(post);
                    }
                }


                return _posts.ToArray();
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

                if(entity == null)
                {
                    return false;
                }

                ctx.Posts.Remove(entity);
                ctx.SaveChanges();

                var query =
                    ctx
                    .Comments
                    .Where(e => e.PostId == id)
                    .Select(e => e.CommentId);

                foreach(var commentId in query)
                {
                    var service = new CommentServices(_userId);
                    service.DeleteComment(commentId);
                }

                return true;
            }
        }
        public IEnumerable<PostListItem> GetAllFollowingsPosts(string id)
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
                        Title = e.Title,
                        Name = e.Name,
                        PostId = e.PostId,
                    });

                return query.ToArray();
            }
        }
    }
}

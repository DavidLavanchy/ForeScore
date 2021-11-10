using ForeScore.Data;
using ForeScore.Models.CommentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Services
{
    public class CommentServices
    {
        private readonly string _userId;

        public CommentServices(string userId)
        {
            _userId = userId;
        }

        public bool CreateComment(CommentCreate model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = new Comment();

                entity.Content = model.Content;
                entity.PostId = model.PostId;
                entity.OwnerId = _userId;

                var name =
                    ctx
                    .Users
                    .Single(e => e.Id == _userId);

                entity.Name = name.FullName;

                ctx.Comments.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListItem> GetCommentsForPost(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Comments
                    .Where(e => e.PostId == id)
                    .Select(e =>
                    new CommentListItem
                    {
                        Content = e.Content,
                        Name = e.Name,
                    });

                return query.ToArray();
            }
        }

        public bool DeleteComment(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Comments
                    .Single(e => e.CommentId == id);

                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

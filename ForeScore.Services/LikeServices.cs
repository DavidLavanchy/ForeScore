using ForeScore.Data;
using ForeScore.Models.LikeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Services
{
    public class LikeServices
    {
        private readonly string _userId;

        public LikeServices(string userId)
        {
            _userId = userId;
        }

        public bool CreateLike(LikeCreate model)
        {
            var entity =
                new Like()
                {
                    PostId = model.PostId
                };

            using (var ctx = new ApplicationDbContext())
            {

                ctx.Likes.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public int GetLikesByPostId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Likes
                    .Where(e => id == e.PostId)
                    .Select(e => e.Id);

                var likeCount = query.Count();

                return likeCount;
            }
        }

        public bool DeleteALike(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                 ctx
                 .Likes
                 .Single(e => id == e.Id);

                ctx.Likes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }

        }
    }
}

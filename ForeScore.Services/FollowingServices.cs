using ForeScore.Data;
using ForeScore.Models.FollowingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Services
{
    public class FollowingServices
    {
        private readonly string _userId;

        public FollowingServices(string userId)
        {
            _userId = userId;
        }

        public bool FollowCreate(FollowingAdd model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Users
                    .Single(e => e.Email == model.Email);

                if(entity == null)
                {
                    return false;
                }

                var following =
                new Following
                {
                    Email = entity.Email,
                    Id = model.Id,
                    FullName = entity.FullName
                };

                ctx.Following.Add(following);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool FollowDelete(FollowingRemove model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Following
                    .Single(e => e.Email == model.Email);


                ctx.Following.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FollowingListItem> GetAllFollowings(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Following
                    .Where(e => e.Id == id)
                    .Select(e =>
                    new FollowingListItem
                    {
                        Email = e.Email,
                        FullName = e.FullName,
                    });

                return query.ToArray();
            }
        }

    }
}

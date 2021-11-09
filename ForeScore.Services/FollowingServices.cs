using ForeScore.Data;
using ForeScore.Models.FollowerModels;
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

        //User inputs an email address for whom they want to follow. If the Follower's email is valid, a following entity will be added
        //which intakes the user's id and the user they are wanting to follow's email and name. The user's information will then be added as a follow eneity taking in
        //their email and name and the user they are following's Id
        public bool FollowCreate(FollowingAdd model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Users
                    .Single(e => e.Email == model.Email);

                if (entity == null)
                {
                    return false;
                }

                var following =
                new Following
                {
                    Email = entity.Email,
                    UserId = entity.Id,
                    FullName = entity.FullName,
                    Id = _userId
                };

                ctx.Following.Add(following);

                var follower =
                    ctx
                    .Users
                    .Single(e => e.Id == _userId);

                AddFollower(follower, entity.Id);

                return ctx.SaveChanges() == 2;
            }
        }

        public FollowingListItem GetFollowingById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Following
                    .Single(e => e.FollowingId == id);

                var following = new FollowingListItem
                {
                    Email = entity.Email,
                    FullName = entity.FullName,
                    UserId = entity.UserId,
                    FollowingId = entity.FollowingId,
                };

                return following;
                    
            }
        }

        public bool FollowDelete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Following
                    .Single(e => e.FollowingId == id && _userId == e.Id);

                if (entity == null)
                {
                    return false;
                }

                var followed =
                ctx
                .Users
                .Single(e => e.Id == _userId);

                RemoveFollower(followed, entity.Id);


                ctx.Following.Remove(entity);
                return ctx.SaveChanges() == 2;
            }
        }

        public IEnumerable<FollowingListItem> GetAllFollowings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Following
                    .Where(e => e.UserId == _userId)
                    .Select(e =>
                    new FollowingListItem
                    {
                        Email = e.Email,
                        FullName = e.FullName,
                        UserId = e.UserId
                        
                    });

                return query.ToArray();
            }
        }


        private bool AddFollower(ApplicationUser model, string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = new FollowedBy();

                entity.Email = model.Email;
                entity.FullName = model.FullName;
                entity.UserId = model.Id;

                entity.Id = id;

                ctx.FollowedBy.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public FollowingAdd CreateFollowingAddModel()
        {
            var model = new FollowingAdd
            {
                Email = null,
                Id = null,
                UserId = _userId,
            };

            return model;
        }

        private bool RemoveFollower(ApplicationUser model, string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                      ctx
                      .FollowedBy
                      .Single(e => id == e.Id && model.Email == e.Email);

                if (entity == null)
                {
                    return false;
                }

                ctx.FollowedBy.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

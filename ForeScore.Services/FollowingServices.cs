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

                ctx.SaveChanges();

                return true;
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
                    Id = entity.Id
                };

                return following;
                    
            }
        }

        public string GetUserId(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Following
                    .Single(e => e.FollowingId == id);

                var userId = entity.UserId;

                return userId;
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

                RemoveFollower(followed, entity.UserId);


                ctx.Following.Remove(entity);
                ctx.SaveChanges();

                return true;
            }
        }

        public IEnumerable<FollowingListItem> GetAllFollowings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Following
                    .Where(e => e.Id == _userId)
                    .Select(e =>
                    new FollowingListItem
                    {
                        Email = e.Email,
                        FullName = e.FullName,
                        UserId = e.UserId,
                        FollowingId = e.FollowingId,
                        Id = e.Id,
                        
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

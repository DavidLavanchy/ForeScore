using ForeScore.Data;
using ForeScore.Models.FollowerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Services
{
    public class FollowerServices
    {
        private readonly string _userId;

        public FollowerServices(string userId)
        {
            _userId = userId;
        }

        public IEnumerable<FollowerListItem> GetFollowers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Users
                    .Single(e => _userId == e.Id);


                var query =
                    ctx
                    .FollowedBy
                    .Where(e => e.Email == entity.Email)
                    .Select(e => e.Id.ToArray());

                List<ApplicationUser> _users = new List<ApplicationUser>();

                foreach (var item in query)
                {
                    var user = ctx.Users.Find(item);
                    _users.Add(user);
                }

               var followers =  _users.
                    Select(e =>
                    new FollowerListItem
                    {
                        Email = e.Email,
                        FullName = e.FullName
                    });

                return followers.ToArray();

            }
        }
    }
}

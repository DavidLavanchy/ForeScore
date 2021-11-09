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
                var query =
                    ctx
                    .FollowedBy
                    .Where(e => e.Id == _userId)
                    .Select(e => new FollowerListItem
                    {
                        Email = e.Email,
                        FullName = e.FullName,
                        UserId = e.UserId,
                        FollowerId = e.FollowedById,
                        Id = e.Id,
                    });

                return query.ToArray();

            }
        }
    }
}

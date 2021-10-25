using ForeScore.Data;
using ForeScore.Models.UserCareerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Services
{
    public class UserCareerServices
    {
        private readonly string _userId;

        public UserCareerServices(string userId)
        {
            _userId = userId;
        }

        public UserCareerViewModel ViewCareerStats(string _userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Users
                    .Single(e => e.Id == _userId);
                return
                new UserCareerViewModel
                {
                    FullName = entity.FullName,
                    Handicap = entity.Handicap,
                    Eagles = entity.Eagles,
                    Aces = entity.Aces,
                    AverageDrivingDistance = entity.AverageDrivingDistance,
                    AveragePutts = entity.AveragePutts,
                    AverageScoreToPar = entity.AverageScoreToPar,
                    Birdies = entity.Birdies,
                    Pars = entity.Pars,
                    RoundsPlayed = entity.RoundsPlayed
                };

            }
        }

        //public IEnumerable<UserCareersFollowingListItem> GetUsersFollowing(string _userId)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query =
        //            ctx
        //            .Users
        //            .Where(e => e.Id == _userId)
        //            .Select(e => e.UserCareersFollowing.ToList());

        //        var following = 
        //            query
        //            .Select(e=> 
        //            new UserCareersFollowingListItem
        //            {
        //                Email = e.
        //            })



        //        return query;
        //    }
        //}

    }
}

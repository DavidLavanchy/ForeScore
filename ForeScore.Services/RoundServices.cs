using ForeScore.Data;
using ForeScore.Models.RoundModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Services
{
    public class RoundServices
    {
        private readonly string _userId;

        public RoundServices(string userId)
        {
            _userId = userId;
        }

        public bool CreateRound(RoundCreateModel model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = new Round
                {
                    CourseId = model.CourseId,
                    DateOfRound = model.DateOfRound,
                    Description = model.Description,
                    HoleData = model.HoleData,
                    IsFeatured = model.IsFeatured,
                    IsPublic = model.IsPublic,
                    Id = _userId,
                    Score = model.Score,
                };

                ctx.Rounds.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public RoundDetail GetRoundById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Rounds
                    .Single(e => e.RoundId == id);

                var round = new RoundDetail
                {
                    CourseId = entity.CourseId,
                    DateOfRound = entity.DateOfRound,
                    Description = entity.Description,
                    HoleData = entity.HoleData,
                    IsFeatured = entity.IsFeatured,
                    IsPublic = entity.IsPublic,
                    Score = entity.Score,

                };

                return round;
            }
        }
    }
}

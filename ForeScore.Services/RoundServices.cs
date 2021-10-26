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
            using (var ctx = new ApplicationDbContext())
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
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Rounds
                    .Single(e => e.RoundId == id && e.Id == _userId);

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

        public ICollection<RoundListItem> GetAllRoundsByUserId()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Rounds
                    .Where(e => e.Id == _userId)
                    .Select(e=> 
                new RoundListItem
                {
                    CourseId = e.CourseId,
                    DateOfRound = e.DateOfRound,
                    Description = e.Description,
                    IsFeatured = e.IsFeatured,
                    IsPublic = e.IsPublic,
                    Score = e.Score,
                });

                return query.ToArray();
            }
        }

        public ICollection<RoundListItem> GetAllRoundsByUserIdAscending()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Rounds
                    .Where(e => e.Id == _userId)
                    .OrderBy(e=> e.Score)
                    .Select(e =>
                new RoundListItem
                {
                    CourseId = e.CourseId,
                    DateOfRound = e.DateOfRound,
                    Description = e.Description,
                    IsFeatured = e.IsFeatured,
                    IsPublic = e.IsPublic,
                    Score = e.Score,
                });

                return query.ToArray();
            }
        }

        public ICollection<RoundListItem> GetAllRoundsByUserIdAndDate()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Rounds
                    .Where(e => e.Id == _userId)
                    .OrderBy(e => e.DateOfRound)
                    .Select(e =>
                new RoundListItem
                {
                    CourseId = e.CourseId,
                    DateOfRound = e.DateOfRound,
                    Description = e.Description,
                    IsFeatured = e.IsFeatured,
                    IsPublic = e.IsPublic,
                    Score = e.Score,
                });

                return query.ToArray();
            }
        }

        public bool EditRound(RoundEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Rounds
                    .Single(e => model.RoundId == e.RoundId);

                    entity.DateOfRound = model.DateOfRound;
                    entity.Description = model.Description;
                    entity.IsFeatured = model.IsFeatured;
                    entity.IsPublic = model.IsPublic;
                    entity.Score = model.Score;
                    entity.HoleData = model.HoleData;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool RemoveRound(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Rounds
                    .Single(e => id == e.RoundId);


                ctx.Rounds.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

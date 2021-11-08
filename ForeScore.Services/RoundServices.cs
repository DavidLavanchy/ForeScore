using ForeScore.Data;
using ForeScore.Models.CourseModels;
using ForeScore.Models.HoleDataModels;
using ForeScore.Models.RoundModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

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
                var course = ctx.Courses.Find(model.CourseDetail.CourseId);

                var score = new List<int>();

                foreach(var hole in model.HoleData)
                {
                    var holeScore = hole.Score;
                    score.Add(holeScore);
                }

                var entity = new Round
                {
                    CourseName = course.Name,
                    CourseId = course.CourseId,
                    DateOfRound = model.DateOfRound,
                    Description = model.Description,
                    IsFeatured = model.IsFeatured,
                    IsPublic = model.IsPublic,
                    Id = _userId,
                    Score = score.Sum()
                };

                ctx.Rounds.Add(entity);
                ctx.SaveChanges();

                var round = ctx.Rounds.Find(entity.RoundId);

                var _holes = new List<HoleDataCreate>();

                foreach(var hole in model.HoleData)
                {
                    var newHole = new HoleDataCreate();

                    newHole.RoundId = round.RoundId;
                    newHole.Score = hole.Score;
                    newHole.Putts = hole.Putts;
                    newHole.Penalty = hole.Penalty;
                    newHole.FairwayHit = hole.FairwayHit;
                    newHole.DrivingDistance = hole.DrivingDistance;
                    newHole.HoleNumber = hole.HoleNumber;

                    _holes.Add(newHole);
                }

                foreach(var holeData in _holes)
                {
                    var service = new HoleDataServices();
                    service.CreateHoleData(holeData);
                }

                return true;

            }
        }

        public RoundCreateModel NullRound()
        {
            List<HoleDataCreate> _holes = new List<HoleDataCreate>();

            for (int i = 1; i < 19; i++)
            {
                HoleDataCreate nullHole = new HoleDataCreate();

                nullHole.HoleNumber = i;

                _holes.Add(nullHole);
            }

            RoundCreateModel round = new RoundCreateModel();

            round.HoleData = _holes;


            return round;
        }

        public RoundDetail GetRoundById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Rounds
                    .Single(e => e.RoundId == id && e.Id == _userId);

                var query =
                    ctx
                    .HoleData
                    .Where(e => e.RoundId == id)
                    .Select(e => new HoleDataDetail
                    {
                        DrivingDistance = e.DrivingDistance,
                        FairwayHit = e.FairwayHit,
                        HoleNumber = e.HoleNumber,
                        Penalty = e.Penalty,
                        Putts = e.Putts,
                        RoundId = e.RoundId,
                        Score = e.Score
                    });

                var course =
                    ctx
                    .Courses
                    .Single(e => e.CourseId == entity.CourseId);

                var service = new CourseServices(_userId);

                var courseDetail = service.GetCourseById(course.CourseId);

                var holes = query.ToList();

                var round = new RoundDetail
                {
                    CourseId = entity.CourseId,
                    CourseName = entity.CourseName,
                    DateOfRound = entity.DateOfRound,
                    Description = entity.Description,
                    HoleData = holes,
                    IsFeatured = entity.IsFeatured,
                    IsPublic = entity.IsPublic,
                    Score = entity.Score,
                    CourseDetail = courseDetail,
                    RoundId = entity.RoundId
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
                    .Select(e =>
                new RoundListItem
                {
                    RoundId = e.RoundId,
                    CourseName = e.CourseName,
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
                    .OrderBy(e => e.Score)
                    .Select(e =>
                new RoundListItem
                {
                    CourseId = e.CourseId,
                    CourseName = e.CourseName,
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
                    CourseName = e.CourseName,
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
            using (var ctx = new ApplicationDbContext())
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

                DeleteAllHoleDataWithinRound(entity.RoundId);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SelectListItem> Courses()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Courses
                    .Where(e => e.OwnerId == _userId)
                    .Select(e => new SelectListItem
                    {
                        Text = e.Name,
                        Value = e.CourseId.ToString(),
                    });

                return query.ToArray();
            }
        }

        private bool DeleteAllHoleDataWithinRound(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .HoleData
                    .Where(e => e.RoundId == id)
                    .Select(e => new HoleData
                    {
                        DrivingDistance = e.DrivingDistance,
                        FairwayHit = e.FairwayHit,
                        HoleDataId = e.HoleDataId,
                        HoleNumber = e.HoleNumber,
                        Penalty = e.Penalty,
                        Putts = e.Putts,
                        RoundId = e.RoundId,
                        Score = e.Score,
                    });

                foreach (var hole in query)
                {
                    ctx.HoleData.Remove(hole);
                }

                return ctx.SaveChanges() == 1;
            }
        }


    }
}

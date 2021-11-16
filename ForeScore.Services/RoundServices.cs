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

                foreach (var hole in model.FrontNine)
                {
                    var holeScore = hole.Score;
                    score.Add(holeScore);
                }

                foreach (var hole in model.BackNine)
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


                foreach (var hole in model.CourseDetail.FrontNine)
                {
                    foreach (var holeData in model.FrontNine)
                    {
                        if (hole.HoleNumber == holeData.HoleNumber)
                        {
                            holeData.HolePar = hole.Par;
                        }
                    }
                }

                foreach (var hole in model.CourseDetail.BackNine)
                {
                    foreach (var holeData in model.BackNine)
                    {
                        if (hole.HoleNumber == holeData.HoleNumber)
                        {
                            holeData.HolePar = hole.Par;
                        }
                    }
                }


                var _holes = new List<HoleDataCreate>();

                foreach (var hole in model.FrontNine)
                {
                    var newHole = new HoleDataCreate();

                    newHole.RoundId = round.RoundId;
                    newHole.Score = hole.Score;
                    newHole.Putts = hole.Putts;
                    newHole.Penalty = hole.Penalty;
                    newHole.FairwayHit = hole.FairwayHit;
                    newHole.DrivingDistance = hole.DrivingDistance;
                    newHole.HoleNumber = hole.HoleNumber;
                    newHole.HolePar = hole.HolePar;

                    _holes.Add(newHole);
                }

                foreach (var hole in model.BackNine)
                {
                    var newHole = new HoleDataCreate();

                    newHole.RoundId = round.RoundId;
                    newHole.Score = hole.Score;
                    newHole.Putts = hole.Putts;
                    newHole.Penalty = hole.Penalty;
                    newHole.FairwayHit = hole.FairwayHit;
                    newHole.DrivingDistance = hole.DrivingDistance;
                    newHole.HoleNumber = hole.HoleNumber;
                    newHole.HolePar = hole.HolePar;

                    _holes.Add(newHole);
                }

                foreach (var holeData in _holes)
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

            for (int i = 1; i < 10; i++)
            {
                HoleDataCreate nullHole = new HoleDataCreate();

                nullHole.HoleNumber = i;

                _holes.Add(nullHole);
            }

            List<HoleDataCreate> _holesBack = new List<HoleDataCreate>();

            for (int i = 10; i < 19; i++)
            {
                HoleDataCreate nullHole = new HoleDataCreate();

                nullHole.HoleNumber = i;

                _holesBack.Add(nullHole);
            }

            RoundCreateModel round = new RoundCreateModel();

            round.FrontNine = _holes;
            round.BackNine = _holesBack;


            return round;
        }

        public RoundDetail GetRoundById(int? id)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Rounds
                    .Single(e => e.RoundId == id);

                var course =
                    ctx
                    .Courses
                    .Single(e => e.CourseId == entity.CourseId);

                var service = new CourseServices(_userId);

                var courseDetail = service.GetCourseById(course.CourseId);

                HoleData[] frontNine = entity.HoleData.Take(9).ToArray();
                HoleData[] backNine = entity.HoleData.Skip(9).Take(18).ToArray();

                var round = new RoundDetail
                {
                    CourseId = entity.CourseId,
                    CourseName = entity.CourseName,
                    DateOfRound = entity.DateOfRound,
                    Description = entity.Description,
                    FrontNine = frontNine.ToList(),
                    BackNine = backNine.ToList(),
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

        public ICollection<RoundListItem> GetAllPublicRoundsByUserId()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Rounds
                    .Where(e => e.Id == _userId && e.IsPublic == true)
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
                    .Where(e => e.Id == _userId && e.IsFeatured == true)
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
                    RoundId = e.RoundId,
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

                var score = new List<int>();

                foreach (var hole in model.FrontNine)
                {
                    var holeScore = hole.Score;
                    score.Add(holeScore);
                }

                foreach (var hole in model.BackNine)
                {
                    var holeScore = hole.Score;
                    score.Add(holeScore);
                }

                entity.DateOfRound = model.DateOfRound;
                entity.Description = model.Description;
                entity.IsFeatured = model.IsFeatured;
                entity.IsPublic = model.IsPublic;
                entity.Score = score.Sum();

                ctx.SaveChanges();

                foreach (var hole in model.CourseDetail.FrontNine)
                {
                    foreach (var holeData in model.FrontNine)
                    {
                        if (hole.HoleNumber == holeData.HoleNumber)
                        {
                            holeData.HolePar = hole.Par;
                        }
                    }
                }

                foreach (var hole in model.CourseDetail.BackNine)
                {
                    foreach (var holeData in model.BackNine)
                    {
                        if (hole.HoleNumber == holeData.HoleNumber)
                        {
                            holeData.HolePar = hole.Par;
                        }
                    }
                }

                foreach (var hole in model.FrontNine)
                {
                    var service = new HoleDataServices();

                    service.EditHoleData(hole);
                }

                foreach (var hole in model.BackNine)
                {
                    var service = new HoleDataServices();

                    service.EditHoleData(hole);
                }

                return true;
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

                var posts =
                    ctx
                    .Posts
                    .Where(e => e.RoundId == id)
                    .Select(e => e.PostId);

                var service = new PostServices(_userId);

                foreach(var post in posts)
                {
                    service.DeletePost(post);
                }


                ctx.Rounds.Remove(entity);
                ctx.SaveChanges();

                var query =
                ctx
                .HoleData
                .Where(e => e.RoundId == id)
                .Select(e => e.HoleDataId);

                foreach (var hole in query)
                {
                    var holeService = new HoleDataServices();
                    holeService.DeleteHoleData(hole);
                }


                return true;
            }
        }

        public RoundDetail CreateNullRound()
        {
            var detail = new RoundDetail
            {
                CourseId = 0,
                CourseName = null,
                DateOfRound = null,
                Description = null,
                HoleData = null,
                CourseDetail = null,
                IsFeatured = null,
                IsPublic = null,
                RoundId = 0,
                Score = 0,

            };

            return detail;
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

        public ICollection<RoundDetail> GetAllRounds()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Rounds
                    .Where(e => e.Id == _userId)
                    .Select(e =>
                new RoundDetail
                {
                    RoundId = e.RoundId,
                    CourseName = e.CourseName,
                    DateOfRound = e.DateOfRound,
                    Description = e.Description,
                    IsFeatured = e.IsFeatured,
                    IsPublic = e.IsPublic,
                    Score = e.Score,
                    CourseId = e.CourseId,

                });

                return query.ToArray();
            }
        }

        public ICollection<HoleDataDetail> GetAllHoleData(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
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
                        Score = e.Score,
                        HoleDataId = e.HoleDataId,
                        HolePar = e.HolePar,
                    });

                return query.ToList();
            }
        }

    }
}

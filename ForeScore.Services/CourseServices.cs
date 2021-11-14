using ForeScore.Data;
using ForeScore.Models.CourseModels;
using ForeScore.Models.HoleModels;
using ForeScore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ForeScore.Data.Course;

namespace ForeScore.Services
{
    public class CourseServices
    {
        private readonly string _userId;

        public CourseServices(string userId)
        {
            _userId = userId;
        }

        public bool CreateCourse(CourseCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = new Course();

                entity.Name = model.Name;
                entity.OwnerId = _userId;
                entity.Par = model.Par;
                entity.Rating = model.Rating;
                entity.Slope = model.Slope;
                entity.Address = model.Address;
                entity.City = model.City;
                entity.StateOfResidence = model.StateOfResidence;
                entity.ZipCode = model.ZipCode;
                entity.PhoneNumber = model.PhoneNumber;
                entity.EmailAddress = model.EmailAddress;
                entity.Website = model.Website;
   
                ctx.Courses.Add(entity);
                ctx.SaveChanges();

                var course = ctx.Courses.Find(entity.CourseId);

                var courseId = course.CourseId;

                List<HoleCreate> _holes = new List<HoleCreate>();

                foreach(var hole in model.FrontNine)
                {
                    HoleCreate newHole = new HoleCreate();

                    newHole.CourseId = courseId;
                    newHole.Distance = hole.Distance;
                    newHole.Par = hole.Par;
                    newHole.HoleNumber = hole.HoleNumber;

                    _holes.Add(newHole);
                }

                foreach (var hole in model.BackNine)
                {
                    HoleCreate newHole = new HoleCreate();

                    newHole.CourseId = courseId;
                    newHole.Distance = hole.Distance;
                    newHole.Par = hole.Par;
                    newHole.HoleNumber = hole.HoleNumber;

                    _holes.Add(newHole);
                }

                foreach (var hole in _holes)
                {
                    var service = new HoleServices();
                    service.CreateHole(hole);
                }

                return true;
            }

        }

        public CourseDetail GetCourseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Courses
                    .Single(e => id == e.CourseId);

                Hole[] _holes = entity.Holes.ToArray();

                Hole[] frontNine = _holes.Take(9).ToArray();
                Hole[] backNine = _holes.Skip(9).Take(18).ToArray();

                var course = new CourseDetail
                {
                    Address = entity.Address,
                    EmailAddress = entity.EmailAddress,
                    City = entity.City,
                    Name = entity.Name,
                    Par = entity.Par,
                    PhoneNumber = entity.PhoneNumber,
                    Rating = entity.Rating,
                    Slope = entity.Slope,
                    StateOfResidence = entity.StateOfResidence,
                    Website = entity.Website,
                    ZipCode = entity.ZipCode,
                    CourseId = entity.CourseId,
                    FrontNine = frontNine.ToList(),
                    BackNine = backNine.ToList(),
                    Holes = _holes.ToList()
                };

                return course;
            }
        }

        public IEnumerable<CourseListItem> GetAllCourses()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Courses
                    .Where(e => e.OwnerId == _userId)
                    .Select(e =>
                    new CourseListItem
                    {
                        City = e.City,
                        StateOfResidence = e.StateOfResidence,
                        Name = e.Name,
                        Slope = e.Slope,
                        Rating = e.Rating,
                        Par = e.Par,
                        CourseId = e.CourseId
                    });

                return query.ToArray();
            }
        }

        public bool EditCourse(CourseEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Courses
                    .Single(e => e.CourseId == model.CourseId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.Par = model.Par;
                entity.Slope = model.Slope;
                entity.Rating = model.Rating;
                entity.Address = model.Address;
                entity.ZipCode = model.ZipCode;
                entity.City = model.City;
                entity.StateOfResidence = model.StateOfResidence;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Website = model.Website;
                entity.EmailAddress = model.EmailAddress;
                entity.CourseId = model.CourseId;

                ctx.SaveChanges();


                foreach (var hole in model.Holes)
                {
                    var service = new HoleServices();
                    service.EditHole(hole);
                }

                return true;
            }
        }

        public bool DeleteCourse(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Courses
                    .Single(e => e.CourseId == id && e.OwnerId == _userId);

                ctx.Courses.Remove(entity);
                ctx.SaveChanges();

                var query =
                    ctx
                    .Holes
                    .Where(e => e.CourseId == id)
                    .Select(e => e.HoleId);

                foreach(var hole in query)
                {
                    var service = new HoleServices();
                    service.DeleteHole(hole);
                }

                return true;
            }
        }

        public HoleServices CreateHoleService()
        {
            var service = new HoleServices();
            return service;
        }
    }
}


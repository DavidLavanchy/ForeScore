using ForeScore.Data;
using ForeScore.Models.CourseModels;
using ForeScore.Models.HoleModels;
using ForeScore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ForeScore.Services
{
    public class CourseServices
    {
        private readonly string _userId;

        public CourseServices(string userId)
        {
            _userId = userId;
        }

        public bool CreateCourse(CourseAndHoleCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = new Course();

                entity.Holes = model.CourseCreateModel.Holes;
                entity.Name = model.CourseCreateModel.Name;
                entity.OwnerId = _userId;
                entity.Par = model.CourseCreateModel.Par;
                entity.Rating = model.CourseCreateModel.Rating;
                entity.Slope = model.CourseCreateModel.Slope;
                entity.Address = model.CourseCreateModel.Address;
                entity.City = model.CourseCreateModel.City;
                entity.StateOfResidence = model.CourseCreateModel.StateOfResidence;
                entity.ZipCode = model.CourseCreateModel.ZipCode;
                entity.PhoneNumber = model.CourseCreateModel.PhoneNumber;
                entity.EmailAddress = model.CourseCreateModel.EmailAddress;
                entity.Website = model.CourseCreateModel.Website;
                

                ctx.Courses.Add(entity);

                var course = ctx.Courses.Find(entity);

                var courseId = entity.CourseId;

                List<HoleCreate> _holes = new List<HoleCreate>();

                foreach(var hole in model.HoleCreateModel)
                {
                    HoleCreate newHole = new HoleCreate();

                    newHole.CourseId = courseId;
                    newHole.Distance = hole.Distance;
                    newHole.Par = hole.Par;
                    newHole.HoleNumber = hole.HoleNumber;
                }


                foreach (var hole in _holes)
                {
                    var service = new HoleServices();
                    service.CreateHole(hole);
                }
             
                return ctx.SaveChanges() == 1;
            }
        }

        public CourseDetail GetCourseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Courses
                    .Single(e => id == e.CourseId && e.OwnerId == _userId);

                var course = new CourseDetail
                {
                    Address = entity.Address,
                    EmailAddress = entity.EmailAddress,
                    City = entity.City,
                    Holes = entity.Holes,
                    Name = entity.Name,
                    Par = entity.Par,
                    PhoneNumber = entity.PhoneNumber,
                    Rating = entity.Rating,
                    Slope = entity.Slope,
                    StateOfResidence = entity.StateOfResidence,
                    Website = entity.Website,
                    ZipCode = entity.ZipCode,
                    CourseId = entity.CourseId
                    
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
                        Par = e.Par
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
                entity.Holes = model.Holes;
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

                return ctx.SaveChanges() == 1;
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
                return ctx.SaveChanges() == 1;
            }
        }

        public HoleServices CreateHoleService()
        {
            var service = new HoleServices();
            return service;
        }
    }
}


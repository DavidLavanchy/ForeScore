using ForeScore.Data;
using ForeScore.Models.TeeTimeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Services
{
    public class TeeTimeServices
    {
        private readonly string _userId;

        public TeeTimeServices(string userId)
        {
             _userId = userId;
        }

        public bool CreateTeeTime(TeeTimeCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var teeTime = new TeeTime
                {
                    CourseId = model.CourseId,
                    DateOfTeeTime = model.DateOfTeeTime,
                    Id = _userId,
                };

                var course =
                    ctx
                    .Courses
                    .Single(e => e.CourseId == teeTime.CourseId);

                teeTime.CourseName = course.Name;

                ctx.TeeTimes.Add(teeTime);

                return ctx.SaveChanges() == 1;
            }
        }

        public TeeTimeDetail GetTeeTimeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .TeeTimes
                    .Single(e => e.TeeTimeId == id);

                var crsService = new CourseServices(_userId);

                var courseDetail = crsService.GetCourseById(entity.CourseId);

                var teeTime = new TeeTimeDetail
                {
                    CourseDetail = courseDetail,
                    CourseId = entity.CourseId,
                    DateOfTeeTime = entity.DateOfTeeTime,
                    CourseName = entity.CourseName

                };

                return teeTime;
            }
        }

        public IEnumerable<TeeTimeListItem> UpcomingTeeTimes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .TeeTimes
                    .Where(e => e.Id == _userId && e.DateOfTeeTime > DateTimeOffset.UtcNow)
                    .Select(e =>
                    new TeeTimeListItem
                    {
                        CourseName = e.CourseName,
                        CourseId = e.CourseId,
                        DateOfTeeTime = e.DateOfTeeTime,
                        TeeTimeId = e.TeeTimeId
                    });

                return query.ToArray();
            }
        }

        public IEnumerable<TeeTimeListItem> RecentTeeTimes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .TeeTimes
                    .Where(e => e.Id == _userId && e.DateOfTeeTime < DateTimeOffset.UtcNow)
                    .Select(e =>
                    new TeeTimeListItem
                    {
                        CourseName = e.CourseName,
                        CourseId = e.CourseId,
                        DateOfTeeTime = e.DateOfTeeTime,
                        TeeTimeId = e.TeeTimeId
                    });

                return query.ToArray();
            }
        }

        public bool DeleteTeeTime(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .TeeTimes
                    .Single(e => e.TeeTimeId == id);

                ctx.TeeTimes.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

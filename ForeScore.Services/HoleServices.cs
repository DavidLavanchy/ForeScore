using ForeScore.Data;
using ForeScore.Models.HoleModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Services
{
    public class HoleServices
    {
        public bool CreateHole(HoleCreate model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var hole = new Hole
                {
                    CourseId = model.CourseId,
                    Distance = model.Distance,
                    HoleNumber = model.HoleNumber,
                    Par = model.Par
                };

                ctx.Holes.Add(hole);
                return ctx.SaveChanges() == 1;
            }
        }

        public HoleDetail GetHoleById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Holes
                    .Single(e => e.HoleId == id);

                var hole = new HoleDetail
                {
                    Distance = entity.Distance,
                    HoleNumber = entity.HoleNumber,
                    Par = entity.Par
                };

                return hole;
            }
        }

        public IEnumerable<HoleDetail> GetHolesByCourseId(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Holes
                    .Where(e => e.CourseId == id)
                    .Select(e =>
                    new HoleDetail
                    {
                        Distance = e.Distance,
                        HoleNumber = e.HoleNumber,
                        Par = e.Par
                    });

                var query2 = query.OrderBy(p => p.HoleNumber < p.HoleNumber);

                return query2.ToArray();
            }
        }

        public bool EditHole(HoleEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Holes
                    .Single(e => model.HoleId == e.HoleId);

                entity.HoleNumber = model.HoleNumber;
                entity.Par = model.Par;
                entity.Distance = model.Par;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteHole(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Holes
                    .Single(e => e.HoleId == id);

                ctx.Holes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

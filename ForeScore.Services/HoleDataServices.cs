using ForeScore.Data;
using ForeScore.Models.HoleDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Services
{
    public class HoleDataServices
    {

        public bool CreateHoleData(HoleDataCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = new HoleData
                {
                    DrivingDistance = model.DrivingDistance,
                    FairwayHit = model.FairwayHit,
                    HoleNumber = model.HoleNumber,
                    Penalty = model.Penalty,
                    Putts = model.Putts,
                    Score = model.Score,
                    RoundId = model.RoundId,
                    HolePar = model.HolePar
                };

                ctx.HoleData.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public HoleDataDetail GetHoleDataById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .HoleData
                    .Single(e => e.HoleDataId == id);

                var holeData = new HoleDataDetail
                {
                    DrivingDistance = entity.DrivingDistance,
                    FairwayHit = entity.FairwayHit,
                    HoleNumber = entity.HoleNumber,
                    Penalty = entity.Penalty,
                    Putts = entity.Putts,
                    Score = entity.Score,
                    RoundId = entity.RoundId,
                };

                return holeData;
            }
        }

        public IEnumerable<HoleDataDetail> GetAllHoleDataByRoundId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .HoleData
                    .Where(e => e.RoundId == id)
                    .Select(e =>
                    new HoleDataDetail
                    {
                        DrivingDistance = e.DrivingDistance,
                        FairwayHit = e.FairwayHit,
                        HoleNumber = e.HoleNumber,
                        Penalty = e.Penalty,
                        Putts = e.Putts,
                        Score = e.Score,
                        RoundId = e.RoundId,
                    });

                return query.ToArray();
            }
        }

        public bool EditHoleData(HoleDataEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .HoleData
                    .Single(e => e.HoleDataId == model.HoleDataId);

                entity.DrivingDistance = model.DrivingDistance;
                entity.FairwayHit = model.FairwayHit;
                entity.HoleNumber = model.HoleNumber;
                entity.Penalty = model.Penalty;
                entity.Putts = model.Putts;
                entity.Score = model.Score;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteHoleData(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .HoleData
                    .Single(e => id == e.HoleDataId);

                ctx.HoleData.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

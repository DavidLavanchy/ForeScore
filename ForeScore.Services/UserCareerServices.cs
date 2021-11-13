using ForeScore.Data;
using ForeScore.Models.HoleDataModels;
using ForeScore.Models.RoundModels;
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

        public UserCareerViewModel ViewCareerStats()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Users
                    .Single(e => e.Id == _userId);

                var service = new RoundServices(_userId);

                var rounds = service.GetAllRounds();

                List<HoleDataDetail> _holeData = new List<HoleDataDetail>();

                foreach (var round in rounds)
                {
                    var list = service.GetAllHoleData(round.RoundId);
                    foreach (var hole in list)
                    {
                        _holeData.Add(hole);
                    }
                }


                return
                new UserCareerViewModel
                {
                    FullName = entity.FullName,
                    Handicap = GetHandicap(rounds),
                    Eagles = GetAllEagles(rounds),
                    //Aces = GetAllAces(rounds),
                    AverageDrivingDistance = GetAverageDrivingDistance(rounds),
                    //AveragePutts = GetAveragePutts(rounds),
                    Birdies = GetAllBirdies(rounds),
                    Pars = GetAllPars(rounds),
                    RoundsPlayed = rounds.Count,
                };
            }
        }

        public float GetHandicap(ICollection<RoundDetail> Rounds)
        {
            if (Rounds.Count == 0)
            {
                return default;
            }
            if (Rounds.Count < 5)
            {
                return default;
            }

            if (Rounds.Count <= 20)
            {
                List<float> list = new List<float>();

                foreach (var round in Rounds)
                {
                    if (round.CourseDetail.Slope != null && round.CourseDetail.Rating != null)
                    {
                        float slope = (float)round.CourseDetail.Slope;
                        float rating = (float)round.CourseDetail.Rating;
                        int score = round.Score;

                        float scoreDifferential = ((score - rating) * 113) / slope;
                        list.Add(scoreDifferential);
                    }
                }

                float[] orderedScores = list.OrderBy(p => p).ToArray();

                float scoreOne = orderedScores[0];
                float scoreTwo = orderedScores[1];
                float scoreThree = orderedScores[2];

                float averageScoreDiffirential = (scoreOne + scoreTwo + scoreThree) / 3;

                float handicap = averageScoreDiffirential * 0.96f;

                return handicap;

            }

            if (Rounds.Count >= 20)
            {
                List<float> list = new List<float>();

                foreach (var round in Rounds)
                {
                    if (round.CourseDetail.Slope != null && round.CourseDetail.Rating != null)
                    {
                        float slope = (float)round.CourseDetail.Slope;
                        float rating = (float)round.CourseDetail.Rating;
                        int score = round.Score;

                        float? scoreDifferential = ((score - rating) * 113) / slope;
                        list.Add((float)scoreDifferential);
                    }

                }

                float[] orderedScores = list.OrderBy(p => p).ToArray();

                float scoreOne = orderedScores[0];
                float scoreTwo = orderedScores[1];
                float scoreThree = orderedScores[2];
                float scoreFour = orderedScores[3];
                float scoreFive = orderedScores[4];
                float scoreSix = orderedScores[5];
                float scoreSeven = orderedScores[6];
                float scoreEight = orderedScores[7];
                float scoreNine = orderedScores[8];
                float scoreTen = orderedScores[9];

                float averageScoreDiffirential = (scoreOne + scoreTwo + scoreThree + scoreFive + scoreFive + scoreSix + scoreSeven + scoreEight + scoreNine + scoreTen) / 10;

                float handicap = averageScoreDiffirential * 0.96f;

                return handicap;

            }
            return default;
        }



        public float GetAveragePutts(ICollection<HoleDataDetail> Holes)
        {
            int putts = 0;

            List<HoleDataDetail> overallHoles = new List<HoleDataDetail>();

            foreach (var item in Holes)
            {
                if (item.Putts != null)
                {
                    int puttsForHole = (int)item.Putts;
                    putts = +puttsForHole;
                    overallHoles.Add(item);
                }
            }


            float averagePutts = putts / overallHoles.Count();

            return averagePutts;
        }

        //public int GetAllAces(ICollection<HoleDataDetail> Rounds)
        //{
        //    int aces = 0;

        //    foreach (var round in Rounds)
        //    {

        //       var holeData = round;

        //        foreach (var item in holeData)
        //        {
        //            if (item.Score == 1)
        //            {
        //                aces++;
        //            }

        //        }
        //    }
        //    return aces;
        //}

        public float GetAverageDrivingDistance(ICollection<RoundDetail> Rounds)
        {
            int drivingDistance = 0;
            List<HoleDataDetail> overallHoles = new List<HoleDataDetail>();

            foreach (var round in Rounds)
            {
                var holeData = round.HoleData;

                foreach (var item in holeData)
                {
                    if (item.DrivingDistance != null)
                    {
                        int driveForHole = (int)item.DrivingDistance;
                        drivingDistance = +driveForHole;
                        overallHoles.Add(item);
                    }
                }
            }

            float averageDrivingDistance = drivingDistance / overallHoles.Count();

            return averageDrivingDistance;
        }

        public int GetAllEagles(ICollection<RoundDetail> Rounds)
        {
            var service = new HoleServices();
            int eagles = 0;

            foreach (var round in Rounds)
            {
                var hole = service.GetHoles(round.CourseId);
                var holeData = round.HoleData;

                foreach (var item in holeData)
                {
                    var score = item.Score;
                    var id = item.HoleNumber;

                    foreach (var item2 in hole)
                    {
                        var holePar = item2.Par;
                        var holeId = item2.HoleNumber;

                        if (id == holeId && holePar == 3 && score == 1)
                        {
                            eagles = +0;
                        }

                        if (id == holeId && holePar == score - 2)
                        {
                            eagles += 1;
                        }

                    }
                }
            }
            return eagles;
        }

        public int GetAllPars(ICollection<RoundDetail> Rounds)
        {
            var service = new HoleServices();
            int pars = 0;

            foreach (var round in Rounds)
            {
                var hole = service.GetHoles(round.CourseId);
                var holeData = round.HoleData;

                foreach (var item in holeData)
                {
                    var score = item.Score;
                    var id = item.HoleNumber;

                    foreach (var item2 in hole)
                    {
                        var holePar = item2.Par;
                        var holeId = item2.HoleNumber;

                        if (id == holeId && holePar == score)
                        {
                            pars += 1;
                        }

                    }
                }
            }
            return pars;
        }
        public int GetAllBirdies(ICollection<RoundDetail> Rounds)
        {
            var service = new HoleServices();
            int birdies = 0;

            foreach (var round in Rounds)
            {
                var hole = service.GetHoles(round.CourseId);
                var holeData = round.HoleData;

                foreach (var item in holeData)
                {
                    var score = item.Score;
                    var id = item.HoleNumber;

                    foreach (var item2 in hole)
                    {
                        var holePar = item2.Par;
                        var holeId = item2.HoleNumber;

                        if (id == holeId && holePar == score - 1)
                        {
                            birdies += 1;
                        }

                    }
                }
            }
            return birdies;
        }
    }
}

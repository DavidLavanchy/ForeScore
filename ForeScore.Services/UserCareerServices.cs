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
                    Eagles = GetAllEagles(_holeData),
                    Aces = GetAllAces(_holeData),
                    AverageDrivingDistance = GetAverageDrivingDistance(_holeData),
                    AveragePutts = GetAveragePutts(_holeData),
                    Birdies = GetAllBirdies(_holeData),
                    Pars = GetAllPars(_holeData),
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

        public int GetAllAces(ICollection<HoleDataDetail> Holes)
        {
            int aces = 0;

            foreach (var hole in Holes)
            {
                if (hole.Score == 1)
                {
                    aces = +1;
                }
                else
                {
                    aces = +0;
                }
            }
            return aces;
        }

        public float GetAverageDrivingDistance(ICollection<HoleDataDetail> Holes)
        {
            int drivingDistance = 0;
            List<HoleDataDetail> overallHoles = new List<HoleDataDetail>();

            foreach (var hole in Holes)
            {
                if (hole.DrivingDistance != null)
                {
                    drivingDistance = +(int)hole.DrivingDistance;
                    overallHoles.Add(hole);
                }
            }

            float averageDrivingDistance = drivingDistance / overallHoles.Count();

            return averageDrivingDistance;

        }

        public int GetAllEagles(ICollection<HoleDataDetail> Holes)
        {
            int eagles = 0;

            foreach (var hole in Holes)
            {
                if (hole.Score == 1 && hole.HolePar == 3)
                {
                    eagles = +0;
                }

                if (hole.Score == 2 && hole.HolePar == 4)
                {
                    eagles = +1;
                }

                if (hole.Score == 3 && hole.HolePar == 5)
                {
                    eagles = +1;
                }

                else
                {
                    eagles = +0;
                }

            }

            return eagles;
        }




        public int GetAllPars(ICollection<HoleDataDetail> Holes)
        {
            int pars = 0;

            foreach (var hole in Holes)
            {
                if (hole.Score == 3 && hole.HolePar == 3)
                {
                    pars = +1;
                }

                if (hole.Score == 4 && hole.HolePar == 4)
                {
                    pars = +1;
                }

                if (hole.Score == 5 && hole.HolePar == 5)
                {
                    pars = +1;
                }

                else
                {
                    pars = +0;
                }

            }

            return pars;
        }

        public int GetAllBirdies(ICollection<HoleDataDetail> Holes)
        {
            int birdies = 0;

            foreach (var hole in Holes)
            {
                if (hole.Score == 2 && hole.HolePar == 3)
                {
                    birdies = +1;
                }

                if (hole.Score == 3 && hole.HolePar == 4)
                {
                    birdies = +1;
                }

                if (hole.Score == 4 && hole.HolePar == 5)
                {
                    birdies = +1;
                }

                else
                {
                    birdies = +0;
                }

            }

            return birdies;
        }

    }
}

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
                    FairwaysHit = GetAllFairwaysHit(_holeData),
                    Penalties = GetAllPenalties(_holeData)
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
            List<int> putts = new List<int>();

            List<HoleDataDetail> overallHoles = new List<HoleDataDetail>();

            foreach (var item in Holes)
            {
                if (item.Putts != null)
                {
                    putts.Add((int)item.Putts);
                    overallHoles.Add(item);
                }
            }

            if (overallHoles.Count() == 0 || putts.Sum() == 0)
            {
                return 0;
            }

            float averagePutts = putts.Sum() / overallHoles.Count();

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
            List<int> drivingDistance = new List<int>();
            List<HoleDataDetail> overallHoles = new List<HoleDataDetail>();

            foreach (var hole in Holes)
            {
                if (hole.DrivingDistance != null)
                {
                    drivingDistance.Add((int)hole.DrivingDistance);
                    overallHoles.Add(hole);
                }
            }
            if(overallHoles.Count() == 0 || drivingDistance.Sum() == 0)
            {
                return 0;
            }
            float averageDrivingDistance = drivingDistance.Sum() / overallHoles.Count();

            return averageDrivingDistance;

        }

        public int GetAllEagles(ICollection<HoleDataDetail> Holes)
        {
            List<int> eagles = new List<int>();

            foreach (var hole in Holes)
            {

                if (hole.Score == 2 && hole.HolePar == 4)
                {
                    int score = 1;
                    eagles.Add(score);
                }

                if (hole.Score == 3 && hole.HolePar == 5)
                {
                    int score = 1;
                    eagles.Add(score);
                }

            }

            return eagles.Count();
        }


        public int GetAllPars(ICollection<HoleDataDetail> Holes)
        {
            List<int> pars = new List<int>();

            foreach (var hole in Holes)
            {
                if (hole.Score == 3 && hole.HolePar == 3)
                {
                    int score = 1;
                    pars.Add(score);
                }

                if (hole.Score == 4 && hole.HolePar == 4)
                {
                    int score = 1;
                    pars.Add(score);
                }

                if (hole.Score == 5 && hole.HolePar == 5)
                {
                    int score = 1;
                    pars.Add(score);
                }

            }

            return pars.Count();
        }

        public int GetAllBirdies(ICollection<HoleDataDetail> Holes)
        {
            List<int> birdies = new List<int>();

            foreach (var hole in Holes)
            {
                if (hole.Score == 2 && hole.HolePar == 3)
                {
                    int score = 1;
                    birdies.Add(score);
                }

                if (hole.Score == 3 && hole.HolePar == 4)
                {
                    int score = 1;
                    birdies.Add(score);
                }

                if (hole.Score == 4 && hole.HolePar == 5)
                {
                    int score = 1;
                    birdies.Add(score);
                }


            }

            return birdies.Count();
        }

        public int GetAllFairwaysHit(ICollection<HoleDataDetail> Holes)
        {
            List<int> fairwaysHit = new List<int>();

            foreach (var hole in Holes)
            {
                if (hole.FairwayHit == true)
                {
                    int score = 1;
                    fairwaysHit.Add(score);
                }

            }

            return fairwaysHit.Count();

        }

        public int GetAllPenalties(ICollection<HoleDataDetail> Holes)
        {
            List<int> penalties = new List<int>();

            foreach (var hole in Holes)
            {
                if (hole.Penalty == true)
                {
                    int score = 1;
                    penalties.Add(score);
                }

            }

            return penalties.Count();

        }

    }
}

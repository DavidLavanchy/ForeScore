using ForeScore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.UserCareerModels
{
    public class UserCareerViewModel
    {
        public int UserCareerId { get; set; }
        public string Username { get; set; }
        public float Handicap
        {
            get
            {
                if (Rounds.Count < 5)
                {
                    return default;
                }

                if (Rounds.Count <= 20)
                {
                    List<float> list = new List<float>();

                    foreach (var round in Rounds)
                    {
                        float slope = round.Course.Slope;
                        float rating = round.Course.Rating;
                        int score = round.Score;

                        float scoreDifferential = ((score - rating) * 113) / slope;
                        list.Add(scoreDifferential);
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
                        float slope = round.Course.Slope;
                        float rating = round.Course.Rating;
                        int score = round.Score;

                        float scoreDifferential = ((score - rating) * 113) / slope;
                        list.Add(scoreDifferential);
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
        }
        public float AverageScoreToPar
        {
            get
            {
                List<float> overallAverage = new List<float>();
                List<Hole> overallHoles = new List<Hole>();
                List<int> overallPar = new List<int>();

                foreach (var round in Rounds)
                {
                    var hole = round.Course.Holes;

                    foreach (var item in hole)
                    {
                        overallAverage.Add(item.Score);
                        overallPar.Add(item.Par);
                        overallHoles.Add(item);
                    }
                }

                var sumScore = overallAverage.Sum();
                var sumPar = overallPar.Sum();
                var sumHoles = overallHoles.Count();

                var averageScore = (sumScore - sumPar) / sumHoles;
                return averageScore;
            }
        }
        public int Aces
        {
            get
            {
                int aces = 0;

                foreach (var round in Rounds)
                {

                    var hole = round.Course.Holes;

                    foreach (var item in hole)
                    {
                        if (item.Score == 1)
                        {
                            aces += 1;
                        }
                    }
                }
                return aces;
            }
        }
        public int Eagles
        {
            get
            {
                int eagles = 0;

                foreach (var round in Rounds)
                {

                    var hole = round.Course.Holes;

                    foreach (var item in hole)
                    {
                        if (item.Par == 4 && item.Score == 2)
                        {
                            eagles += 1;
                        }

                        if (item.Par == 5 && item.Score == 3)
                        {
                            eagles += 1;
                        }
                    }
                }
                return eagles;
            }
        }
        public int Birdies
        {
            get
            {
                int birdies = 0;

                foreach (var round in Rounds)
                {

                    var hole = round.Course.Holes;

                    foreach (var item in hole)
                    {
                        if (item.Par == 3 && item.Score == 2)
                        {
                            birdies += 1;
                        }

                        if (item.Par == 4 && item.Score == 3)
                        {
                            birdies += 1;
                        }

                        if (item.Par == 5 && item.Score == 4)
                        {
                            birdies += 1;
                        }
                    }
                }
                return birdies;
            }
        }
        public int Pars
        {
            get
            {
                int pars = 0;

                foreach (var round in Rounds)
                {

                    var hole = round.Course.Holes;

                    foreach (var item in hole)
                    {
                        if (item.Par == 3 && item.Score == 3)
                        {
                            pars += 1;
                        }

                        if (item.Par == 4 && item.Score == 4)
                        {
                            pars += 1;
                        }

                        if (item.Par == 5 && item.Score == 5)
                        {
                            pars += 1;
                        }
                    }
                }
                return pars;
            }
        }
        public float AverageDrivingDistance
        {
            get
            {
                float drivingdistance = 0;
                List<Hole> overallHoles = new List<Hole>();

                foreach (var round in Rounds)
                {
                    var hole = round.Course.Holes;

                    foreach (var item in hole)
                    {
                        drivingdistance += item.DrivingDistance;
                        overallHoles.Add(item);
                    }
                }

                var averageDrivingDistance = drivingdistance / overallHoles.Count();

                return averageDrivingDistance;
            }
        }
        public float AveragePutts
        {
            get
            {
                float putts = 0;
                List<Hole> overallHoles = new List<Hole>();

                foreach (var round in Rounds)
                {
                    var hole = round.Course.Holes;

                    foreach (var item in hole)
                    {
                        putts += item.Putts;
                        overallHoles.Add(item);
                    }
                }

                var averagePutts = putts / overallHoles.Count();

                return averagePutts;
            }
        }
        public int RoundsPlayed
        {
            get
            {
                List<Hole> overallHoles = new List<Hole>();

                foreach (var round in Rounds)
                {
                    var hole = round.Course.Holes;

                    foreach (var item in hole)
                    {
                        overallHoles.Add(item);
                    }
                }

                return overallHoles.Count();
            }
        }
        public List<Round> Rounds { get; set; }
        public List<UserCareer> UserCareersFollowed { get; set; }
        public List<UserCareer> UserCareersFollowing { get; set; }
        public List<Post> Posts { get; set; }
    }
}

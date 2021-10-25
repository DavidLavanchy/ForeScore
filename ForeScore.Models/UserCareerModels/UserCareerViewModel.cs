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
        public string FullName { get; set; }
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
                    var holeData = round.HoleData;

                    foreach (var item in holeData)
                    {
                        overallAverage.Add(item.Score);
                    }

                    foreach (var item in hole)
                    {
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
                    var holeData = round.HoleData;

                    foreach (var item in holeData)
                    {
                        var score = item.Score;
                        var id = item.HoleId;

                        foreach (var item2 in hole)
                        {
                            var holePar = item2.Par;
                            var holeId = item2.HoleId;

                            if (id == holeId && score == 1)
                            {
                                aces = +1;

                            }
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
                    var holeData = round.HoleData;

                    foreach (var item in holeData)
                    {
                        var score = item.Score;
                        var id = item.HoleId;

                        foreach (var item2 in hole)
                        {
                            var holePar = item2.Par;
                            var holeId = item2.HoleId;

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
        }
        public int Birdies
        {
            get
            {
                int birdies = 0;

                foreach (var round in Rounds)
                {

                    var hole = round.Course.Holes;
                    var holeData = round.HoleData;

                    foreach (var item in holeData)
                    {
                        var score = item.Score;
                        var id = item.HoleId;

                        foreach (var item2 in hole)
                        {
                            var holePar = item2.Par;
                            var holeId = item2.HoleId;

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
        public int Pars
        {
            get
            {
                int par = 0;

                foreach (var round in Rounds)
                {

                    var hole = round.Course.Holes;
                    var holeData = round.HoleData;

                    foreach (var item in holeData)
                    {
                        var score = item.Score;
                        var id = item.HoleId;

                        foreach (var item2 in hole)
                        {
                            var holePar = item2.Par;
                            var holeId = item2.HoleId;

                            if (id == holeId && holePar == score)
                            {
                                par += 1;
                            }
                        }
                    }
                }
                return par;
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
                    var holeData = round.HoleData;

                    foreach (var item in holeData)
                    {
                        var id = item.HoleId;

                        foreach (var item2 in hole)
                        {
                            var holeId = item2.HoleId;
                            if (id == holeId)
                            {
                                drivingdistance += item.DrivingDistance;
                                overallHoles.Add(item2);
                            }
                        }
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
                    var holeData = round.HoleData;

                    foreach (var item in holeData)
                    {
                        var id = item.HoleId;

                        foreach (var item2 in hole)
                        {
                            var holeId = item2.HoleId;
                            if (id == holeId)
                            {
                                putts+= item.Putts;
                                overallHoles.Add(item2);
                            }
                        }
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
        public List<ApplicationUser> UserCareersFollowed { get; set; }
        public List<ApplicationUser> UserCareersFollowing { get; set; }
        public List<Post> Posts { get; set; }
    }
}

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
        public int AverageScoreOverPar { get; set; }
        public int Aces { get; set; }
        public int Eagles { get; set; }
        public int Birdies { get; set; }
        public int Pars { get; set; }
        public float AverageDrivingDistance { get; set; }
        public int AveragePutts { get; set; }
        public int RoundsPlayed { get; set; }
        public List<Round> Rounds { get; set; }
        public List<UserCareer> UserCareersFollowed { get; set; }
        public List<UserCareer> UserCareersFollowing { get; set; }
        public List<Post> Posts { get; set; }
    }
}

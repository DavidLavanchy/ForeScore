using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Data
{
    public class UserCareer 
    {
        [Key]
        public int UserCareerId { get; set; }
        public string Username { get; set; }
        public float Handicap { get; set; }
        public float AverageScoreToPar { get; set; }
        public int Aces { get; set; }
        public int Eagles { get; set; }
        public int Birdies { get; set; }
        public int Pars { get; set; }
        public float AverageDrivingDistance { get; set; }
        public float AveragePutts { get; set; }
        public int RoundsPlayed { get; set; }
        public List<Round> Rounds { get; set; }
        public List<UserCareer> UserCareersFollowed { get; set; }
        public List<UserCareer> UserCareersFollowing { get; set; }
        public List<Post> Posts { get; set; }
    }
}

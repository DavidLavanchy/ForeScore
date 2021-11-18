using ForeScore.Data;
using ForeScore.Models.FollowingModels;
using ForeScore.Models.PostModels;
using ForeScore.Models.RoundModels;
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
        public float? Handicap { get; set; }
        public int? Aces { get; set; }
        public int? Eagles { get; set; }
        public int? Birdies { get; set; }
        public int? Pars { get; set; }
        public float? AverageDrivingDistance { get; set; }
        public float? AveragePutts { get; set; }
        public int? RoundsPlayed { get; set; }
        public int? FairwaysHit { get; set; }
        public int? Penalties { get; set; }
        public IEnumerable<FollowingListItem> Following { get; set; }
        public IEnumerable<RoundListItem> RoundDetails { get; set; }
        public IEnumerable<PostListItem> PostDetails { get; set; }

    }
}

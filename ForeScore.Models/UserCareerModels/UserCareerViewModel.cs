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
        public float Handicap { get; set; }
        public int Aces { get; set; }
        public int Eagles { get; set; }
        public int Birdies { get; set; }
        public int Pars { get; set; }
        public float AverageDrivingDistance { get; set; }
        public float AveragePutts { get; set; }
        public int RoundsPlayed { get; set; }
        public virtual ICollection<FollowedBy> FollowedBy { get; set; }
        public virtual ICollection<Following> Following { get; set; }

    }
}

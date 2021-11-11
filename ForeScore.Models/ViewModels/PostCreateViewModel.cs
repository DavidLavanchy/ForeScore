using ForeScore.Models.PostModels;
using ForeScore.Models.RoundModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.ViewModels
{
    public class PostCreateViewModel
    {
        public IEnumerable<RoundListItem> Rounds { get; set; }
        public int? NullRound { get; set; }
    }
}

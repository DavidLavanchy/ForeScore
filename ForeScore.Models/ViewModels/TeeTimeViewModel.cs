using ForeScore.Models.TeeTimeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.ViewModels
{
    public class TeeTimeViewModel
    {
        public List<TeeTimeListItem> UpcomingTeeTimes { get; set; }

        public List<TeeTimeListItem> RecentTeeTimes { get; set; }
    }
}

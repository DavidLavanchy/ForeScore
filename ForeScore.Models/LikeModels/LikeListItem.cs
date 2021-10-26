using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.LikeModels
{
    public class LikeListItem
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int NumberOfLikesOnPost { get; set; }
    }
}

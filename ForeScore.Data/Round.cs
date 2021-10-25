using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Data
{
    public class Round
    {
        [Key]
        public int RoundId { get; set; }
        [Required]
        [ForeignKey(nameof(Course))]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public string Description { get; set; }
        public int Score { get; set; }
        public bool IsPublic { get; set; }
        public bool IsFeatured { get; set; }
        public DateTimeOffset DateOfRound { get; set; }
        public ICollection<HoleData> HoleData { get; set; }
        [Required]
        [ForeignKey(nameof(User))]
        public string Id { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}

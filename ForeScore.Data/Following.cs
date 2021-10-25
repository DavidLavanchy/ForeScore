using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Data
{
    public class Following
    {
        [Key]
        public int FollowingId { get; set; }
        [Required]
        public string Email { get; set; }
        public string FullName { get; set; }
        [Required]
        [ForeignKey(nameof(User))]
        public string Id { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}

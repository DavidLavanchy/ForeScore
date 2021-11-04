using ForeScore.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Models.RoundModels
{
    public class RoundCreateModel
    {
        [Required]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        [Required]
        public int Score { get; set; }
        public bool IsPublic
        {
            get
            {
                return IsPublic;
            }
            set
            {
                if (IsFeatured == true)  
                    IsPublic = true; 
            }
        }
        public bool IsFeatured { get; set; }
        [Required]
        public DateTimeOffset DateOfRound { get; set; }
        [Required]
        [Range(9, 18)]
        public List<HoleData> HoleData { get; set; }
        public string OwnerId { get; set; }
    }
}

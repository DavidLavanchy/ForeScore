using ForeScore.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Data
{
    public class Course 
    {
        [Key]
        public int CourseId { get; set; }
        public string Name { get; set; }
        public float? Slope { get; set; }
        public float? Rating { get; set; }
        public int? Par { get; set; }
        [Range(9,18)]
        public virtual ICollection<Hole> Holes { get; set; }
        public string OwnerId { get; set; }
        public string Address { get; set; }

        public string City { get; set; }

        public enum State
        {
            [Description("Alabama")]
            AL = 1,
            [Description("Alaska")]
            AK,
            [Description("Arkansas")]
            AR,
            [Description("Arizona")]
            AZ,
            [Description("California")]
            CA,
            [Description("Colorado")]
            CO,
            [Description("Connecticut")]
            CT,
            [Description("D.C.")]
            DC,
            [Description("Delaware")]
            DE,
            [Description("Florida")]
            FL,
            [Description("Georgia")]
            GA,
            [Description("Hawaii")]
            HI,
            [Description("Iowa")]
            IA,
            [Description("Idaho")]
            ID,
            [Description("Illinois")]
            IL,
            [Description("Indiana")]
            IN,
            [Description("Kansas")]
            KS,
            [Description("Kentucky")]
            KY,
            [Description("Louisiana")]
            LA,
            [Description("Massachusetts")]
            MA,
            [Description("Maryland")]
            MD,
            [Description("Maine")]
            ME,
            [Description("Michigan")]
            MI,
            [Description("Minnesota")]
            MN,
            [Description("Missouri")]
            MO,
            [Description("Mississippi")]
            MS,
            [Description("Montana")]
            MT,
            [Description("North Carolina")]
            NC,
            [Description("North Dakota")]
            ND,
            [Description("Nebraska")]
            NE,
            [Description("New Hampshire")]
            NH,
            [Description("New Jersey")]
            NJ,
            [Description("New Mexico")]
            NM,
            [Description("Nevada")]
            NV,
            [Description("New York")]
            NY,
            [Description("Oklahoma")]
            OK,
            [Description("Ohio")]
            OH,
            [Description("Oregon")]
            OR,
            [Description("Pennsylvania")]
            PA,
            [Description("Rhode Island")]
            RI,
            [Description("South Carolina")]
            SC,
            [Description("South Dakota")]
            SD,
            [Description("Tennessee")]
            TN,
            [Description("Texas")]
            TX,
            [Description("Utah")]
            UT,
            [Description("Virginia")]
            VA,
            [Description("Vermont")]
            VT,
            [Description("Washington")]
            WA,
            [Description("Wisconsin")]
            WI,
            [Description("West Virginia")]
            WV,
            [Description("Wyoming")]
            WY
        }
        public State StateOfResidence { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Website { get; set; }


    }
}


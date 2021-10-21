using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeScore.Contracts
{
    public class ContactInformation
    {
        [DisplayName("Address")]
        [MaxLength(100)]
        [MinLength(1)]
        public string Address { get; set; }

        [DisplayName("City")]
        [MaxLength(100)]
        [MinLength(1)]
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
        [DisplayName("State")]
        public State StateOfResidence { get; set; }

        [MaxLength(5)]
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }

        [DisplayName("Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [DisplayName("Email Address")]
        [MaxLength(200)]
        public string EmailAddress { get; set; }

        [Url]
        [DisplayName("Website")]
        public string Website { get; set; }

        public ContactInformation(string address, string city, string zipCode, State stateOfResidence, string phoneNumber, string emailAddress)
        {
            Address = address;
            City = city;
            StateOfResidence = stateOfResidence;
            ZipCode = zipCode;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
        }
        public ContactInformation() { }

    }
}


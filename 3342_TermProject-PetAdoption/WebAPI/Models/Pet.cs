using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Pet
    {
        public int petID { get; set; }
        public string name { get; set; }
        public int userID { get; set; }
        public string animal { get; set; }
        public string breed { get; set; }
        public int goodWithKids { get; set; }
        public int goodWithPets { get; set; }
        public string location { get; set; }
        public string ageRange { get; set; }
    }
}

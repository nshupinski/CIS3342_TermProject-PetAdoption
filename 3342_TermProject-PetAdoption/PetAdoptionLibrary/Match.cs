using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoptionLibrary
{

    public class Match
    {
        public string animal { get; set; }
        public int goodWithKids { get; set; }
        public int goodWithPets { get; set; }
        public string location { get; set; }
        public string ageRange { get; set; }

        public Match()
        {

        }
    }
}

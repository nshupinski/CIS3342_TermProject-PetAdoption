using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoptionLibrary
{
    public class Pet
    {
        public int petID { get; set; }
        public string name { get; set; }
        public string shelterUser { get; set; }
        public string animal { get; set; }
        public string breed { get; set; }
        public int goodWithKids { get; set; }
        public int goodWithPets { get; set; }
        public string location { get; set; }
        public string ageRange { get; set; }

        public Pet()
        {
        }

        public Pet(string name, int petID, string shelterUser, string animal, string breed, int goodWithKids, int goodWithPets, string location, string ageRange)
        {
            this.name = name;
            this.petID = petID;
            this.shelterUser = shelterUser;
            this.animal = animal;
            this.breed = breed;
            this.goodWithKids = goodWithKids;
            this.goodWithPets = goodWithPets;
            this.location = location;
            this.ageRange = ageRange;
            addToDatabase();

        }

        protected void addToDatabase()
        {
            // use API to add new pet to database
        }

        protected decimal testCompatibility()
        {
            decimal compatNum = 0;
            //takes in the user's search results, generates compatibility, returns number for this specific pet
            return compatNum;
        }
    }
}

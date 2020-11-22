using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoptionLibrary
{
    public class Pet
    {

        string name;
        string userID;
        string animal;
        string breed;
        bool goodWithKids;
        bool goodWithPets;
        string location;
        string ageRange;

        public Pet(string name, string userID, string animal, string breed, bool goodWithKids, bool goodWithPets, string location, string ageRange)
        {
            this.name = name;
            this.userID = userID;
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

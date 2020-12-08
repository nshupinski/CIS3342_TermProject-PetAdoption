using PetAdoptionLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3342_TermProject_PetAdoption
{
    public partial class Pet_Page : System.Web.UI.Page
    {
        Pet pet = new Pet();

        protected void Page_Load(object sender, EventArgs e)
        {
            int petID = int.Parse(Session["selectedPet"].ToString());

            // Get Selected Pet
            WebRequest request = WebRequest.Create("https://localhost:44361/api/Pet/GetPetByID/" + petID);
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            Pet selectedPet = js.Deserialize<Pet>(data);

            pet = selectedPet;

            txtAnimal.Text = selectedPet.animal.ToString();
            txtBreed.Text = selectedPet.breed.ToString();
            txtGWKids.Text = selectedPet.goodWithKids.ToString();
            txtGWPets.Text = selectedPet.goodWithPets.ToString();
            txtLocation.Text = selectedPet.location.ToString();
            txtAge.Text = selectedPet.ageRange.ToString();
        }

        protected void btnLove_Clicked(object sender, EventArgs e)
        {
            string userID = Session["Username"].ToString();
            
            PetsSOAP.Pets proxy = new PetsSOAP.Pets();
            proxy.likePet(userID, pet.petID);

            btnLove.Style["background-color"] = "red";
        }

        protected void btnAdopt_Clicked(object sender, EventArgs e)
        {

        }
    }
}
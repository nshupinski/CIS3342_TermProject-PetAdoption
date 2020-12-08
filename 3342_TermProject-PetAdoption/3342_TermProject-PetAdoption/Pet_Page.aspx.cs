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
            // Disable pet info if user is adopter
            if(Session["UserType"].ToString() == "PetAdopter")
            {
                txtName.Enabled = false;
                txtAnimal.Enabled = false;
                txtBreed.Enabled = false;
                txtShelter.Enabled = false;
                txtGWKids.Enabled = false;
                txtGWPets.Enabled = false;
                txtLocation.Enabled = false;
                txtAge.Enabled = false;
            }

            string userType = Session["UserType"].ToString();

            if (userType == null)
            {
                Response.Redirect("Login.aspx");
            }else if(userType == "PetAdopter")
            {
                var AddPets = Page.Master.FindControl("addPetLink");
                AddPets.Visible = false;
            }
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
            txtName.Text = selectedPet.name.ToString();
            txtAnimal.Text = selectedPet.animal.ToString();
            txtBreed.Text = selectedPet.breed.ToString();
            txtShelter.Text = selectedPet.shelterUser.ToString();
            txtGWKids.Text = selectedPet.goodWithKids.ToString();
            txtGWPets.Text = selectedPet.goodWithPets.ToString();
            txtLocation.Text = selectedPet.location.ToString();
            txtAge.Text = selectedPet.ageRange.ToString();

            if(txtGWKids.Text == "0")
            {
                txtGWKids.Text = "No";
            }
            if (txtGWPets.Text == "0")
            {
                txtGWPets.Text = "No";
            }

            petPhoto.Src = "ImageGrab.aspx?ID=" + pet.petID;
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
            string userID = Session["Username"].ToString();

            PetsSOAP.Pets proxy = new PetsSOAP.Pets();
            proxy.AddRequest(userID, pet.petID);

            modal.Style["visibility"] = "visible";
        }

        protected void btnAdoptClose_Clicked(object sender, EventArgs e)
        {
            modal.Style["visibility"] = "hidden";
        }
    }
}
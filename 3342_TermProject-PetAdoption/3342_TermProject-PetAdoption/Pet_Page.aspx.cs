using PetAdoptionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3342_TermProject_PetAdoption
{
    public partial class Pet_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Pet selectedPet = (Pet)Session["selectedPet"];

            txtAnimal.Text = selectedPet.animal.ToString();
            txtBreed.Text = selectedPet.breed.ToString();
            txtGWKids.Text = selectedPet.goodWithKids.ToString();
            txtGWPets.Text = selectedPet.goodWithPets.ToString();
            txtLocation.Text = selectedPet.location.ToString();
            txtAge.Text = selectedPet.ageRange.ToString();
        }
    }
}
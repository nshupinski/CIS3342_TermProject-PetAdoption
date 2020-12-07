using PetAdoptionLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace _3342_TermProject_PetAdoption
{
    public partial class Home : System.Web.UI.Page
    {
        DataSet myDS = new DataSet();
        List<Pet> pets = new List<Pet>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!(IsPostBack))
            {
                WebRequest request = WebRequest.Create("https://localhost:44361/api/Pet/GetAllPets/");
                WebResponse response = request.GetResponse();

                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                JavaScriptSerializer js = new JavaScriptSerializer();
                List<Pet> petsList = js.Deserialize<List<Pet>>(data);
                pets = petsList;

                DataList1.DataSource = pets;
                DataList1.DataBind();
                /*foreach (Pet pet in petsList) {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", "createPetCard('" + pet.name + "', '" + pet.petID + "', '" + pet.shelterUser + "', '" + pet.animal + "', '" + pet.breed + "', '" + pet.goodWithKids + "', '" + pet.goodWithPets + "', '" + pet.location + "', '" + pet.ageRange + "')", true);
                }*/
            }
        }

        protected void btnCompatTest_Clicked(object sender, EventArgs e)
        {

        }

        protected void btnView_Clicked(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            clickedButton.ID = clickedButton.ID.Replace("btnView_", "");

            for (int i = 0; i < pets.Count; i++)
            {
                /*if(pets[i].petID == clickedButton.ID)
                {
                    Session.Add("selectedPet", pets[i]);
                    Response.Redirect("Pet_Page.aspx");
                }*/
            }
        }
    }
}
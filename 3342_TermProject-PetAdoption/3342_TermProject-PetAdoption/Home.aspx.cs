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

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!(IsPostBack))
            {
                WebRequest request = WebRequest.Create("https://localhost:44361/api/Pet/GetAllPets");
                WebResponse response = request.GetResponse();

                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                JavaScriptSerializer js = new JavaScriptSerializer();
                List<Pet> petsList = js.Deserialize<List<Pet>>(data);

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "createPetCard(petsList)", true);
            }
        }

        protected void btnCompatTest_Clicked(object sender, EventArgs e)
        {

        }
    }
}
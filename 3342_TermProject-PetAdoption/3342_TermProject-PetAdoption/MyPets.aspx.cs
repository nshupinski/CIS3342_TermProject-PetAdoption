using PetAdoptionLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3342_TermProject_PetAdoption
{
    public partial class MyPets : System.Web.UI.Page
    {
        string userType;
        string username;
        List<Pet> pets = new List<Pet>();

        protected void Page_Load(object sender, EventArgs e)
        {
            userType = Session["UserType"].ToString();
            username = Session["Username"].ToString();

            if (userType == "PetAdopter")
            {
                loadLikedPets();
                description.InnerText = "Here we display all of the pets you've liked. Click on the 'View Pet' button for more information.";
                var AddPets = Page.Master.FindControl("addPetLink");
                AddPets.Visible = false;
            }
            else
            {
                loadShelterPets();
                description.InnerText = "Here we display all of the pets you've uploaded. Click on the 'View Pet' button for more information.";
            }

        }

        public void loadLikedPets()
        {
            WebRequest request = WebRequest.Create("https://localhost:44361/api/Pet/GetLikedPets/" + username);
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Pet> petsList = js.Deserialize<List<Pet>>(data);
            pets = petsList;
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(pets);
            dt.Columns.Add("imgFile");

            foreach (DataRow tempRow in dt.Rows)
            {
                tempRow["imgFile"] = "ImageGrab.aspx?ID=" + tempRow["petID"];
            }

            rptPet.DataSource = dt;
            rptPet.DataBind();
        }

        public void loadShelterPets()
        {
            WebRequest request = WebRequest.Create("https://localhost:44361/api/Pet/GetShelterPets/" + username);
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Pet> petsList = js.Deserialize<List<Pet>>(data);
            pets = petsList;
            ListtoDataTableConverter converter = new ListtoDataTableConverter();
            DataTable dt = converter.ToDataTable(pets);
            dt.Columns.Add("imgFile");

            foreach (DataRow tempRow in dt.Rows)
            {
                tempRow["imgFile"] = "ImageGrab.aspx?ID=" + tempRow["petID"];
            }

            rptPet.DataSource = dt;
            rptPet.DataBind();
        }

        protected void rptPet_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int rowIndex = e.Item.ItemIndex;
            Label myLabel = (Label)rptPet.Items[rowIndex].FindControl("lblPetID");
            String pet = myLabel.Text;
            int petID = Int32.Parse(pet);
            Session.Add("selectedPet", petID);
            Response.Redirect("PetPage.aspx");
        }

        public class ListtoDataTableConverter
        {

            public DataTable ToDataTable<T>(List<T> items)

            {

                DataTable dataTable = new DataTable(typeof(T).Name);

                //Get all the properties

                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (PropertyInfo prop in Props)

                {

                    //Setting column names as Property names

                    dataTable.Columns.Add(prop.Name);

                }

                foreach (T item in items)

                {

                    var values = new object[Props.Length];

                    for (int i = 0; i < Props.Length; i++)

                    {

                        //inserting property values to datatable rows

                        values[i] = Props[i].GetValue(item, null);

                    }

                    dataTable.Rows.Add(values);

                }

                //put a breakpoint here and check datatable

                return dataTable;

            }

        }
    }
}
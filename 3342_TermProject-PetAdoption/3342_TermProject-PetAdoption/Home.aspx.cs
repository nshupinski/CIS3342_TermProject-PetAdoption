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
            string userType = Session["UserType"].ToString();

            if(userType == "PetAdopter")
            {
                var AddPets = Page.Master.FindControl("addPetLink");
                AddPets.Visible = false;
            }

            if (!(IsPostBack))
            {
                // Get Pet objects
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
                ListtoDataTableConverter converter = new ListtoDataTableConverter();
                DataTable dt = converter.ToDataTable(pets);
                dt.Columns.Add("imgFile");

                foreach(DataRow tempRow in dt.Rows)
                {
                    tempRow["imgFile"] = "ImageGrab.aspx?ID=" + tempRow["petID"];
                }

                rptPet.DataSource = dt;
                rptPet.DataBind();

                
            }
        }


        protected void btnCompatTest_Clicked(object sender, EventArgs e)
        {

        }


        protected void rptPet_ItemCommand(Object source, RepeaterCommandEventArgs e)
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
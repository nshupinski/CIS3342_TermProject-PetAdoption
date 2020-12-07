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
        List<PetPicture> petPics = new List<PetPicture>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!(IsPostBack))
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

                DataList1.DataSource = pets;
                DataList1.DataBind();

                buildCards();

                // Get Pet pictures
                WebRequest request2 = WebRequest.Create("https://localhost:44361/api/Pet/GetAllPets/");
                WebResponse response2 = request2.GetResponse();

                Stream theDataStream2 = response2.GetResponseStream();
                StreamReader reader2 = new StreamReader(theDataStream);
                String data2 = reader2.ReadToEnd();
                reader2.Close();
                response2.Close();

                JavaScriptSerializer js2 = new JavaScriptSerializer();
                List<PetPicture> petPictures = js2.Deserialize<List<PetPicture>>(data);
                petPics = petPictures;
            }
        }

        protected void buildCards()
        {
            if(pets.Count != 0)
            {
                int col = 0;

                for (int i = 0; i < pets.Count; i++)
                {
                    col++;

                    Table table = new Table();

                    TableRow imageRow = new TableRow();
                    TableCell imageValue = new TableCell();
                    Image picValue = new Image();
                    TableRow nameRow = new TableRow();
                    TableHeaderCell nameValue = new TableHeaderCell();
                    TableRow contentRow = new TableRow();
                    TableCell contentValue = new TableCell();
                    TableRow contentRow2 = new TableRow();
                    TableCell contentValue2 = new TableCell();
                    TableRow buttonRow = new TableRow();
                    TableCell buttonValue = new TableCell();

                    // Assign values

                    nameValue.Text = pets[i].name;
                    contentValue.Text = pets[i].breed + " - " + pets[i].ageRange;
                    contentValue.Text = " - " + pets[i].location;

                    // Create a View Button 
                    Button viewButton = new Button();
                    viewButton.Text = "View";
                    viewButton.CssClass = "viewButton";
                    viewButton.ID = pets[i].petID.ToString();
                    viewButton.Width = 120;
                    viewButton.Click += new EventHandler(this.btnView_Clicked);
                    buttonValue.Controls.Add(viewButton);

                    // Append all cells to rows and rows to table
                    //picValue.Controls.Add(picValue);

                    imageRow.Cells.Add(imageValue);
                    nameRow.Cells.Add(nameValue);
                    contentRow.Cells.Add(contentValue);
                    contentRow2.Cells.Add(contentValue2);
                    buttonRow.Cells.Add(buttonValue);

                    table.Rows.Add(imageRow);
                    table.Rows.Add(nameRow);
                    table.Rows.Add(contentRow);
                    table.Rows.Add(contentRow2);
                    table.Rows.Add(buttonRow);

                    if (col == 1)
                    {
                        col1.Controls.Add(table);
                    }
                    else if (col == 2)
                    {
                        col2.Controls.Add(table);
                    }
                    else if (col == 3)
                    {
                        col3.Controls.Add(table);
                    }
                    else if (col > 3)
                    {
                        col1.Controls.Add(table);
                        col = 0;
                    }
                }
            }
        }

        protected void btnCompatTest_Clicked(object sender, EventArgs e)
        {

        }

        protected void btnView_Clicked(object sender, EventArgs e)
        {
            Pet selectedPet = new Pet(); ;
            Button clickedButton = sender as Button;
            int id = int.Parse(clickedButton.ID);

            foreach(Pet pet in pets)
            {
                if(pet.petID == id)
                {
                    selectedPet = pet;
                }
            }

            Session.Add("selectedPet", selectedPet);
            Response.Redirect("Pet_Page.aspx");
        }
    }
}
using _3342_TermProject_PetAdoption.Accounts;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetAdoptionLibrary;
using System.Data.SqlClient;

namespace _3342_TermProject_PetAdoption
{
    public partial class Profile : System.Web.UI.Page
    {
        string userType;
        string username;

        protected void Page_Load(object sender, EventArgs e)
        {

            userType = Session["UserType"].ToString();
            if (userType == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (userType == "PetAdopter")
            {
                var AddPets = Page.Master.FindControl("addPetLink");
                AddPets.Visible = false;
            }
            loadUser();

        }

        public void loadUser()
        {
            username = Session["Username"].ToString();

            WebRequest request = WebRequest.Create("https://localhost:44361/api/Account/GetUser/" + username);
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            Accounts.Account account = js.Deserialize<Accounts.Account>(data);

            lblUsername.InnerText = account.username;
            lblEmail.Text = account.email;
            lblLocation.Text = account.city + ", " + account.state;
            string phone = String.Format("{0:(###) ###-####}", double.Parse(account.phoneNum));
            lblPhone.Text = phone;
            string type = account.accountType;

            if(type == "PetAdopter")
            {
                lblType.Text = "Pet Adopter";
                profileimg.Src = "images/adopter.png";
                lblPetGV.Text = "<b>Pets I've Inquired About</b> - The shelter has been notified of your request and will contact you via Phone to inquire further. The final decision will be reflected in the 'Status' column.";
                loadAdopterGV();
            }
            else
            {
                lblType.Text = "Shelters & Rescues";
                profileimg.Src = "images/shelter.png";
                lblPetGV.Text = "<b>Unprocessed Pet Inquiries</b> - Please contact the inquirer via phone number for any questions/interviews. Update the final decision with either an Approval or Denial.";
                loadShelterGV();
            }



        }

        public void loadAdopterGV()
        {
            gvShelter.Visible = false;
            gvAdopter.Visible = true;
            DBConnect objDB = new DBConnect();
            SqlCommand getPetsCMD = new SqlCommand();
            getPetsCMD.CommandType = System.Data.CommandType.StoredProcedure;
            getPetsCMD.CommandText = "TP_GetAdopterPets";
            getPetsCMD.Parameters.AddWithValue("@username", username);
            DataSet data = objDB.GetDataSetUsingCmdObj(getPetsCMD);
            if(data.Tables[0].Rows.Count == 0)
            {
                lblGridView.Visible = true;
                lblGridView.Text = "You have made no adoption requests!";
            }
            gvAdopter.DataSource = data;
            gvAdopter.DataBind();
        }

        public void loadShelterGV()
        {
            gvShelter.Visible = true;
            DBConnect objDB = new DBConnect();
            SqlCommand getPetsCMD = new SqlCommand();
            getPetsCMD.CommandType = System.Data.CommandType.StoredProcedure;
            getPetsCMD.CommandText = "TP_GetShelterPets";
            getPetsCMD.Parameters.AddWithValue("@username", username);
            DataSet data = objDB.GetDataSetUsingCmdObj(getPetsCMD);
            if (data.Tables[0].Rows.Count == 0)
            {
                lblGridView.Visible = true;
                lblGridView.Text = "There are no unprocessed adoption requests.";
            }
            gvShelter.DataSource = data;
            gvShelter.DataBind();
        }

        protected void gvShelter_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            String username = gvShelter.Rows[rowIndex].Cells[0].Text;
            int petID = Int32.Parse(gvShelter.Rows[rowIndex].Cells[2].Text);
            string status;

            switch (e.CommandName)
            {
                case "ApproveRequest":

                    status = "Approved";
                    PetsSOAP.Accounts approveProxy = new PetsSOAP.Accounts();
                    approveProxy.updateStatus(username, petID, status);
                    loadShelterGV();

                    break;

                case "DenyRequest":

                    status = "Denied";
                    PetsSOAP.Accounts denyProxy = new PetsSOAP.Accounts();
                    denyProxy.updateStatus(username, petID, status);
                    loadShelterGV();

                    break;
            }

        }

        protected void gvAdopter_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            int petID = Int32.Parse(gvAdopter.Rows[rowIndex].Cells[0].Text);

            PetsSOAP.Accounts proxy = new PetsSOAP.Accounts();
            proxy.deleteRequest(username, petID);
            loadAdopterGV();

        }
    }
}
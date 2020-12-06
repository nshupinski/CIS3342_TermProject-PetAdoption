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

namespace _3342_TermProject_PetAdoption
{
    public partial class Profile : System.Web.UI.Page
    {
        string userType;

        protected void Page_Load(object sender, EventArgs e)
        {
            userType = Session["UserType"].ToString();

            if(userType == "PetAdopter")
            {
                loadUser();
            }
            else
            {
                loadUser();
            }

        }

        public void loadUser()
        {
            string username = Session["Username"].ToString();

            WebRequest request = WebRequest.Create("https://localhost:44361/api/Account/GetUser/" + username);
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            Account account = js.Deserialize<Account>(data);

            lblUsername.InnerText = account.username;
            lblEmail.Text = account.email;
            lblLocation.Text = account.city + ", " + account.state;
            string phone = String.Format("{0:(###) ###-####}", double.Parse(account.phoneNum));
            lblPhone.Text = phone;
            string type = account.accountType;

            if(type == "PetAdopter")
            {
                lblType.Text = "Pet Adopter";
            }
            else
            {
                lblType.Text = "Shelters & Rescues";
            }

        }

        public void loadShelter()
        {

        }

        
    }
}
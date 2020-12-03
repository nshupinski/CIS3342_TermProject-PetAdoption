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
    public partial class Login : System.Web.UI.Page
    {
        string username;
        string password;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Clicked(object sender, EventArgs e)
        {
            username = username_input.Text;
            password = password_input.Text;
            String userType;

            if (userPet.Checked)
            {
                userType = userPet.Value;
            }
            else
            {
                userType = userShelter.Value;
            }

            PetsSOAP.Accounts proxy = new PetsSOAP.Accounts();
            Boolean result = proxy.verifyLogin(username, password, userType);

            if (result)
            {

                WebRequest request = WebRequest.Create("https://localhost:44361/api/Account/GetUserVerified/" + username);
                WebResponse response = request.GetResponse();

                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                JavaScriptSerializer js = new JavaScriptSerializer();
                Boolean verified = js.Deserialize<Boolean>(data);

                if (verified)
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    Response.Redirect("Verification.aspx");
                }

            }
            else
            {
                lblErrors.Text = "Login failed. You can reset your password if you need to!";
            }

        }

        protected void btnCreateAccount_Clicked(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void btnDeleteCookie_Clicked(object sender, EventArgs e)
        {

        }
    }
}
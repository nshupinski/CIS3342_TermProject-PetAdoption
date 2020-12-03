using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                Response.Redirect("Home.aspx");
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
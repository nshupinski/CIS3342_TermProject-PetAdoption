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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Clicked(object sender, EventArgs e)
        {

        }

        protected void btnCreateAccount_Clicked(object sender, EventArgs e)
        {
            Server.Transfer("Register.aspx");
        }
    }
}
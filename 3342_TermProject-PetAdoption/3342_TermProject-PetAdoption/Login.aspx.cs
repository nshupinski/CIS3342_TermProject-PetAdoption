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
        protected void Page_Load(object sender, EventArgs e)
        {

            var profile = Page.Master.FindControl("profileLink");
            profile.Visible = false;
            var pets = Page.Master.FindControl("petsLink");
            pets.Visible = false;
            var AddPets = Page.Master.FindControl("addPetLink");
            AddPets.Visible = false;
            var LogOut = Page.Master.FindControl("btnLogOut");
            LogOut.Visible = false;

            if (!IsPostBack)
            {
                HttpCookie reqCookies = Request.Cookies["userInfo"];

                if(reqCookies != null)
                {
                    username_input.Text = reqCookies["Username"].ToString();
                    password_input.Text = reqCookies["Password"].ToString();
                    string userType = reqCookies["UserType"].ToString();
                    checkCookies.Checked = true;

                    if(userType == "PetAdopter")
                    {
                        userPet.Checked = true;
                    }
                    else
                    {
                        userPet.Checked = false;
                        userShelter.Checked = true;
                    }
                }
                else
                {
                    Session.Add("UserType", null);
                    Session.Add("Username", null);
                }
                
            }
        }

        protected void btnLogin_Clicked(object sender, EventArgs e)
        {
            string username = username_input.Text;
            string password = password_input.Text;
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
                Session["UserType"] = userType;
                Session["Username"] = username;

                WebRequest request = WebRequest.Create("https://localhost:44361/api/Account/GetUserVerified/" + username);
                WebResponse response = request.GetResponse();

                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();

                JavaScriptSerializer js = new JavaScriptSerializer();
                Boolean verified = js.Deserialize<Boolean>(data);

                if (checkCookies.Checked)
                {
                    HttpCookie userInfo = new HttpCookie("userInfo");
                    userInfo["Username"] = username;
                    userInfo["UserType"] = userType;
                    userInfo["Password"] = password;
                    userInfo.Expires.Add(new TimeSpan(12, 0, 0));
                    Response.Cookies.Add(userInfo);
                }
                else
                {
                    if (Request.Cookies["userInfo"] != null)
                    {
                        Response.Cookies["userInfo"].Expires = DateTime.Now.AddDays(-1);
                    }
                }

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
            Session["UserType"] = null;
            Session["UserID"] = null;

            if(Request.Cookies["userInfo"] != null){
                Response.Cookies["userInfo"].Expires = DateTime.Now.AddDays(-1);
            }
            Response.Redirect("Login.aspx");
        }

        protected void btnForgotPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgetPassword.aspx");
        }
    }
}
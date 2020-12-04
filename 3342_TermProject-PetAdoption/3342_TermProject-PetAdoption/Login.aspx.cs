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
            if (!IsPostBack)
            {
                HttpCookie reqCookies = Request.Cookies["userInfo"];
                if(reqCookies != null)
                {
                    Session.Add("UserType", reqCookies["UserType"].ToString());
                    Session.Add("Username", reqCookies["Username"].ToString());
                    string username = reqCookies["Username"].ToString();

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

                HttpCookie userInfo = new HttpCookie("userInfo");
                userInfo["Username"] = username;
                userInfo["UserType"] = userType;
                userInfo.Expires.Add(new TimeSpan(12, 0, 0));
                Response.Cookies.Add(userInfo);

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
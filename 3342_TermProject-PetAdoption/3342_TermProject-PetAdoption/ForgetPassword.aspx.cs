using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3342_TermProject_PetAdoption
{
    public partial class ForgetPassword : System.Web.UI.Page
    {

        string question1 = "Security Question: What was your childhood nickname?";
        string question2 = "Security Question: What was the last name of your third-grade teacher?";
        string question3 = "Security Question: What is the name of your favorite pet?";
        Random rnd = new Random();



        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                int num = rnd.Next(1, 4);
                Session.Add("QuestionNum", num);

                if (num == 1)
                {
                    lblsecurityQuestion.Text = question1;
                }
                else if (num == 2)
                {
                    lblsecurityQuestion.Text = question2;
                }
                else
                {
                    lblsecurityQuestion.Text = question3;
                }
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int num = Int32.Parse(Session["QuestionNum"].ToString());
            string username = username_input.Text;
            Session.Add("User", username);
            string answer = security_input.Text;

            WebRequest request = WebRequest.Create("https://localhost:44361/api/Account/GetSecurityAnswer/" + username + "/" + num);
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            string correct = data;

            if (answer == correct)
            {
                passwordDiv.Visible = true;
                securityDiv.Visible = false;
            }
            else
            {
                lblErrors.Text = "Security answer or email is incorrect.";
            }

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            string newPassword;
            string username = Session["User"].ToString();

            if (password_input.Text == password2_input.Text)
            {
                newPassword = password_input.Text;
                PetsSOAP.Accounts proxy = new PetsSOAP.Accounts();
                Boolean result = proxy.changePassword(username, newPassword);
                if (result)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    lblErrors.Text = "Error updating new password. Try again later.";
                }
            }
            else
            {
                lblErrorsPassword.Text = "Passwords must match.";
                return;
            }
        }
    }
}
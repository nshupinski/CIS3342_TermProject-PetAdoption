using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using _3342_TermProject_PetAdoption.Accounts;

namespace _3342_TermProject_PetAdoption
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateAccount_Clicked(object sender, EventArgs e)
        {
            Account newAccount = new Account();

            if (!validateUsername(username_input.Text))
            {
                newAccount.username = username_input.Text;
            }
            else
            {
                lblErrors.Text = "Username is already taken.";
                return;
            }

            if (!validateEmail(email_input.Text))
            {
                newAccount.email = email_input.Text;
            }
            else
            {
                lblErrors.Text = "Email is already taken.";
                return;
            }

            if (userPet.Checked)
            {
                newAccount.accountType = userPet.Value;
            }
            else
            {
                newAccount.accountType = userShelter.Value;
            }

            string password1 = password_input.Text;
            string password2 = password2_input.Text;

            if (password1 == password2)
            {
                newAccount.password = password_input.Text;
            }
            else
            {
                lblErrors.Text = "Passwords do not match.";
                return;
            }

            long value;
            Boolean parse = Int64.TryParse(phone_input.Text, out value);

            if (Int64.TryParse(phone_input.Text, out value))
            {
                
            }
            else
            {
                lblErrors.Text = "Phone number is not in a valid format.";
                return;
            }

            if (!validatePhone(phone_input.Text))
            {
                newAccount.phoneNum = phone_input.Text;
            }
            else
            {
                lblErrors.Text = "Phone number is already in use.";
                return;
            }

            newAccount.city = city_input.Text;

            if(state_input.SelectedItem.Value == "")
            {
                lblErrors.Text = "Please select a state.";
                return;
            }
            else
            {
                newAccount.state = state_input.SelectedItem.Value;
            }

            newAccount.secAnswer1 = secAnswer1.Text;
            newAccount.secAnswer2 = secAnswer2.Text;
            newAccount.secAnswer3 = secAnswer3.Text;
            
            Accounts.Accounts proxy = new Accounts.Accounts();
            Boolean result = proxy.AddAccount(newAccount);

            if (result)
            {
                Session["UserType"] = newAccount.accountType;
                Session["Username"] = newAccount.username;
                generateVerification(username_input.Text);
                Server.Transfer("Verification.aspx");
            }
            else
            {
                lblErrors.Text = "Account could not be created, Check back later.";
            }
        }

        public Boolean validateUsername(string username)
        {
            WebRequest request = WebRequest.Create("https://localhost:44361/api/Account/GetUserExists/" + username);
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            Boolean valid = js.Deserialize<Boolean>(data);

            return valid;
        }

        public Boolean validateEmail(string email)
        {
            WebRequest request = WebRequest.Create("https://localhost:44361/api/Account/GetUserExistsEmail/" + email);
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            Boolean valid = js.Deserialize<Boolean>(data);

            return valid;
        }

        public Boolean validatePhone(string phone)
        {
            WebRequest request = WebRequest.Create("https://localhost:44361/api/Account/GetUserExistsPhone/" + phone);
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            Boolean valid = js.Deserialize<Boolean>(data);

            return valid;
        }

        public void generateVerification(string username)
        {

            char[] chArray = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string str = string.Empty;
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                int index = random.Next(1, chArray.Length);
                if (!str.Contains(chArray.GetValue(index).ToString()))
                {
                    str = str + chArray.GetValue(index);
                }
                else
                {
                    i--;
                }
            }

            PetsSOAP.Accounts proxy = new PetsSOAP.Accounts();
            Boolean result = proxy.generateVerification(username, str);

            //SEND EMAIL
        }
    }
}
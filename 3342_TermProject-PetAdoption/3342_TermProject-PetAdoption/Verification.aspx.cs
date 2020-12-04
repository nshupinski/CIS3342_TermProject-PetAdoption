﻿using System;
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
    public partial class Verification : System.Web.UI.Page
    {

        string username;

        protected void Page_Load(object sender, EventArgs e)
        {
           username = Session["Username"].ToString();
        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {

            string entered = verify_input.Text;
            WebRequest request = WebRequest.Create("https://localhost:44361/api/Account/GetVerificationCode/" + username);
            WebResponse response = request.GetResponse();

            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            string code = data;

            if(entered == code)
            {
                PetsSOAP.Accounts proxy = new PetsSOAP.Accounts();
                Boolean result = proxy.updateVerification(username);

                if (result)
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    lblErrors.Text = "Error verifying your account.";
                }
            }
            else
            {
                lblErrors.Text = "Verification code is incorrect. Please check your email again!";
            }
            
        }
    }
}
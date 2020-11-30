﻿using _3342_TermProject_PetAdoption.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
            newAccount.username = username_input.Text;
            newAccount.email = email_input.Text;
            if (userPet.Checked)
            {
                newAccount.accountType = userPet.Value;
            }
            else
            {
                newAccount.accountType = userShelter.Value;
            }
            newAccount.password = password_input.Text;
            newAccount.phoneNum = phone_input.Text;
            newAccount.city = city_input.Text;
            newAccount.state = state_input.SelectedItem.Value;
            newAccount.secAnswer1 = secAnswer1.Text;
            newAccount.secAnswer2 = secAnswer2.Text;
            newAccount.secAnswer3 = secAnswer3.Text;

            // if username/email/phone number is already in use, display this to the user in label and return
            // if passwords don't match, display this to the user in label and return
            // else
            // send this account type to the API to add to the database
            // redirect back to login
        }
    }
}
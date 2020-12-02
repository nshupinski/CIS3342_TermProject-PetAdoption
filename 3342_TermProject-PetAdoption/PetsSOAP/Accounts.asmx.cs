﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using PetAdoptionLibrary;

namespace PetsSOAP
{
    /// <summary>
    /// Summary description for Accounts
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Accounts : System.Web.Services.WebService
    {

        [WebMethod]
        public Boolean AddAccount(Account newAccount)
        {
            if (newAccount != null)
            {
                DBConnect objDB = new DBConnect();
                SqlCommand addAccountCmd = new SqlCommand();

                addAccountCmd.CommandType = CommandType.StoredProcedure;
                addAccountCmd.CommandText = "TP_AddUser";

                addAccountCmd.Parameters.AddWithValue("@username", newAccount.username);
                addAccountCmd.Parameters.AddWithValue("@email", newAccount.email);
                addAccountCmd.Parameters.AddWithValue("@accountType", newAccount.accountType);
                addAccountCmd.Parameters.AddWithValue("@passwords", newAccount.password);
                addAccountCmd.Parameters.AddWithValue("@phoneNum", newAccount.phoneNum);
                addAccountCmd.Parameters.AddWithValue("@city", newAccount.city);
                addAccountCmd.Parameters.AddWithValue("@state", newAccount.state);
                addAccountCmd.Parameters.AddWithValue("@answer1", newAccount.secAnswer1);
                addAccountCmd.Parameters.AddWithValue("@answer2", newAccount.secAnswer2);
                addAccountCmd.Parameters.AddWithValue("@answer3", newAccount.secAnswer3);


                int success = objDB.DoUpdateUsingCmdObj(addAccountCmd);

                if (success > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }

            return false;
        }
    }
}

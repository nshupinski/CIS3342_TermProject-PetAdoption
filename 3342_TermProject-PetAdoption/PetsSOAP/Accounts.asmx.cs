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
                addAccountCmd.Parameters.AddWithValue("@password", newAccount.password);
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

        [WebMethod]
        public Boolean verifyLogin(string username, string password, string accountType)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand loginCmd = new SqlCommand();

            loginCmd.CommandType = CommandType.StoredProcedure;
            loginCmd.CommandText = "TP_ValidateLogin";
            loginCmd.Parameters.AddWithValue("@username", username);
            loginCmd.Parameters.AddWithValue("@password", password);
            loginCmd.Parameters.AddWithValue("@userType", accountType);

            DataSet data = objDB.GetDataSetUsingCmdObj(loginCmd);
            int value = Int32.Parse(data.Tables[0].Rows[0][0].ToString());

            if(value == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        [WebMethod]
        public Boolean generateVerification(string username, string verificationCode)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand verifyCmd = new SqlCommand();

            verifyCmd.CommandType = CommandType.StoredProcedure;
            verifyCmd.CommandText = "TP_GenerateVerification";
            verifyCmd.Parameters.AddWithValue("@username", username);
            verifyCmd.Parameters.AddWithValue("@code", verificationCode);


            int success = objDB.DoUpdateUsingCmdObj(verifyCmd);

            if (success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        
        }

        [WebMethod]
        public Boolean updateVerification(string username)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand updateCmd = new SqlCommand();

            updateCmd.CommandType = CommandType.StoredProcedure;
            updateCmd.CommandText = "TP_UpdateVerified";
            updateCmd.Parameters.AddWithValue("@username", username);

            int success = objDB.DoUpdateUsingCmdObj(updateCmd);

            if (success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public Boolean changePassword(string username, string password)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand changeCmd = new SqlCommand();

            changeCmd.CommandType = CommandType.StoredProcedure;
            changeCmd.CommandText = "TP_ResetPassword";
            changeCmd.Parameters.AddWithValue("@username", username);
            changeCmd.Parameters.AddWithValue("@password", password);

            int success = objDB.DoUpdateUsingCmdObj(changeCmd);

            if (success > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public void updateStatus(string username, int petID, string status)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand updateCmd = new SqlCommand();

            updateCmd.CommandType = CommandType.StoredProcedure;
            updateCmd.CommandText = "TP_UpdateStatus";
            updateCmd.Parameters.AddWithValue("@status", status);
            updateCmd.Parameters.AddWithValue("@userID", username);
            updateCmd.Parameters.AddWithValue("@petID", petID);
            objDB.DoUpdateUsingCmdObj(updateCmd);

        }

        [WebMethod]
        public void deleteRequest(string username, int petID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand updateCmd = new SqlCommand();

            updateCmd.CommandType = CommandType.StoredProcedure;
            updateCmd.CommandText = "TP_DeleteRequest";
            updateCmd.Parameters.AddWithValue("@username", username);
            updateCmd.Parameters.AddWithValue("@petID", petID);
            objDB.DoUpdateUsingCmdObj(updateCmd);

        }
    }

}

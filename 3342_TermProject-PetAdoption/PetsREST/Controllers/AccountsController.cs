﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PetsREST.Controllers
{
    [Route("api/Account")]
    public class AccountsController : Controller
    {

        [HttpGet("GetUserExists/{username}")]
        public Boolean GetUserExists(string username)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand getUserCmd = new SqlCommand();

            getUserCmd.CommandType = CommandType.StoredProcedure;
            getUserCmd.CommandText = "TP_GetUserByUsername";

            getUserCmd.Parameters.AddWithValue("@username", username);

            DataSet data = objDB.GetDataSetUsingCmdObj(getUserCmd);

            if (data.Tables[0].Rows.Count == 0)
                return false;


            return true;

        }

        [HttpGet("GetUserExistsEmail/{email}")]
        public Boolean GetUserExistsEmail(string email)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand getUserCmd = new SqlCommand();

            getUserCmd.CommandType = CommandType.StoredProcedure;
            getUserCmd.CommandText = "TP_GetUserByEmail";

            getUserCmd.Parameters.AddWithValue("@email", email);

            DataSet data = objDB.GetDataSetUsingCmdObj(getUserCmd);

            if (data.Tables[0].Rows.Count == 0)
                return false;


            return true;

        }

        [HttpGet("GetUserExistsPhone/{phone}")]
        public Boolean GetUserExistsPhone(string phone)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand getUserCmd = new SqlCommand();

            getUserCmd.CommandType = CommandType.StoredProcedure;
            getUserCmd.CommandText = "TP_GetUserByPhone";

            getUserCmd.Parameters.AddWithValue("@phone", phone);

            DataSet data = objDB.GetDataSetUsingCmdObj(getUserCmd);

            if (data.Tables[0].Rows.Count == 0)
                return false;


            return true;

        }

        [HttpGet("GetVerificationCode/{username}")]
        public string GetVerificationCode(string username)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand getCodeCmd = new SqlCommand();

            getCodeCmd.CommandType = CommandType.StoredProcedure;
            getCodeCmd.CommandText = "TP_GetVerificationCode";
            getCodeCmd.Parameters.AddWithValue("@username", username);

            DataSet data = objDB.GetDataSetUsingCmdObj(getCodeCmd);
            string code = data.Tables[0].Rows[0][1].ToString();

            return code;
        }

        [HttpGet("GetUserVerified/{username}")]
        public Boolean isUserVerfified(string username)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand isVerifiedCmd = new SqlCommand();

            isVerifiedCmd.CommandType = CommandType.StoredProcedure;
            isVerifiedCmd.CommandText = "TP_GetVerificationCode";
            isVerifiedCmd.Parameters.AddWithValue("@username", username);

            DataSet data = objDB.GetDataSetUsingCmdObj(isVerifiedCmd);
            int value = Int32.Parse(data.Tables[0].Rows[0][2].ToString());

            if (value == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpGet("GetSecurityAnswer/{username}/{num}")]
        public String getSecurityAnswer(string username, int num)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand securityCmd = new SqlCommand();

            securityCmd.CommandType = CommandType.StoredProcedure;
            securityCmd.CommandText = "TP_GetSecurityAnswers";
            securityCmd.Parameters.AddWithValue("@username", username);

            DataSet data = objDB.GetDataSetUsingCmdObj(securityCmd);
            string answer = data.Tables[0].Rows[0][num].ToString();

            return answer;
            
        }

        [HttpGet("GetUser/{username}")]
        public Account GetUser(string username)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand getUserCmd = new SqlCommand();

            getUserCmd.CommandType = CommandType.StoredProcedure;
            getUserCmd.CommandText = "TP_GetUserByUsername";

            getUserCmd.Parameters.AddWithValue("@username", username);

            DataSet data = objDB.GetDataSetUsingCmdObj(getUserCmd);

            Account gotAccount = new Account();
            gotAccount.username = data.Tables[0].Rows[0][1].ToString();
            gotAccount.email = data.Tables[0].Rows[0][2].ToString();
            gotAccount.accountType = data.Tables[0].Rows[0][3].ToString();
            gotAccount.password = data.Tables[0].Rows[0][4].ToString();
            gotAccount.phoneNum = data.Tables[0].Rows[0][5].ToString();
            gotAccount.city = data.Tables[0].Rows[0][6].ToString();
            gotAccount.state = data.Tables[0].Rows[0][7].ToString();

            return gotAccount;
        }
    }
}

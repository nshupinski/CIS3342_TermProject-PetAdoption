using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionLibrary;

using System.Data;              // import needed for DataSet and other data classes
using System.Data.SqlClient;    // import needed for ADO.NET classes
using Utilities;                // import needed for DBConnect class
using WebAPI.Models;
using System.Collections;

namespace WebAPI.Controllers
{

    [Route("Account/[controller]")]
    public class AccountsController : Controller
    {
        //[HttpGet]
        //public Account GetAccount(string username, string password)
        //{

        //}

        [HttpGet]
        public Account GetUser(string username)
        {
            Account user = new Account();
            DBConnect objDB = new DBConnect();
            SqlCommand getUserCmd = new SqlCommand();

            getUserCmd.CommandType = CommandType.StoredProcedure;
            getUserCmd.CommandText = "TP_GetUserByUsername";

            getUserCmd.Parameters.AddWithValue("@username", username);

            DataSet userData = objDB.GetDataSetUsingCmdObj(getUserCmd);

            return user;

        }

        [HttpGet("GetUserExists/{username}")]
        public int GetUserExists(string username)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand getUserCmd = new SqlCommand();

            getUserCmd.CommandType = CommandType.StoredProcedure;
            getUserCmd.CommandText = "TP_GetUserByUsername";

            getUserCmd.Parameters.AddWithValue("@username", username);

            int exists = objDB.DoUpdateUsingCmdObj(getUserCmd);

            return exists;

        }

        [HttpGet]
        public Account GetEmail(string email)
        {
            Account user = new Account();


            return user;
        }

        [HttpGet]
        public Account GetPhone(string phone)
        {
            Account user = new Account();


            return user;
        }
    }
}
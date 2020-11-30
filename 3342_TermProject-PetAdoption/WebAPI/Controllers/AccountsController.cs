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

    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        //[HttpGet]
        //public Account GetAccount(string username, string password)
        //{

        //}

        [HttpPost]
        public Boolean Post([FromBody] Account newAccount)
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

            if(success > 0)
            {
                return true;
            }

            return false;

        }


        
    }
}
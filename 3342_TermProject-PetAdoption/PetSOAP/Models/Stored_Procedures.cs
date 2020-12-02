using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Utilities;

namespace WebAPI.Models
{
    public class Stored_Procedures
    {
        
        public DataSet SP_GetAllPets()
        {
            DataSet myDS;
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "GetAllPets";

            // Execute stored procedure using DBConnect object and the SQLCommand object
            myDS = objDB.GetDataSetUsingCmdObj(objCommand);

            return myDS;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PetAdoptionLibrary;
using Utilities;
using System.Web;
using System.Web.Services;

namespace PetSOAP
{
    [WebService(Namespace = "http://tempuri.org/")]

    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

    [System.ComponentModel.ToolboxItem(false)]

    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.

    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        [WebMethod]
        public Boolean AddAccount(Account newAccount)
        {
            if(newAccount != null)
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


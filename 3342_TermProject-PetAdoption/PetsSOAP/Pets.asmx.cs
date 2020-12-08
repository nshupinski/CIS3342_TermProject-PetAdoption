using PetAdoptionLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PetsSOAP
{
    /// <summary>
    /// Summary description for Pets
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Pets : System.Web.Services.WebService
    {

        [WebMethod]
        public int addPet(Pet newPet)
        {
            DBConnect objDB = new DBConnect();

            if (newPet != null)
            {
                SqlCommand addPetCmd = new SqlCommand();

                addPetCmd.CommandType = CommandType.StoredProcedure;
                addPetCmd.CommandText = "TP_AddPet";

                addPetCmd.Parameters.AddWithValue("@name", newPet.name);
                addPetCmd.Parameters.AddWithValue("@shelterID", newPet.shelterUser);
                addPetCmd.Parameters.AddWithValue("@animal", newPet.animal);
                addPetCmd.Parameters.AddWithValue("@breed", newPet.breed);
                addPetCmd.Parameters.AddWithValue("@goodWithKids", newPet.goodWithKids);
                addPetCmd.Parameters.AddWithValue("@goodWithPets", newPet.goodWithPets);
                addPetCmd.Parameters.AddWithValue("@location", newPet.location);
                addPetCmd.Parameters.AddWithValue("@ageRange", newPet.ageRange);

                DataSet data = objDB.GetDataSetUsingCmdObj(addPetCmd);

                int petID = Int32.Parse(data.Tables[0].Rows[0][0].ToString());

                if (petID < 0)
                {
                    return -1;
                }

                return petID;
            }

            return -1;
        }

        [WebMethod]
        public int likePet(string userID, int petID)
        {
            DBConnect objDB = new DBConnect();

            SqlCommand addPetCmd = new SqlCommand();

            addPetCmd.CommandType = CommandType.StoredProcedure;
            addPetCmd.CommandText = "TP_LikePet";

            addPetCmd.Parameters.AddWithValue("@userID", userID);
            addPetCmd.Parameters.AddWithValue("@petID", petID);

            DataSet data = objDB.GetDataSetUsingCmdObj(addPetCmd);

            return petID;
        }

        [WebMethod]
        public int AddRequest(string userID, int petID)
        {
            DBConnect objDB = new DBConnect();

            SqlCommand addPetCmd = new SqlCommand();

            addPetCmd.CommandType = CommandType.StoredProcedure;
            addPetCmd.CommandText = "TP_AddRequest";

            addPetCmd.Parameters.AddWithValue("@username", userID);
            addPetCmd.Parameters.AddWithValue("@petID", petID);
            addPetCmd.Parameters.AddWithValue("@requestDate", DateTime.Now);

            DataSet data = objDB.GetDataSetUsingCmdObj(addPetCmd);

            return petID;
        }

        [WebMethod]
        public int getMatch(Match search)
        {

            DBConnect objDB = new DBConnect();
            SqlCommand getPetsCmd = new SqlCommand();

            getPetsCmd.CommandType = CommandType.StoredProcedure;
            getPetsCmd.CommandText = "TP_GetAllPets";

            DataSet ds = objDB.GetDataSetUsingCmdObj(getPetsCmd);
            Dictionary<int, double> compatNumbers = new Dictionary<int, double>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                int compatNum = 0;
                Pet newPet = new Pet();
                newPet.name = row["name"].ToString();
                newPet.petID = int.Parse(row["petID"].ToString());
                newPet.shelterUser = row["shelterID"].ToString();
                newPet.animal = row["animal"].ToString();
                newPet.breed = row["breed"].ToString();
                newPet.goodWithKids = int.Parse(row["goodWithKids"].ToString());
                newPet.goodWithPets = int.Parse(row["goodWithPets"].ToString());
                newPet.location = row["location"].ToString();
                newPet.ageRange = row["ageRange"].ToString();
                string state = newPet.location.Substring(newPet.location.Length - 2);

                if (search.animal == newPet.animal)
                {
                    compatNum += 20;
                }

                if(search.ageRange == newPet.ageRange)
                {
                    compatNum += 20;
                }

                if (search.goodWithKids == newPet.goodWithKids)
                {
                    compatNum += 20;
                }


                if (search.goodWithPets == newPet.goodWithPets)
                {
                    compatNum += 20;
                }

                if (search.location == state)
                {
                    compatNum += 20;
                }

                compatNumbers.Add(newPet.petID, compatNum);
            }

            int petMatch = compatNumbers.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;

            return petMatch;
        }
    }
}

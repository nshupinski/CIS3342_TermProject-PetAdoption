using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetAdoptionLibrary;

namespace PetsREST.Controllers
{
    [Route("api/Pet")]
    public class PetsController : Controller
    {
        [HttpGet("GetAllPets")]
        public List<Pet> GetAllPets()
        {
            DBConnect objDB = new DBConnect();
            SqlCommand getPetsCmd = new SqlCommand();

            getPetsCmd.CommandType = CommandType.StoredProcedure;
            getPetsCmd.CommandText = "TP_GetAllPets";

            DataSet ds = objDB.GetDataSetUsingCmdObj(getPetsCmd);

            List<Pet> pets = new List<Pet>();
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                Pet newPet = new Pet();
                newPet.name = row["name"].ToString();
                newPet.userID = row["shelterID"].ToString();
                newPet.animal = row["animal"].ToString();
                newPet.breed = row["breed"].ToString();
                newPet.goodWithKids = int.Parse(row["goodWithKids"].ToString());
                newPet.goodWithPets = int.Parse(row["goodWithPets"].ToString());
                newPet.location = row["location"].ToString();
                newPet.ageRange = row["ageRange"].ToString();

                pets.Add(newPet);
            }
            return pets;
        }
    }
}
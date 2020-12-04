using Microsoft.AspNetCore.Mvc;
using PetAdoptionLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Utilities;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class PetsController
    {
        [HttpGet("AllPets")]
        public List<Pet> GetAllPets()
        {
            Stored_Procedures procedures = new Stored_Procedures();
            DBConnect objDB = new DBConnect();
            DataSet ds = procedures.SP_GetAllPets();

            List<Pet> pets = new List<Pet>();
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                Pet newPet = new Pet();
                newPet.name = row["name"].ToString();
            }

            return pets;
        }
    }
}

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
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //Pet newPet = ds.Tables[0].Rows[i];
                //pets.Add(ds.Tables[0].Rows[i]);
            }

            return pets;
        }
    }
}

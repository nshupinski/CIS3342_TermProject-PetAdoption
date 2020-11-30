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


        [HttpGet("AllPets")]
        public List<Pet> GetAllPets()
        {
            Stored_Procedures procedures = new Stored_Procedures();
            DBConnect objDB = new DBConnect();
            DataSet ds = procedures.SP_GetAllPets();

            List<Pet> pets = new List<Pet>();
            for(int i=0; i<ds.Tables[0].Rows.Count; i++)
            {
                //Pet newPet = ds.Tables[0].Rows[i];
                //pets.Add(ds.Tables[0].Rows[i]);
            }

            return pets;
        } 
    }
}
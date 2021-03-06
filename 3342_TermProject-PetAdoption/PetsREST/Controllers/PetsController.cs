﻿using System;
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
            foreach (DataRow row in ds.Tables[0].Rows)
            {
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

                pets.Add(newPet);
            }
            return pets;
        }

        [HttpGet("GetLikedPets/{username}")]
        public List<Pet> GetLikedPets(string username)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand getPetsCmd = new SqlCommand();

            getPetsCmd.CommandType = CommandType.StoredProcedure;
            getPetsCmd.CommandText = "TP_GetUserLikedPets";
            getPetsCmd.Parameters.AddWithValue("@username", username);

            DataSet ds = objDB.GetDataSetUsingCmdObj(getPetsCmd);

            List<Pet> pets = new List<Pet>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
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

                pets.Add(newPet);
            }
            return pets;
        }

        [HttpGet("GetShelterPets/{username}")]
        public List<Pet> GetShelterPets(string username)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand getPetsCmd = new SqlCommand();

            getPetsCmd.CommandType = CommandType.StoredProcedure;
            getPetsCmd.CommandText = "TP_GetAllShelterPets";
            getPetsCmd.Parameters.AddWithValue("@shelterID", username);

            DataSet ds = objDB.GetDataSetUsingCmdObj(getPetsCmd);

            List<Pet> pets = new List<Pet>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
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

                pets.Add(newPet);
            }
            return pets;
        }

        [HttpGet("GetPetByID/{petID}")]
        public Pet GetPetByID(int petID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand getPetsCmd = new SqlCommand();

            getPetsCmd.CommandType = CommandType.StoredProcedure;
            getPetsCmd.CommandText = "TP_GetPetByID";

            getPetsCmd.Parameters.AddWithValue("@petID", petID);

            DataSet ds = objDB.GetDataSetUsingCmdObj(getPetsCmd);

            Pet newPet = new Pet();
            newPet.name = ds.Tables[0].Rows[0]["name"].ToString();
            newPet.petID = int.Parse(ds.Tables[0].Rows[0]["petID"].ToString());
            newPet.shelterUser = ds.Tables[0].Rows[0]["shelterID"].ToString();
            newPet.animal = ds.Tables[0].Rows[0]["animal"].ToString();
            newPet.breed = ds.Tables[0].Rows[0]["breed"].ToString();
            newPet.goodWithKids = int.Parse(ds.Tables[0].Rows[0]["goodWithKids"].ToString());
            newPet.goodWithPets = int.Parse(ds.Tables[0].Rows[0]["goodWithPets"].ToString());
            newPet.location = ds.Tables[0].Rows[0]["location"].ToString();
            newPet.ageRange = ds.Tables[0].Rows[0]["ageRange"].ToString();

            return newPet;
        }
    }       
}
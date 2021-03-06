﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetAdoptionLibrary;

namespace _3342_TermProject_PetAdoption
{
    public partial class Compatibility : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userType = Session["UserType"].ToString();

            if (userType == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnFindMatch_Click(object sender, EventArgs e)
        {
            Match search = new Match();
            search.animal = ddlAnimal.SelectedItem.Value;
            search.location = state_input.SelectedItem.Value;
            search.ageRange = age_input.SelectedItem.Value;

            if (checkGoodWithKids.Checked)
            {
                search.goodWithKids = 1;
            }
            else
            {
                search.goodWithKids = 0;
            }

            if (checkGoodWithPets.Checked)
            {
                search.goodWithPets = 1;
            }

            PetsSOAP.Pets proxy = new PetsSOAP.Pets();
            int petID = proxy.getMatch(search);

            Session.Add("selectedPet", petID);
            Response.Redirect("Pet_Page.aspx");

        }
    }
}
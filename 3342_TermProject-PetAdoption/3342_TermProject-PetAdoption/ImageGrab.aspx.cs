﻿using PetAdoptionLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3342_TermProject_PetAdoption
{
    public partial class ImageGrab : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBConnect objDB = new DBConnect();

            DataSet ds;

            string strSQL;



            if (Request.QueryString["ID"] != null)

            {

                // Get the image from the Image table using GET parameter supplied through the URL

                strSQL = "SELECT ImageData FROM TP_PetPhotos Where petID = " + Request.QueryString["ID"];

                ds = objDB.GetDataSet(strSQL);



                byte[] imageData;

                imageData = (byte[])objDB.GetField("ImageData", 0);



                // Write the binary image data in the Response for the browser to display

                Response.Clear();

                Response.OutputStream.Write(imageData, 0, imageData.Length);

                //Response.BinaryWrite(imageData);

                Response.End();
            }
        }
    }
}
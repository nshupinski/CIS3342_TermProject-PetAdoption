using PetAdoptionLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _3342_TermProject_PetAdoption
{
    public partial class AddPet : System.Web.UI.Page
    {
        string username;

        protected void Page_Load(object sender, EventArgs e)
        {
            username = Session["Username"].ToString();
        }

        protected void btnSubmit_addPet_Click(object sender, EventArgs e)
        {
            PetsSOAP.Pet newPet = new PetsSOAP.Pet();
            newPet.name = name_input.Text;
            newPet.shelterUser = username;
            newPet.animal = ddlAnimal.SelectedValue;
            newPet.breed = breed_input.Text;
            if (checkGoodWithKids.Checked)
            {
                newPet.goodWithKids = 1;
            }
            else
            {
                newPet.goodWithKids = 0;
            }

            if (checkGoodWithPets.Checked)
            {
                newPet.goodWithPets = 1;
            }
            else
            {
                newPet.goodWithPets = 0;
            }

            if(state_input.SelectedItem.Value == "")
            {
                lblErrors.Text = "Please select a state.";
            }
            else
            {
                newPet.location = city_input.Text + ", " + state_input.SelectedItem.Value;
            }
            

            if (age_input.SelectedItem.Value == "")
            {
                lblErrors.Text = "Please select a valid age range.";
            }
            else
            {
                newPet.ageRange = age_input.SelectedItem.Value;
            }

            PetsSOAP.Pets proxy = new PetsSOAP.Pets();
            int petID = proxy.addPet(newPet);
            uploadPhotoToDatabase(petID);
        }

        public void uploadPhotoToDatabase(int petID)
        {
            DBConnect objDB = new DBConnect();

            SqlCommand objCommand = new SqlCommand();

            int result = 0, imageSize;

            string fileExtension, imageType, imageName;

            try
            {
                // Use the FileUpload control to get the uploaded data

                if (photo_upload.HasFile)
                {
                    imageSize = photo_upload.PostedFile.ContentLength;
                    byte[] imageData = new byte[imageSize];
                    photo_upload.PostedFile.InputStream.Read(imageData, 0, imageSize);
                    imageName = photo_upload.PostedFile.FileName;
                    imageType = photo_upload.PostedFile.ContentType;


                    fileExtension = imageName.Substring(imageName.LastIndexOf("."));
                    fileExtension = fileExtension.ToLower();

                    if (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".bmp" || fileExtension == ".gif")
                    {
                        // INSERT an image (BLOB) into the database using a stored procedure 'storeProductImage'

                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.CommandText = "TP_StorePetPhoto";

                        objCommand.Parameters.AddWithValue("@ImageTitle", "pet" + petID + "img");

                        objCommand.Parameters.AddWithValue("@ImageData", imageData);

                        objCommand.Parameters.AddWithValue("@ImageType", imageType);

                        objCommand.Parameters.AddWithValue("@ImageLength", imageData.Length);

                        objCommand.Parameters.AddWithValue("@PetID", petID);

                        result = objDB.DoUpdateUsingCmdObj(objCommand);

                        // TRANSFER TO THE PET PAGE FOR THE ONE YOU JUST MADE
                    }
                    else
                    {

                        lblErrors.Text = "Only jpg, bmp, and gif file formats supported.";

                    }

                }

            }

            catch (Exception ex)
            {

                lblErrors.Text = "Error ocurred: [" + ex.Message + "] cmd=" + result;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetAdoptionLibrary
{
    public class PetPicture
    {
        public int petID { get; set; }
        public string ImageData { get; set; }
        public string ImageType { get; set; }
        public int ImageLength { get; set; }
        public string ImageTitle { get; set; }

        public PetPicture()
        {
        }
    }
}

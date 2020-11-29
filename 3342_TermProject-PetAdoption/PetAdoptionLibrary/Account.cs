using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3342_TermProject_PetAdoption.Models
{
    public class Account
    {
        public int userID { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string accountType { get; set; }
        public string password { get; set; }
        public string phoneNum { get; set; }
        public string city { get; set; }
        public string state { get; set; }
    }
}
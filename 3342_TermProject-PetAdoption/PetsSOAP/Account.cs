using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsSOAP
{
    public class Account
    {
        public string username { get; set; }
        public string email { get; set; }
        public string accountType { get; set; }
        public string password { get; set; }
        public string phoneNum { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string secAnswer1 { get; set; }
        public string secAnswer2 { get; set; }
        public string secAnswer3 { get; set; }


        public Account()
        {

        }
    }
}
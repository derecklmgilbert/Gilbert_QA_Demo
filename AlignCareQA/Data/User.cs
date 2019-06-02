using System;
using System.Collections.Generic;
using System.Text;

namespace AlignCareQA.Data
{
    class User
    {
        public string username;
        public string password;
        public string confirmpassword;
        public string role;
        public string firstname;
        public string lastname;
        public string daysindormancy;
        public string daysinexpiration;

        public bool active;
        public bool dormant;
        public bool expired;
    }
}

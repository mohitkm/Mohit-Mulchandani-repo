                        /* Conceptualized and created by Dhrumil Kishor Panchal & Mohit Kishor Mulchandani */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DatabaseConnectivity;

namespace BackendLogic
{
    public class UserDetail
    {
        public int UserDetailID;
        public String Name;
        public String Email;
        public String Mobile;
        public String Address;
        public String Password;
        public bool IsActive;
        public String Photo;
        public String UserType;
    }
}

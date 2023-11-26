using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Final_MIS
{

    public class Connection
    {
        public static string GetConnectionString()
        {
            string connectionString = "Data Source=OTNGLMQUYNA702C;Initial Catalog=STUFOOD_DB;Integrated Security=True;Encrypt=False";

            return connectionString;
        }
    }
}
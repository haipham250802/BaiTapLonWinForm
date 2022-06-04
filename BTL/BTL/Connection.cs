using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BTL
{
    internal class Connection
    {
        static string chuoiketnoi = "Data Source = DESKTOP-I3B80O6\\SQLEXPRESS; Initial Catalog = QLCHTH; Integrated Security = true";
        public static SqlConnection Getconnect()
        {
            return new SqlConnection(chuoiketnoi);
        }
    }

}

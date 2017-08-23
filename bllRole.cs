using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class bllRole
    {
        public List<Role> GetAll()
        {
            using(SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
            {
                List<Role> lstRole = new List<Role>();
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM UserRole",cnn);
                cnn.Open();
                using(SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while(rdr.Read())
                    {
                        lstRole.Add(new Role()
                        {
                            Id = rdr.GetInt32(0),
                            UserType = rdr.GetString(1)
                        });
                    }
                }
                return lstRole;
            }
        }
    }
}

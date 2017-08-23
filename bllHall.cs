using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class bllHall
    {
        public List<Hall> getAll()
        {
            List<Hall> lstHall = new List<Hall>();
            using(SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM Halls",cnn);
                cnn.Open();
                using(SqlDataReader rdr =cmd.ExecuteReader())
                {
                    while(rdr.Read())
                    {
                        lstHall.Add(new Hall()
                            {
                                Id = rdr.GetInt32(0),
                                HallName = rdr.GetString(1)
                            });
                    }
                }
                return lstHall;
            }
        }
    }
}

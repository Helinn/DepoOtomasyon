using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class bllStatus
    {
        public List<Entities.Status> GetAll()
        {
            using (SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
            {
                List<Entities.Status> lstStatus = new List<Entities.Status>();
                SqlCommand cmd = new SqlCommand(@"SELECT StatusID, StatusType FROM Status", cnn);
                cnn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        lstStatus.Add(new Entities.Status()
                            {
                                Id = rdr.GetInt32(0),
                                StatusType = rdr.GetString(1)
                            });
                    }
                }
                return lstStatus;
            }
        }
    }
}

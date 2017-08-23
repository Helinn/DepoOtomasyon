using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class bllOperations
    {
        public List<Operations> GetAll()
        {
            using (SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
            {
                List<Operations> lstOperations = new List<Operations>();
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM Operations", cnn);
                cnn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        lstOperations.Add(new Operations()
                        {
                            Id = rdr.GetInt32(0),
                            OperationType = rdr.GetString(1)
                        });
                    }
                }
                return lstOperations;
            }
        }
    }
}

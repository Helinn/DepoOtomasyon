using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Data
{
    public class bllCategories
    {
        public List<Entities.Category> GetAll()
        {
            using(SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
            {
                List<Entities.Category> lstCategories = new List<Entities.Category>();
                SqlCommand cmd = new SqlCommand(@"SELECT CategoryID, CategoryType FROM Categories",cnn);
                cnn.Open();
                using(SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        lstCategories.Add(new Entities.Category()
                                            {
                                                Id = rdr.GetInt32(0),
                                                CategoryName = rdr.GetString(1)
                                            });
                    }
                }
                return lstCategories;
            }    
        }
    }
}

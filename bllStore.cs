using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class bllStore
    {
        public List<Store> getAll()
        {
            List<Store> lstStore = new List<Store>();
            using(SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
            {
                SqlCommand cmd =new SqlCommand(@"SELECT * FROM Stores",cnn);
                cnn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        lstStore.Add(new Store()
                        {
                            Id = rdr.GetInt32(0),
                            StoreType = rdr.GetString(1),
                        });
                    } 
                }
                return lstStore;
            }
        }
    }
}

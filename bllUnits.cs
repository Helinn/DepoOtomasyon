using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class bllUnits
    {
        public List<Entities.Unit> GetAll()
        {
            using (SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
            {
                List<Entities.Unit> lstUnit = new List<Entities.Unit>();
                SqlCommand cmd = new SqlCommand(@"SELECT UnitID,UnitType FROM Units",cnn);
                cnn.Open();
                using(SqlDataReader rdr = cmd.ExecuteReader())
                {
                   while(rdr.Read())
                   {
                       lstUnit.Add(new Entities.Unit()
                       {
                           Id = rdr.GetInt32(0),
                           UnitType = rdr.GetString(1)
                       });
                   }
                }
                return lstUnit;
            }
        }
    }
}

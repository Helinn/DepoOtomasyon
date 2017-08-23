using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class bllDepartment
    {
        public List<Entities.Departments> GetAll()
        {
            using (SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
            {
                List<Entities.Departments> lstDep = new List<Entities.Departments>();
                SqlCommand depCmd = new SqlCommand(@"SELECT ID, DepartmentName FROM Departments", cnn);
                cnn.Open();
                using (SqlDataReader rdr = depCmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        lstDep.Add(new Entities.Departments()
                        {
                            Id = rdr.GetInt32(0),
                            DepartmentName = rdr.GetString(1)
                        });
                    }
                }

                return lstDep;
            }
        }

    }
}

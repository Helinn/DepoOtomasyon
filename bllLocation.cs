using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Data
{
    public class bllLocation
    {
        public List<Entities.Location> GetAll()
        {
            List<Entities.Location> lstLocation = new List<Entities.Location>();
            using(SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT Locations.LocationId, Halls.HallID, Stores.StoreID,
                                                 Locations.colon, Locations.shelf,Halls.HallName,Stores.StoreType FROM Halls INNER JOIN
                                                 Locations ON Halls.HallID = Locations.HallID INNER JOIN
                                                 Stores ON Locations.StoreID = Stores.StoreID", cnn);
                cnn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while(rdr.Read())
                    {
                        lstLocation.Add(new Entities.Location()
                                        {
                                            Id = rdr.GetInt32(0),
                                            HallID = rdr.GetInt32(1),
                                            StoreID = rdr.GetInt32(2), 
                                            Column = rdr.GetInt32(3),
                                            Shelf = rdr.GetInt32(4),
                                            HallType = rdr.GetString(5),
                                            StoreType = rdr.GetString(6),
                                        });
                    }
                }
                return lstLocation;
            }
        }
    }
}

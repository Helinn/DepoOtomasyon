using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class bllStock
    {
        public List<Entities.Stock> GetAll()
        {

            using (SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
            {
                List<Entities.Stock> lstStock = new List<Entities.Stock>();
                SqlCommand cmd = new SqlCommand(@"SELECT Stocks.StockId, Products.ProductName, Products.ProductCode, Units.UnitType,
                                                  Stocks.Amount, Stocks.RegistrationDate, Stocks.ExpirationDate, Status.StatusType, 
                                                  Stores.StoreType, Halls.HallName, Locations.colon, Locations.shelf
                                                  FROM Stocks INNER JOIN Halls INNER JOIN Locations ON Halls.HallID = Locations.HallID 
                                                  ON Stocks.LocationID = Locations.LocationId INNER JOIN Stores ON Locations.StoreID = Stores.StoreID
                                                  INNER JOIN Status ON Status.StatusID = Stocks.StockStatusID INNER JOIN 
                                                  Products ON Products.ProductID = Stocks.ProductID INNER JOIN Units ON 
                                                  Products.UnitID = Units.UnitID", cnn);
                cnn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        lstStock.Add(new Entities.Stock()
                        {
                            Id = rdr.GetInt32(0),
                            ProductName = rdr.GetString(1),
                            ProductCode = rdr.GetString(2),
                            UnitType = rdr.GetString(3),
                            Amount = rdr.GetInt32(4),
                            RegistrationDate = rdr.GetDateTime(5),
                            ExpirationDate = rdr.GetDateTime(6),
                            StockStatuType = rdr.GetString(7),
                            Location = rdr.GetString(8) + " " + rdr.GetString(9) + "-" + rdr.GetInt32(10) + "-" + rdr.GetInt32(11)
                            //depo-koridor-kolon-kat     
                        });
                    }
                }
                return lstStock;
            }
        }
        public bool Order(int Id, int newAmount)
        {
            using (SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
            {
                SqlCommand cmd = new SqlCommand(@"Update Stocks Set Amount = Amount-@amount Where StockID=@prmID", cnn);
                cmd.Parameters.Add(new SqlParameter("@prmID", System.Data.SqlDbType.Int) { Value = Id });
                cmd.Parameters.AddWithValue("@amount", newAmount);
                cnn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool Purchase(int Id, int newamount)
        {

            using (SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
            {
                SqlCommand cmd = new SqlCommand(@"Update Stocks Set Amount = Amount+@amount Where StockID=@prmID", cnn);
                cmd.Parameters.Add(new SqlParameter("@prmID", System.Data.SqlDbType.Int) { Value = Id });
                cmd.Parameters.AddWithValue("@amount", newamount);
                cnn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool Insert(int PId, int newAmount, DateTime reg, DateTime exp, int locId, int statusId)
        {
            using (SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO Stocks (ProductID, Amount,
                                                  ExpirationDate,RegistrationDate,LocationID,StockStatusID) VALUES(@Pid,@amount,@expdate,@regdate,@locId,@statusId)", cnn);
                cnn.Open();
                cmd.Parameters.AddWithValue("@Pid", PId);
                cmd.Parameters.AddWithValue("@amount", newAmount);
                cmd.Parameters.AddWithValue("@expdate", exp);
                cmd.Parameters.AddWithValue("@regdate", reg);
                cmd.Parameters.AddWithValue("@locId", locId);
                cmd.Parameters.AddWithValue("@statusId", statusId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public int GetLocationID(string storeId, string hallId, string colon, string shelf)
        {
            int LocationID = -1;
            using (SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT Locations.LocationId FROM Halls INNER JOIN
                         Locations ON Halls.HallID = Locations.HallID INNER JOIN
                         Stores ON Locations.StoreID = Stores.StoreID Where Locations.StoreID=@storeid AND 
                         Locations.HallID = @hallid AND Locations.colon = @cln AND Locations.shelf = @shelf", cnn);
                cmd.Parameters.AddWithValue("@storeid", int.Parse(storeId));
                cmd.Parameters.AddWithValue("@hallid", int.Parse(hallId));
                cmd.Parameters.AddWithValue("@cln", int.Parse(colon));
                cmd.Parameters.AddWithValue("@shelf", int.Parse(shelf));
                cnn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        LocationID = rdr.GetInt32(0);
                    }
                    return LocationID;
                }
            }
        }
        /*
         * @param LocationID Lokasyon belirtir.
         * lokasyonda aynı tip üründen varsa true yani yerlesebilir,
         * ayni tip urun degilse false yani yerlesemez.
         * **/
        public bool LocationControl(int LocationID, int ProductID)
        {
            int PID = -1;
            using (SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT Stocks.ProductID FROM Locations INNER JOIN
                         Stocks ON Locations.LocationId = Stocks.LocationID Where Stocks.LocationID = @LocId", cnn);
                cmd.Parameters.AddWithValue("@LocId", LocationID);
                cnn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        PID = rdr.GetInt32(0);
                    }
                }
            }

            if (PID == ProductID || PID == -1)
                return true;
            else return false;
        }
        public bool SearchInStock(int pID)
        {
            int PID = -1;
            using (SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT Stocks.ProductID FROM Stocks INNER JOIN Products
                                                ON Stocks.ProductID=Products.ProductID where Stocks.ProductID =@pid", cnn);
                cmd.Parameters.AddWithValue("@pid", pID);
                cnn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        PID = rdr.GetInt32(0);
                        if (PID != -1)
                            return true;
                    }
                }
            }
            return false;
        }

    }//class end
}//namespace
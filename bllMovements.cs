using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Data.Entities;

namespace Data
{
    public class bllMovements
    {
        public List<Movements> GetAll()
        {
            List<Movements> lstMovement = new List<Movements>();
            using(SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT Movements.MoveID, Stocks.StockID, Products.ProductName,
                                                Products.ProductCode,Movements.DateOfMovement, Movements.MoveTypeID,Movements.Amount,UsersTable.ID,
                                                UsersTable.Name, UsersTable.Surname,Units.UnitType FROM Stocks INNER JOIN
                                                Products ON Stocks.ProductID = Products.ProductID INNER JOIN
                                                Movements ON Stocks.StockId = Movements.StockID INNER JOIN UsersTable ON UsersTable.Id = Movements.UserID INNER JOIN Units On Units.UnitID=Products.UnitID", cnn);
                cnn.Open();
                using(SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while(rdr.Read())
                    
                        lstMovement.Add(new Movements()
                        {
                             Id = rdr.GetInt32(0),
                             StockID = rdr.GetInt32(1),
                             ProductName= rdr.GetString(2),
                             ProductCode= rdr.GetString(3),
                             DateOfMovement = rdr.GetDateTime(4),
                             MoveType= rdr.GetInt32(5),
                             Amount = rdr.GetInt32(6),
                             UserID = rdr.GetInt32(7),
                             UserName = rdr.GetString(8)+" "+rdr.GetString(9),
                             UnitType = rdr.GetString(10)
                        });
                    }
                }
             return lstMovement;
         }
        public bool Insert(int StockID, DateTime dt, int MoveType,int newAmount,int User)
        {
            using (SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO Movements (StockID, MoveTypeID, DateOfMovement,Amount,UserID) Values(@stockid,@movetype,@date,@amount,@user)", cnn);
                cnn.Open();
                cmd.Parameters.AddWithValue("@stockid", StockID);
                cmd.Parameters.AddWithValue("@movetype", MoveType);
                cmd.Parameters.AddWithValue("@date", dt);
                cmd.Parameters.AddWithValue("@amount", newAmount);
                cmd.Parameters.AddWithValue("@user", User);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class bllProducts
    {
       public List<Products> GetAllProducts()
        {
            List<Products> lstProducts = new List<Products>();
           using(SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
           {
               SqlCommand cmd = new SqlCommand(@"SELECT Products.ProductID, Products.ProductName, Products.ProductCode,
                                                 Units.UnitID, Products.Title, Products.SerialNum, Products.Comment, 
                                                 Status.StatusID, Categories.CategoryID, Units.UnitType,Status.StatusType,Categories.CategoryType FROM Categories INNER JOIN
                                                 Products ON Categories.CategoryID = Products.CategoryID INNER JOIN
                                                 Status ON Products.StatusId = Status.StatusID INNER JOIN
                                                 Units ON Products.UnitID = Units.UnitID", cnn);
               cnn.Open();
               using (SqlDataReader rdr = cmd.ExecuteReader())
               {
                   while (rdr.Read())
                   {
                       lstProducts.Add(new Products
                       {
                           Id = rdr.GetInt32(0),
                           ProductName = rdr.GetString(1),
                           ProductCode = rdr.GetString(2),
                           UnitID = rdr.GetInt32(3),
                           Title = rdr.GetString(4),
                           SerialNum = rdr.GetInt32(5),
                           Comment = rdr.IsDBNull(6) ? null : rdr.GetString(6),
                           StatusID = rdr.GetInt32(7),
                           ProductCategoryID = rdr.GetInt32(8),
                           UnitType = rdr.GetString(9),
                           StatusType = rdr.GetString(10),
                           CategoryType = rdr.GetString(11)
                       });    
                   }
               }
           }
           return lstProducts;
        }
        public bool Insert(Products newProduct)
        {
              using(SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
              {
                  SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[Products] ([ProductName],[ProductCode],[UnitID],
                                                    [Title],[SerialNum],
                                                    [Comment],[StatusID],[CategoryID]) VALUES(@pname,@pcode,@unitId,@title,@seriNo
                                                    ,@comm,@statusId,@categoryId)", cnn);
                  cnn.Open();
                  cmd.Parameters.AddWithValue("@pname", newProduct.ProductName);
                  cmd.Parameters.AddWithValue("@pcode", newProduct.ProductCode);
                  cmd.Parameters.AddWithValue("@unitId", newProduct.UnitID);
                  cmd.Parameters.AddWithValue("@title", newProduct.Title);
                  cmd.Parameters.AddWithValue("@seriNo", newProduct.SerialNum);
                  cmd.Parameters.AddWithValue("@comm", newProduct.Comment);
                  cmd.Parameters.AddWithValue("@statusId", newProduct.StatusID);
                  cmd.Parameters.AddWithValue("@categoryId", newProduct.ProductCategoryID);
                  return cmd.ExecuteNonQuery() > 0;
              }
        }
        public bool Update(Products newProduct)
        {
            using (SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
            {
                SqlCommand cmd = new SqlCommand(@"UPDATE Products Set ProductName=@pname, Comment=@comm where ProductID=@pid",cnn);
                cnn.Open();
                cmd.Parameters.AddWithValue("@pname", newProduct.ProductName);
                cmd.Parameters.AddWithValue("@comm", newProduct.Comment);
                cmd.Parameters.AddWithValue("@pid", newProduct.Id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool Delete(int Id)
        {
            using (SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
            {
                SqlCommand cmd = new SqlCommand(@"DELETE FROM [dbo].[Products] Where ProductID = @prmID", cnn);
                cmd.Parameters.Add(new SqlParameter("@prmID", System.Data.SqlDbType.Int) { Value = Id });

                cnn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }   
         public bool PCodeContains(Products product)
        {
            using (SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT Products.ProductCode, Products.SerialNum FROM
                                                  Products
                                                  Where Products.ProductCode = @pcode or Products.SerialNum=@serino", cnn);

                SqlParameter[] sqlParams = new SqlParameter[]  { 
                new SqlParameter("@pcode", System.Data.SqlDbType.VarChar, 50){Value=product.ProductCode},
                new SqlParameter("@serino",System.Data.SqlDbType.Int,sizeof(int)){Value=product.SerialNum}
                };
                cmd.Parameters.AddRange(sqlParams);
                cnn.Open();
                //int serino;
                //string pcode;
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                   /* while (rdr.Read())
                    {
                        pcode=rdr.GetString(0);
                        serino=rdr.GetInt32(1);
                        if ((pcode.Equals(product.ProductCode) && serino.Equals(product.SerialNum)) || ((pcode.Equals(product.ProductCode) ||
                            serino.Equals(product.SerialNum))))
                            return true;
                        else 
                            return false;*/
                    if(rdr.Read())
                        return true;
                    else return false;
                    //}
                }
                //return false;
            }
        }

    }//class end
}//namespace end

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class bllAuthentication
    {
        public UserTable Authenticate(string userName, string userPass)
        {
            using (SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT UsersTable.ID, Departments.ID, UsersTable.name, 
                                                  UsersTable.surname, UsersTable.username, UsersTable.password,
                                                  UsersTable.email, UsersTable.phoneNumber, UsersTable.comment, UserRole.UserType,
                                                  Departments.DepartmentName FROM Departments INNER JOIN
                                                  UsersTable ON Departments.ID = UsersTable.DepartmentID INNER JOIN UserRole ON UserRole.RoleID = UsersTable.RoleID
                                                  Where UsersTable.password = @pass and UsersTable.username = @uname", cnn);
                                                //guvenlik için username ve password ü parametreye bağlayarak aldım.
                SqlParameter[] sqlParams = new SqlParameter[] { 
                new SqlParameter("@pass", System.Data.SqlDbType.NVarChar, 50){Value=userPass},
                new SqlParameter("@uname", System.Data.SqlDbType.VarChar, 50){Value=userName}
                };
                cmd.Parameters.AddRange(sqlParams);
                cnn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                        return new UserTable()
                        {
                            Id = rdr.GetInt32(0),
                            DepartmentId = rdr.GetInt32(1),
                            Name = rdr.GetString(2),
                            Surname = rdr.GetString(3),
                            Username = rdr.GetString(4),
                            Password = rdr.GetString(5),
                            Email = rdr.IsDBNull(6) ? null : rdr.GetString(6),
                            PhoneNumber = rdr.IsDBNull(7) ? null : rdr.GetString(7),
                            Comment = rdr.IsDBNull(8) ? null : rdr.GetString(8),
                            Role = rdr.GetString(9),
                            Department = rdr.GetString(10),
                            IsAuthenticated = true
                        };
                    rdr.Close();
                }
                cnn.Close();
            }
            return null;
        }

        public List<UserTable> GetAllUsers()
        {
            List<UserTable> lst = new List<UserTable>();
            using (SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT UsersTable.ID, Departments.ID, UsersTable.name, 
                                                  UsersTable.surname, UsersTable.username, UsersTable.password,
                                                  UsersTable.email, UsersTable.phoneNumber, UsersTable.comment, 
                                                  UserRole.UserType,Departments.DepartmentName FROM Departments INNER JOIN UsersTable ON 
                                                  Departments.ID = UsersTable.DepartmentID INNER JOIN UserRole ON 
                                                  UserRole.RoleID = UsersTable.RoleID", cnn);
                cnn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        lst.Add(new UserTable()
                        {
                            Id = rdr.GetInt32(0),
                            DepartmentId = rdr.GetInt32(1),
                            Name = rdr.GetString(2),
                            Surname = rdr.GetString(3),
                            Username = rdr.GetString(4),
                            Password = rdr.GetString(5),
                            Email = rdr.IsDBNull(6) ? "" : rdr.GetString(6),
                            PhoneNumber = rdr.IsDBNull(7) ? "" : rdr.GetString(7),
                            Comment = rdr.IsDBNull(8) ? "" : rdr.GetString(8),
                            Role = rdr.GetString(9),
                            Department = rdr.GetString(10),
                            IsAuthenticated = true
                        });
                    }
                }
            }
            
            return lst;
        }

        public bool Delete(int Id)
        {
            using (SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
            {
                SqlCommand cmd = new SqlCommand(@"DELETE FROM [dbo].[UsersTable] Where ID = @prmID", cnn);
                cmd.Parameters.Add(new SqlParameter("@prmID", System.Data.SqlDbType.Int) { Value = Id });

                cnn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Insert(UserTable person)
        {
            using (SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
            {

                SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[UsersTable] ([DepartmentID], [name], [surname], [username],[password]
                                                , [email], [phoneNumber], [comment],[RoleID]) VALUES(@dep,@name,@sname,@uname,@pass,@email,@pnum,@comm,@role)", cnn);

                cnn.Open();
                cmd.Parameters.AddWithValue("@dep", person.DepartmentId);
                cmd.Parameters.AddWithValue("@name", person.Name);
                cmd.Parameters.AddWithValue("@sname", person.Surname);
                cmd.Parameters.AddWithValue("@uname",person.Username);
                cmd.Parameters.AddWithValue("@pass", person.Password);
                cmd.Parameters.AddWithValue("@email",person.Email);
                cmd.Parameters.AddWithValue("@pnum", person.PhoneNumber);
                cmd.Parameters.AddWithValue("@comm", person.Comment);
                cmd.Parameters.AddWithValue("@role", person.RoleID);
                 return cmd.ExecuteNonQuery() > 0;
            
            }
            
        }
        public bool UNameContains(UserTable person)
        {
            using (SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
            {
                SqlCommand cmd = new SqlCommand(@"SELECT UsersTable.username FROM
                                                  UsersTable
                                                  Where UsersTable.username = @uname", cnn);
                                                
                SqlParameter[] sqlParams = new SqlParameter[]  { 
                new SqlParameter("@uname", System.Data.SqlDbType.VarChar, 50){Value=person.Username}
                };
                cmd.Parameters.AddRange(sqlParams);
                cnn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                        return true;
                    return false;
                }
            }
        }
        public bool Update(UserTable person)
        {
            using (SqlConnection cnn = new SqlConnection(StaticValues.CnnString))
            {
                SqlCommand cmd = new SqlCommand(@"UPDATE UsersTable SET username=@uname,name=@name,surname=@surname,
                                                  email=@email, phoneNumber=@phone,comment=@comm 
                                                  Where ID = @uID", cnn);
                cnn.Open();
                cmd.Parameters.AddWithValue("@uID", person.Id);
                cmd.Parameters.AddWithValue("@uname", person.Username);
                cmd.Parameters.AddWithValue("@name", person.Name);
                cmd.Parameters.AddWithValue("@surname", person.Surname);
                cmd.Parameters.AddWithValue("@email", person.Email);
                cmd.Parameters.AddWithValue("@phone", person.PhoneNumber);
                cmd.Parameters.AddWithValue("@comm", person.Comment);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}

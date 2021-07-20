using CommonLayer;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["BookstoreConnectionString"].ConnectionString;
        //static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookstoreDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection connection = new SqlConnection(connectionString);
        public bool Authenticate(LoginModel model)
        {
            try
            {
                using (connection)
                {
                    string query = $"SELECT * FROM Users WHERE Email = '{model.Email}' and Password = '{model.Password}'";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                   
                    while(reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            string fullname = reader.GetString(1);
                            string email = reader.GetString(2);
                            string mobile = reader.GetString(4);
                            return true;

                        }
                        else
                        {
                            return false;
                        }
                    }
                                              
                }
                return false;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool Register(RegisterModel model)
        {
            try
            {
                //if (model != null)                           
                using (connection)
                {
                    string query = $"insert into Users (FullName, Email, Password, Mobile) values ('{model.FullName}','{model.Email}','{model.Password}','{model.Mobile}')";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    var result = cmd.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    else return false;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}

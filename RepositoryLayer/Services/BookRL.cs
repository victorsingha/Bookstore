using CommonLayer;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class BookRL : IBookRL
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["BookstoreConnectionString"].ConnectionString;
        //static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookstoreDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection connection = new SqlConnection(connectionString);

        public List<BookModel> CartBooksByUserId(int userid)
        {
            List<BookModel> list = new List<BookModel>();

            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("CartBooksByUserId", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = userid;
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            BookModel book = new BookModel();
                            book.BookId = reader.GetInt32(0);
                            book.Title = reader.GetString(1);
                            book.Author = reader.GetString(2);
                            book.ImageUrl = reader.GetString(3);
                            book.Description = reader.GetString(4);
                            book.Rating = reader.GetString(5);
                            book.ReviewCount = reader.GetInt32(6);
                            book.Price = reader.GetInt32(7);
                            book.Discount = reader.GetInt32(8);
                            book.InStock = reader.GetString(9);

                            list.Add(book);
                        }
                    }
                    return list;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<BookModel> GetBookList()
        {
            List<BookModel> list = new List<BookModel>();
            
            try
            {
                using (connection)
                {
                    //string query = $"select * from Books";
                    //SqlCommand cmd = new SqlCommand(query, connection);
                    SqlCommand cmd = new SqlCommand("GetAllBookList", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            BookModel book = new BookModel();
                            book.BookId = reader.GetInt32(0);
                            book.Title = reader.GetString(1);
                            book.Author = reader.GetString(2);
                            book.ImageUrl = reader.GetString(3);
                            book.Description = reader.GetString(4);
                            book.Rating = reader.GetString(5);
                            book.ReviewCount = reader.GetInt32(6);
                            book.Price = reader.GetInt32(7);
                            book.Discount = reader.GetInt32(8);
                            book.InStock = reader.GetString(9);
                                                      
                            list.Add(book);
                        }                    
                    }
                    return list;
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}

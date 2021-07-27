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

        public bool AddToCart(int UserId, int BookId)
        {
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("AddToCart", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = UserId;
                    cmd.Parameters.Add("@BookId", SqlDbType.VarChar).Value = BookId;
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
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool AddToWishlist(int UserId, int BookId)
        {
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("AddToWishlist", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = UserId;
                    cmd.Parameters.Add("@BookId", SqlDbType.VarChar).Value = BookId;
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
            catch (Exception e)
            {
                throw e;
            }
        }

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
                    connection.Close();
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

        public List<Order> GetOrdersByUserId(int UserId)
        {
            List<Order> list = new List<Order>();

            try
            {
                using (connection)
                {
     
                    SqlCommand cmd = new SqlCommand("GetOrdersByUserId", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = UserId;
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            Order order = new Order();
                            order.OrderId = (Int32)reader["OrderId"];
                            order.FullName = (string)reader["FullName"];
                            order.Mobile = (string)reader["Mobile"];
                            order.Address = (string)reader["Address"];
                            order.City = (string)reader["City"];
                            order.State = (string)reader["State"];
                            order.UserId = (Int32)reader["UserId"];
                            order.BookId = (Int32)reader["BookId"];
                            order.Title = (string)reader["Title"];
                            order.Author = (string)reader["Author"];
                            order.ImageUrl = (string)reader["ImageUrl"];
                            order.Description = (string)reader["Description"];
                            order.Rating = (string)reader["Rating"];
                            order.ReviewCount = (Int32)reader["ReviewCount"];
                            order.Price = (Int32)reader["Price"];
                            order.Discount = (Int32)reader["Discount"];
                            order.InStock = (string)reader["InStock"];

                            list.Add(order);
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

        public bool PlaceOrder(Cart cart,int UserId)
        {
            try
            {          
                int OrderId;
                bool flag = false;
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("PlaceOrder", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FullName", SqlDbType.VarChar).Value = cart.Customer.FullName;
                    cmd.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = cart.Customer.Mobile;
                    cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = cart.Customer.Address;
                    cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = cart.Customer.City;
                    cmd.Parameters.Add("@State", SqlDbType.VarChar).Value = cart.Customer.State;
                    cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = UserId;

                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            //Get OrderId from the Orders Table after Creating new Order.
                            OrderId = reader.GetInt32(0);

                            SqlConnection connection2 = new SqlConnection(connectionString);
                            using (connection2)
                            {
                                //for each book in cart insert into Orders_Books Table
                                foreach (var book in cart.BookList)
                                {
                                    SqlCommand command = new SqlCommand("InsertOrderedBooks", connection2);
                                    command.CommandType = CommandType.StoredProcedure;
                                    command.Parameters.Add("@OrderId", SqlDbType.VarChar).Value = OrderId;
                                    command.Parameters.Add("@BookId", SqlDbType.VarChar).Value = book.BookId;
                                    connection2.Open();
                                    var result = command.ExecuteNonQuery();
                                    connection2.Close();
                                    if (result != 0)
                                    {
                                        flag = true;
                                    }
                                    else flag = false;

                                }
                            }
                           
                        }
                    }
                  
                }
                return flag;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool RemoveFromCart(int UserId, int BookId)
        {
            try
            {
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand("RemoveFromCart", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserId", SqlDbType.VarChar).Value = UserId;
                    cmd.Parameters.Add("@BookId", SqlDbType.VarChar).Value = BookId;
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
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

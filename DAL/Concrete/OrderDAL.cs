using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL.Concrete
{
    public class OrderDAL:IOrderDAL
    {
        private string connectionString;

        public OrderDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public OrderDTO CreateOrder(OrderDTO order)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into [Order] (Customerid, OrderManagerid, Value, Date) output INSERTED.Order_id values (@Customerid, @OrderManagerid, @Value)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@Customerid", order.Customerid);
                comm.Parameters.AddWithValue("@OrderManagerid", order.OrderManagerid);
                comm.Parameters.AddWithValue("@Value", order.Value);
                comm.Parameters.AddWithValue("@Date", order.Date);

                conn.Open();

                order.Order_id = Convert.ToInt32(comm.ExecuteScalar());
                return order;
            }
        }

        public void DeleteOrder(int Order_id)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from [Add] where Id_or_order=@Order_id delete from [Order] where Order_id = @Order_id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@Order_id", Order_id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }



        public OrderDTO GetOrderById(int Order_id)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                OrderDTO order = new OrderDTO();

                comm.CommandText = "select * from [Order] where Order_id = @Order_id";

                comm.Parameters.AddWithValue("@Order_id", Order_id);
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    order = new OrderDTO
                    {
                        Order_id = Convert.ToInt32(reader["Order_id"]),
                        OrderManagerid = Convert.ToInt32(reader["OrderManagerid"]),
                        Customerid = Convert.ToInt32(reader["Customerid"]),
                        Value = Convert.ToInt32(reader["Value"]),
                        Date = Convert.ToDateTime(reader["Date"]),
                    };
                }

                return order;
            }
        }



        public List<OrderDTO> GetAllOrders(int OrderManagerid)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from [Order] where OrderManagerid = @OrderManagerid";
                comm.Parameters.AddWithValue("@OrderManagerid", OrderManagerid);
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<OrderDTO> orders = new List<OrderDTO>();
                while (reader.Read())
                {

                    orders.Add(new OrderDTO
                    {
                        Order_id = Convert.ToInt32(reader["Order_id"]),
                        Customerid = Convert.ToInt32(reader["Customerid"]),
                        OrderManagerid = Convert.ToInt32(reader["OrderManagerid"]),
                        Value = Convert.ToInt32(reader["Value"]),
                        Date = Convert.ToDateTime(reader["Date"]),
                    });
                }

                return orders;
            }
        }

        public List<OrderDTO> GetAllOrdersSorted(int SortParameter, int OrderManagerid)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                if (SortParameter == 1)
                {
                    comm.CommandText = "select * from [Order] where OrderManagerid=@OrderManagerid order by Date ASC";
                    comm.Parameters.AddWithValue("@OrderManagerid", OrderManagerid);
                }
                if (SortParameter == 2)
                {
                    comm.CommandText = "select * from [Order] where OrderManagerid=@OrderManagerid order by Date DESC";
                    comm.Parameters.AddWithValue("@OrderManagerid", OrderManagerid);
                }
                if (SortParameter == 3)
                {
                    comm.CommandText = "select * from [Order] where OrderManagerid=@OrderManagerid order by Value DESC";
                    comm.Parameters.AddWithValue("@OrderManagerid", OrderManagerid);
                }
                else
                {
                    comm.CommandText = "select * from [Order] where OrderManagerid=@OrderManagerid";
                    comm.Parameters.AddWithValue("@OrderManagerid", OrderManagerid);
                }





                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<OrderDTO> orders = new List<OrderDTO>();
                while (reader.Read())
                {

                    orders.Add(new OrderDTO
                    {
                        Order_id = Convert.ToInt32(reader["Order_id"]),
                        Customerid = Convert.ToInt32(reader["Customerid"]),
                        OrderManagerid = Convert.ToInt32(reader["OrderManagerid"]),
                        Value = Convert.ToInt32(reader["Value"]),
                        Date = Convert.ToDateTime(reader["Date"]),
                    });
                }

                return orders;
            }
        }

        public OrderDTO PackOrder(int Order_id)
        {
            int Value = 0;
            AddDTO orderitem = new AddDTO();
            ItemDTO item = new ItemDTO();
            OrderDTO order = new OrderDTO();

            ItemDAL dal = new ItemDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);
            OrderDAL dal1 = new OrderDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from [Add] where Id_or_order=@Id_or_order";
                comm.Parameters.AddWithValue("@Id_or_order", Order_id);
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();
                List<AddDTO> orderitems = new List<AddDTO>();
                while (reader.Read())
                {
                    orderitems.Add(new AddDTO
                    {
                        Id_or_order = Convert.ToInt32(reader["Id_or_order"]),
                        Id_of_item = Convert.ToInt32(reader["Id_of_item"]),
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                    });
                }
            }



            OrderDAL dal2 = new OrderDAL(ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString);

            order = new OrderDTO
            {
                Order_id = Order_id,
                Value = Value
            };



            using (SqlConnection conn1 = new SqlConnection(this.connectionString))
            using (SqlCommand comm1 = conn1.CreateCommand())
            {
                comm1.CommandText = "update [Order] set Value= @Value where Order_id = @Order_id";
                comm1.Parameters.Clear();
                comm1.Parameters.AddWithValue("@Order_id", order.Order_id);
                comm1.Parameters.AddWithValue("@Value", order.Value);
                conn1.Open();

                order.Order_id = Convert.ToInt32(comm1.ExecuteScalar());
            }


            return order;




        }

    }
}
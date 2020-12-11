using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class Order_ManagerDAL:IOrder_ManagerDAL
    {
        private string connectionString;

        public Order_ManagerDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public Order_ManagerDTO GetOrder_ManagerById(int O_M_id)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                Order_ManagerDTO Order_Manager = new Order_ManagerDTO();

                comm.CommandText = $"select * from Order_Manager where O_M_id = @O_M_id";
                comm.Parameters.AddWithValue("@O_M_id", O_M_id);
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    Order_Manager = new Order_ManagerDTO
                    {
                        O_M_id = Convert.ToInt32(reader["O_M_id"]),
                        Login = reader["Login"].ToString(),
                        Password = (byte[])(reader["Password"]),
                        E_mail = reader["E_mail"].ToString(),
                    };
                }

                return Order_Manager;
            }
        }


        public Order_ManagerDTO GetOrder_ManagerByLogin(string Order_ManagerLogin)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                Order_ManagerDTO Order_Manager = new Order_ManagerDTO();

                comm.CommandText = $"select * from Order_Manager where Login = @Login";
                comm.Parameters.AddWithValue("@Login", Order_ManagerLogin);
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    Order_Manager = new Order_ManagerDTO
                    {
                        O_M_id = Convert.ToInt32(reader["O_M_id"]),
                        Login = reader["Login"].ToString(),
                        Password = (byte[])(reader["Password"]),
                        E_mail = reader["E_mail"].ToString(),
                    };
                }

                return Order_Manager;
            }
        }


        public Order_ManagerDTO CreateOrder_Manager(Order_ManagerDTO Order_Manager)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into Order_Manager (Login, Password, E_mail) output INSERTED.O_M_id values (@Login, @Password, @E_mail)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@Login", Order_Manager.Login);
                comm.Parameters.AddWithValue("@Password", Order_Manager.Password);
                comm.Parameters.AddWithValue("@E_mail", Order_Manager.E_mail);
                conn.Open();

                Order_Manager.O_M_id = Convert.ToInt32(comm.ExecuteScalar());
                return Order_Manager;
            }
        }

        public Order_ManagerDTO UpdateOrder_Manager(Order_ManagerDTO Order_Manager)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "update Order_Manager set E_mail = @E_mail where O_M_id = @O_M_id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@O_M_id", Order_Manager.O_M_id);
                comm.Parameters.AddWithValue("@E_mail", Order_Manager.E_mail);
                conn.Open();

                Order_Manager.O_M_id = Convert.ToInt32(comm.ExecuteScalar());


                return Order_Manager;
            }




        }

        public bool Login(string Password, string Login)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                Order_ManagerDTO Order_Manager = new Order_ManagerDTO();

                comm.CommandText = $"select * from Order_Manager where Login=@Login";
                comm.Parameters.AddWithValue("@Login", Login);
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    Order_Manager = new Order_ManagerDTO
                    {
                        O_M_id = Convert.ToInt32(reader["O_M_id"]),
                        Login = reader["Login"].ToString(),
                        Password = (byte[])(reader["Password"]),
                        E_mail = reader["E_mail"].ToString(),

                    };
                    if (new PasswordActions().PasswordDecryption(Order_Manager.Password) == Password)
                    {
                        return true;
                    }
                }


            }
            return false;
        }




        public void DeleteOrder_Manager(int O_M_id)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from Order_Manager where O_M_id = @O_M_id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@O_M_id", O_M_id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }
    }
}

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
    public class CustomerDAL:ICustomerDAL
    {
        private string connectionString;

        public CustomerDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<CustomerDTO> GetAllCustomers()
        {
            throw new NotImplementedException();
        }


        public CustomerDTO GetCustomerById(int Customer_id)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                CustomerDTO Customer = new CustomerDTO();

                comm.CommandText = $"select * from Customer where Customer_id=@Customer_id";
                comm.Parameters.AddWithValue("@Customer_id", Customer_id);
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    Customer = new CustomerDTO
                    {
                        Customer_id = Convert.ToInt32(reader["Customer_id"]),
                        Customer_login = reader["Customer_login"].ToString(),
                        Customer_e_mail = reader["Customer_e_mail"].ToString(),
                    };
                }

                return Customer;
            }
        }


        public CustomerDTO GetCustomerByLogin(string Customer_e_mail)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                CustomerDTO Customer = new CustomerDTO();

                comm.CommandText = $"select * from Customer where Customer_e_mail=@Customer_e_mail";
                comm.Parameters.AddWithValue("@Customer_e_mail", Customer_e_mail);
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    Customer = new CustomerDTO
                    {
                        Customer_id = Convert.ToInt32(reader["Customer_id"]),
                        Customer_login = reader["Customer_login"].ToString(),
                        Customer_e_mail = reader["Customer_e_mail"].ToString(),
                    };
                }

                return Customer;
            }
        }

        public void DeleteCustomer(int Customer_id)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from Customer where Customer_id = @Customer_id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@Customer_id", Customer_id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }

        public CustomerDTO UpdateCustomer(CustomerDTO Customer)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "update Customer set Customer_login =@Customer_login, Customer_e_mail= @Customer_e_mail where Customer_id = @Customer_id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@Customer_id", Customer.Customer_id);
                comm.Parameters.AddWithValue("@Customer_login", Customer.Customer_login);
                comm.Parameters.AddWithValue("@Customer_e_mail", Customer.Customer_e_mail);
                conn.Open();

                Customer.Customer_id = Convert.ToInt32(comm.ExecuteScalar());


                return Customer;
            }
        }


        public CustomerDTO CreateCustomer(CustomerDTO Customer)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into Customer (Customer_login,Customer_e_mail) output INSERTED.Customer_id values (@Customer_login, @Customer_e_mail)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@Customer_id", Customer.Customer_id);
                comm.Parameters.AddWithValue("@Customer_login", Customer.Customer_login);
                comm.Parameters.AddWithValue("@Customer_e_mail", Customer.Customer_e_mail);
                conn.Open();

                Customer.Customer_id = Convert.ToInt32(comm.ExecuteScalar());
                return Customer;
            }
        }


        public bool Login(string Password, string Login)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                CustomerDTO shipper = new CustomerDTO();

                comm.CommandText = $"select * from Customer where Customer_e_mail=@Login";
                comm.Parameters.AddWithValue("@Login", Login);
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    shipper = new CustomerDTO
                    {
                        Customer_id = Convert.ToInt32(reader["Customer_id"]),
                        Customer_login = reader["Customer_login"].ToString(),
                        Customer_e_mail = reader["Customer_e_mail"].ToString(),
                    };
                    if (shipper.Customer_e_mail == Password)
                    {
                        return true;
                    }
                }


            }
            return false;
        }
    }
}

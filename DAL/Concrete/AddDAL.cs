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
    public class AddDAL:IAddDAL
    {
        private string connectionString;

        public AddDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public AddDTO Add(AddDTO add)
        {
            throw new NotImplementedException();
        }


        //adds one order position to order
        public AddDTO Createadd(AddDTO add)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into [Add] (Id_of_order, Id_of_item, Quantity) values (@Id_of_order, @Id_of_item, @Quantity)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@Id_of_order",add.Id_or_order);
                comm.Parameters.AddWithValue("@Id_of_item", add.Id_of_item);
                comm.Parameters.AddWithValue("@Quantity", add.Quantity);
                conn.Open();

                return add;
            }
        }

        //deletes one position from order
        public void Deleteadd(int Id_of_order)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from [Add] where Id_of_order = @Id_of_order";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@Id_of_order", Id_of_order);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }

        //shows all positions from one(same) order
        public List<AddDTO> FromSameOrder(int Id_of_order)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from [Add] where Id_of_order = @Id_of_order";
                comm.Parameters.AddWithValue("@Id_of_order", Id_of_order);
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<AddDTO> items = new List<AddDTO>();
                while (reader.Read())
                {

                    items.Add(new AddDTO
                    {
                        Id_or_order = Convert.ToInt32(reader["Id_of_order"]),
                        Id_of_item = Convert.ToInt32(reader["Id_of_item"]),
                        Quantity = Convert.ToInt32(reader["Quantity"])
                    });
                }

                return items;
            }
        }

    }
}

using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace DAL.Concrete
{
    public class ItemDAL:IItemDAL
    {
        private string connectionString;

        public ItemDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public ItemDTO CreateItem(ItemDTO item)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into Item (Name, Value) output INSERTED.Item_id values (@Name, @Value";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@Name", item.Name);
                comm.Parameters.AddWithValue("@Value", item.Value);
                conn.Open();

                item.Item_id = Convert.ToInt32(comm.ExecuteScalar());
                return item;
            }
        }

        public void DeleteItem(int Item_id)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from Item where Item_id = @Item_id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@Item_id", Item_id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }

        public List<ItemDTO> GetAllItems()
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from Item";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<ItemDTO> items = new List<ItemDTO>();
                while (reader.Read())
                {
                    items.Add(new ItemDTO
                    {
                        Item_id = Convert.ToInt32(reader["Item_id"]),
                        Name = reader["Name"].ToString(),
                        Value = Convert.ToInt32(reader["Value"]),
                    });
                }

                return items;
            }
        }

        public List<ItemDTO> GetAllItemsSorted(int SortParameter)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {



                if (SortParameter == 1)
                {
                    comm.CommandText = "select * from Item order by Value ASC";
                }
                if (SortParameter == 2)
                {
                    comm.CommandText = "select * from Item order by Name DESC";

                }
                if (SortParameter == 3)
                { comm.CommandText = "select * from Item order by Item_id DESC"; }

                else
                { comm.CommandText = "select * from Item"; }






                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<ItemDTO> items = new List<ItemDTO>();
                while (reader.Read())
                {

                    items.Add(new ItemDTO
                    {
                        Item_id = Convert.ToInt32(reader["Item_id"]),
                        Name = (reader["Name"]).ToString(),
                        Value = Convert.ToInt32(reader["Value"]),
                    });
                }
                //Convert.
                return items;
            }
        }




        public ItemDTO GetItemById(int Item_id)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                ItemDTO items = new ItemDTO();

                comm.CommandText = $"select * from Item where Item_id={Item_id}";

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    items = new ItemDTO
                    {
                        Item_id = Convert.ToInt32(reader["Item_id"]),
                        Name = reader["Name"].ToString(),
                        Value = Convert.ToInt32(reader["Value"]),
                    };
                }

                return items;
            }
        }

        public ItemDTO UpdateItem(ItemDTO item)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "update Item set Value= @Value, =@ where Item_id = @Item_id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@Item_id", item.Item_id);
                //comm.Parameters.AddWithValue("@Name", item.Name);
                comm.Parameters.AddWithValue("@Value", item.Value);
                conn.Open();

                item.Item_id = Convert.ToInt32(comm.ExecuteScalar());


                return item;
            }
        }
    }
}

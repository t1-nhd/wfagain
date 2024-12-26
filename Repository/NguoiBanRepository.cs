using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test.Model;

namespace test.Repository
{
    internal class NguoiBanRepository
    {
        private readonly string connectionString = StaticResource.connectionString();
        SqlConnection connection;

        public List<NguoiBan> getListNguoiBan()
        {
            List<NguoiBan> list = new List<NguoiBan>();
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("select * from NguoiBan", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                NguoiBan kh = new NguoiBan();

                                kh.MaNB = reader["MaNB"].ToString();
                                kh.TenNB = reader["TenNB"].ToString();
                                kh.DiaChi = reader["DiaChi"].ToString();

                                list.Add(kh);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Failed to get list NguoiBan" + ex);
            }
            finally
            {
                connection?.Close();
            }

            return list;
        }
    }
}

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
    internal class HangRepository
    {
        private readonly string connectionString = "Data Source=HDUYSTRIX;Initial Catalog=NhatNamFood;Integrated Security=True;TrustServerCertificate=True";


        public List<Hang> getListHang()
        {
            List<Hang> list = new List<Hang>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("select * from Hang", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Hang hang = new Hang();

                                hang.MaH = reader["MaH"].ToString();
                                hang.TenH = reader["TenH"].ToString();
                                hang.DonGia = reader.GetDecimal(reader.GetOrdinal("DonGia"));

                                list.Add(hang);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Failed to get list Hang" + ex);
            }

            return list;
        }
    }
}

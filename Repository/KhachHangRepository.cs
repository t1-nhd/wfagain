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
    internal class KhachHangRepository
    {
        private readonly string connectionString = "Data Source=HDUYSTRIX;Initial Catalog=NhatNamFood;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection connection;

        public List<KhachHang> getListKhachHang()
        {
            List<KhachHang> list = new List<KhachHang>();
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("select * from KhachHang", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                KhachHang kh = new KhachHang();

                                kh.MaKH = reader["MaKH"].ToString();
                                kh.TenKH = reader["TenKH"].ToString();
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
                MessageBox.Show("Failed to get list KhachHang" + ex);
            }
            finally
            {
                connection?.Close();
            }

            return list;
        }

        public String getTenKH(string maKH)
        {
            string tenKH = "";
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("select kh.TenKH from KhachHang kh where kh.MaKH = @maKH", connection))
                    {
                        command.Parameters.AddWithValue("maKH", maKH);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                tenKH = reader["TenKH"].ToString();
                                return tenKH;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to find Khach hang" + ex);
            }
            finally
            {
                connection?.Close();
            }
            return tenKH;
        }
    }
}

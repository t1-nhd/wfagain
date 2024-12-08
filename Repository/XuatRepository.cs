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
    internal class XuatRepository
    {
        private readonly string connectionString = "Data Source=HDUYSTRIX;Initial Catalog=NhatNamFood;Integrated Security=True;TrustServerCertificate=True";


        public List<Xuat> getListXuat()
        {
            List<Xuat> list = new List<Xuat>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("select * from Xuat x order by x.NgayXK DESC", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Xuat xuat = new Xuat();

                                xuat.MaHDX = reader["MaHDX"].ToString();
                                xuat.NgayXK = reader.GetDateTime(reader.GetOrdinal("NgayXK"));
                                xuat.TongCong = reader.GetDecimal(reader.GetOrdinal("TongCong"));
                                xuat.MaKH = reader["MaKH"].ToString();

                                list.Add(xuat);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Failed to get list Xuat" + ex);
            }

            return list;
        }

        public List<XuatChiTiet> getListXuatChiTiet(string maHDX)
        {
            List<XuatChiTiet> list = new List<XuatChiTiet>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("select * from XuatChiTiet xct where xct.MaHDX = @maHDX", connection))
                    {
                        command.Parameters.AddWithValue("maHDX", maHDX);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                XuatChiTiet ct = new XuatChiTiet();

                                ct.MaHDX = reader["MaHDX"].ToString();
                                ct.MaH = reader["MaH"].ToString();
                                ct.SoLuong = reader.GetInt32(reader.GetOrdinal("SoLuong"));

                                list.Add(ct);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Failed to get list Xuat" + ex);
            }

            return list;
        }

        public string getLastId()
        {
            Xuat xuat = new Xuat();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT TOP 1 x.MaHDX FROM Xuat x ORDER BY x.MaHDX DESC", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return reader["MaHDX"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to find Khach hang" + ex);
            }
            return "";
        }

        public Hang getHang(string maH)
        {
            Hang hang = new Hang();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("select h.TenH, h.DonGia from Hang h where h.MaH = @maH", connection))
                    {
                        command.Parameters.AddWithValue("maH", maH);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                hang.TenH = reader["TenH"].ToString();
                                hang.DonGia = reader.GetDecimal(reader.GetOrdinal("DonGia"));
                                return hang;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to find Khach hang" + ex);
            }
            return hang;
        }

        public String getTenKH(string maKH)
        {
            string tenKH = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
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
            return tenKH;
        }
    }
}

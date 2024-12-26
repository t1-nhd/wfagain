using System;
using System.Collections.Generic;
using System.Data;
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
        private readonly string connectionString = StaticResource.connectionString();
        SqlConnection connection;

        public List<Xuat> getListXuat()
        {
            List<Xuat> list = new List<Xuat>();
            try
            {
                using (connection = new SqlConnection(connectionString))
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
            finally
            {
                connection?.Close();
            }

            return list;
        }

        public List<XuatChiTiet> getListXuatChiTiet(string maHDX)
        {
            List<XuatChiTiet> list = new List<XuatChiTiet>();
            try
            {
                using (connection = new SqlConnection(connectionString))
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
            finally
            {
                connection?.Close();
            }

            return list;
        }

        public string getLastId()
        {
            Xuat xuat = new Xuat();
            try
            {
                using (connection = new SqlConnection(connectionString))
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
            finally
            {
                connection?.Close();
            }
            return "";
        }
    }
}

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
    internal class NhapRepository
    {
        private readonly string connectionString = "Data Source=HDUYSTRIX;Initial Catalog=NhatNamFood;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection connection;

        public List<Nhap> getListNhap()
        {
            List<Nhap> list = new List<Nhap>();
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using(SqlCommand command = new SqlCommand("select * from Nhap n order by n.MaHD DESC", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Nhap nhap = new Nhap();

                                nhap.MaHD = reader["MaHD"].ToString();
                                nhap.MaNB = reader["MaNB"].ToString();
                                nhap.NgayNhap = reader.GetDateTime(reader.GetOrdinal("NgayNhap"));
                                nhap.CongTH = reader.GetDecimal(reader.GetOrdinal("CongTH"));
                                nhap.ThueSuatGTGT = reader.GetDouble(reader.GetOrdinal("ThueSuatGTGT"));
                                nhap.TongTT = reader.GetDecimal(reader.GetOrdinal("TongTT"));
                                
                                list.Add(nhap);
                            }
                        }
                    }
                }
            }
            catch (Exception ex){
                Console.WriteLine(ex.Message); 
                MessageBox.Show("Failed to get list Nhap" + ex);
            }
            finally
            {
                connection?.Close();
            }

            return list;
        }

        public String getTenNB(string maNB)
        {
            string tenNB = "";
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("select nb.TenNB from NguoiBan nb where nb.MaNB = @maNB", connection))
                    {
                        command.Parameters.AddWithValue("maNB", maNB);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) {
                                tenNB = reader["TenNB"].ToString();
                                return tenNB;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to find Nguoi ban" + ex);
            }
            finally
            {
                connection?.Close();
            }
            return tenNB;
        }
    }
}

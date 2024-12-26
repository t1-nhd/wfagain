using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test.Model;
using test.Repository;

namespace test
{
    public partial class FormXuatChiTiet : Form
    {
        string maHDX;
        string connectionString = StaticResource.connectionString();
        SqlConnection connection;
        DataTable dataTable;
        XuatRepository xuatRepository = new XuatRepository();
        HangRepository hangRepository = new HangRepository();

        public FormXuatChiTiet(string maHDX)
        {
            InitializeComponent();
            InitConnectDb();
            this.maHDX = maHDX;
            LoadData();
        }

        public void InitConnectDb()
        {
            connection = new SqlConnection(connectionString);
        }

        public void LoadData()
        {
            try
            {
                connection.Open();
                List<XuatChiTiet> listXCT = xuatRepository.getListXuatChiTiet(this.maHDX);

                dataTable = new DataTable();
                dataTable.Columns.Add("MaHDX");
                dataTable.Columns.Add("TenHang");
                dataTable.Columns.Add("SoLuong");
                dataTable.Columns.Add("ThanhTien");

                foreach (XuatChiTiet ct in listXCT)
                {
                    var row = dataTable.NewRow();

                    row["MaHDX"] = ct.MaHDX;
                    row["TenHang"] = hangRepository.getHang(ct.MaH).TenH;
                    row["SoLuong"] = ct.SoLuong;
                    row["ThanhTien"] = ct.SoLuong * hangRepository.getHang(ct.MaH).DonGia;

                    dataTable.Rows.Add(row);
                }


                this.dataGridXuatCT.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Failed to load data" + ex);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}

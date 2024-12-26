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
    public partial class FormXuat : Form
    {
        string connectionString = StaticResource.connectionString();
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataTable dataTable;
        XuatRepository xuatRepository = new XuatRepository();
        HangRepository hangRepository = new HangRepository();
        KhachHangRepository KhachHangRepository = new KhachHangRepository();

        public FormXuat()
        {
            InitializeComponent();
            InitConnectDb();
            loadData();
        }

        public void InitConnectDb()
        {
            connection = new SqlConnection(connectionString);
        }

        public void loadData()
        {
            try
            {
                connection.Open();
                adapter = new SqlDataAdapter("select * from Xuat x order by x.MaHDX DESC", connection);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                dataTable = new DataTable();
                adapter.Fill(dataTable);
                this.dataTableChangeFormat(dataTable);

                this.dataTable.Columns["MaKH"].ColumnName = "TenKH";
                this.dataGridXuat.DataSource = dataTable;
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
        public void dataTableChangeFormat(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                string maKH = row["MaKH"].ToString();
                string tenKH = KhachHangRepository.getTenKH(maKH);
                row["MaKH"] = tenKH; // Thay thế giá trị MaNB bằng TenNB }

                DateTime ngayNX = (DateTime)row["NgayXK"];
                row["NgayXK"] = ngayNX.ToString("dd/MM/yyyy");
            }
        }

        private void dataGridXuat_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridXuat.Rows[e.RowIndex];
            string maHDX = selectedRow.Cells["MaHDX"].Value.ToString();

            FormXuatChiTiet formXuatChiTiet = new FormXuatChiTiet(maHDX);
            formXuatChiTiet.Show();
        }

        private void createXuatBt_Click(object sender, EventArgs e)
        {
            FormCreateHoaDonXuat formCreateHoaDonXuat = new FormCreateHoaDonXuat();
            formCreateHoaDonXuat.Show();
            this.Close();
        }

        private void FormCreateHoaDonXuat_CreateSuccessfully(object sender, EventArgs e)
        {
            loadData();
        }

    }
}

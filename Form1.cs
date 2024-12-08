using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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
    public partial class FormNhap : Form
    {
        string connectionString = "Data Source=HDUYSTRIX;Initial Catalog=NhatNamFood;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection connection;
        DataTable dataTable;
        NhapRepository nhapRepository = new NhapRepository();

        public FormNhap()
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
                List<Nhap> nhaps = nhapRepository.getListNhap();
                dataTable = new DataTable();

                dataTable.Columns.Add("MaHD");
                dataTable.Columns.Add("TenNB");
                dataTable.Columns.Add("NgayNhap");
                dataTable.Columns.Add("CongTH");
                dataTable.Columns.Add("ThueSuatGTGT");
                dataTable.Columns.Add("TongTT");

                foreach (Nhap nhap in nhaps) { 
                    var row = dataTable.NewRow();

                    row["MaHD"] = nhap.MaHD;
                    row["TenNB"] = nhapRepository.getTenNB(nhap.MaNB);
                    row["NgayNhap"] = nhap.NgayNhap.ToString("dd/MM/yyyy");
                    row["CongTH"] = nhap.CongTH;
                    row["ThueSuatGTGT"] = nhap.ThueSuatGTGT;
                    row["TongTT"] = nhap.TongTT;

                    dataTable.Rows.Add(row);
                }

                this.dataGridNhap.DataSource = dataTable;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Failed to load data" + ex);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormXuat formXuat = new FormXuat();
            formXuat.Show();
        }
    }
}

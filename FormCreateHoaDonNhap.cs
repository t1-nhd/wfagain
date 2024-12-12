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
    public partial class FormCreateHoaDonNhap : Form
    {
        string connectionString = "Data Source=HDUYSTRIX;Initial Catalog=NhatNamFood;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection connection;
        DataTable dataTable;
        string maHDN;
        HangRepository hangRepository = new HangRepository();
        NguoiBanRepository nguoiBanRepository = new NguoiBanRepository();
        readonly int _5M = 5000000;
        double tax = 0.3;
        public event EventHandler CreateSuccessfully;

        public FormCreateHoaDonNhap()
        {
            InitializeComponent();
            InitConnectDb();
            autoId();
            loadData();
            label9.Text = maHDN;
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
                List<Hang> hangs = hangRepository.getListHang();
                List<NguoiBan> nbs = nguoiBanRepository.getListNguoiBan();

                productCbBox.DataSource = hangs;
                productCbBox.DisplayMember = "TenH";
                productCbBox.ValueMember = "MaH";

                empNameCbBox.DataSource = nbs;
                empNameCbBox.DisplayMember = "TenNB";
                empNameCbBox.ValueMember = "MaNB";

                dataTable = new DataTable();
                dataTable.Columns.Add("MaH");
                dataTable.Columns.Add("TenH");
                dataTable.Columns.Add("SoLuong");
                dataTable.Columns.Add("tt");
                dataTable.Columns.Add("ThanhTien");
                dataTable.Columns.Add("ThaoTac");

                DateTime ngayXuat = DateTime.Now;
                dateLabel.Text = ngayXuat.ToString("dd/MM/yyyy");

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



        //using procedure spNew_MaHD
        private void autoId()
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("spNew_MaHD", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter outputParam = new SqlParameter("@new_MaHD", SqlDbType.VarChar, 9) { 
                    Direction = ParameterDirection.Output 
                }; 
                cmd.Parameters.Add(outputParam);
                cmd.ExecuteNonQuery();
                maHDN = outputParam.Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        private void backBt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int uP;
        private void productCbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            Hang selectedHang = cb.SelectedItem as Hang;
            int sl = (int)quantity.Value;

            string lastPrice = ((int)selectedHang.DonGia * sl).ToString("N0", new System.Globalization.CultureInfo("de-DE"));
            string unitPrice = selectedHang.DonGia.ToString("N0", new System.Globalization.CultureInfo("de-DE"));
            this.uP = (int)selectedHang.DonGia;


            unitPriceLabel.Text = unitPrice + "VND";
            totalPriceLb.Text = lastPrice + "VND";
        }

        private void quantity_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = sender as NumericUpDown;
            int quantity = (int)numericUpDown.Value;

            string lastPrice = (this.uP * quantity).ToString("N0", new System.Globalization.CultureInfo("de-DE")) + "VND";

            totalPriceLb.Text = lastPrice;
            string thanhTien = lastPrice;
        }

        private void addItemBt_Click(object sender, EventArgs e)
        {
            int sl = (int)quantity.Value;
            string maH = productCbBox.SelectedValue.ToString();
            int unitPrice = (int)hangRepository.getHang(maH).DonGia;
            int lastPrice = (int)quantity.Value * unitPrice;
            bool isExist = false;

            foreach (DataRow row in dataTable.Rows)
            {
                if (row["MaH"].ToString() == maH)
                {
                    int newSl = int.Parse(row["SoLuong"].ToString()) + sl;
                    int newThanhTien = newSl * unitPrice;
                    row["SoLuong"] = newSl.ToString();
                    row["ThanhTien"] = newThanhTien.ToString("N0", new System.Globalization.CultureInfo("de-DE")) + "VND";
                    row["tt"] = newThanhTien;
                    isExist = true;
                    break;
                }
            }

            if (!isExist)
            {
                DataRow newRow = dataTable.NewRow();

                newRow["MaH"] = maH;
                newRow["TenH"] = hangRepository.getHang(maH).TenH;
                newRow["SoLuong"] = sl;
                newRow["tt"] = sl * unitPrice;
                newRow["ThanhTien"] = (sl * unitPrice).ToString("N0", new System.Globalization.CultureInfo("de-DE")) + "VND";
                newRow["ThaoTac"] = "Xóa";

                dataTable.Rows.Add(newRow);

                DGVNewNhapCT.DataSource = dataTable;
                DGVNewNhapCT.Columns["MaH"].Visible = false;
                DGVNewNhapCT.Columns["tt"].Visible = false;
                saveXuatBt.Enabled = true;
            }
            quantity.Value = 1;
            totalAllPriceLb.Text = this.calculateToTalAllPrice().ToString("N0", new System.Globalization.CultureInfo("de-DE")) + "VND"; ;
            lastPriceLb.Text = this.calculateLastPrice().ToString("N0", new System.Globalization.CultureInfo("de-DE")) + "VND"; ;
        }

        private int calculateToTalAllPrice()
        {
            int totalPrice = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                totalPrice += int.Parse(row["tt"].ToString());
            }
            if(totalPrice >= _5M)
            {
                taxDecrease.Text = (totalPrice * 0.4).ToString("N0", new System.Globalization.CultureInfo("de-DE")) + "VND";
            }
            else
            {
                taxDecrease.Text = (totalPrice * 0.3).ToString("N0", new System.Globalization.CultureInfo("de-DE")) + "VND"; ;
            }
            return totalPrice;
        }

        private int calculateLastPrice()
        {
            double totalPrice = 0;
            foreach (DataRow row in dataTable.Rows) {
                totalPrice += int.Parse(row["tt"].ToString());
            }
            if (totalPrice < _5M)
            {
                totalPrice += totalPrice * 0.3;
            }
            else
            {
                totalPrice += totalPrice * 0.4;
            }
            return (int)totalPrice;
        }

        private void DGVNewNhapCT_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVNewNhapCT.Columns.Count - 1 && e.RowIndex >= 0 && e.RowIndex < dataTable.Rows.Count)
            {
                dataTable.Rows.RemoveAt(e.RowIndex);
                if (dataTable.Rows.Count == 0)
                {
                    saveXuatBt.Enabled = false;
                }
            }
            cancelUpdateItemBt_Click(sender, e);
        }

        int rowIndex;
        private void DGVNewNhapCT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            if (rowIndex >= 0 && rowIndex < dataTable.Rows.Count)
            {
                DataGridViewRow row = DGVNewNhapCT.Rows[rowIndex];

                string maH = row.Cells["MaH"].Value.ToString();
                int sl = int.Parse(row.Cells["SoLuong"].Value.ToString());
                Hang thisHang = hangRepository.getHang(maH);
                string donGia = thisHang.DonGia.ToString("N0", new System.Globalization.CultureInfo("de-DE")) + "VND";
                string thanhTien = (sl * (int)thisHang.DonGia).ToString("N0", new System.Globalization.CultureInfo("de-DE")) + "VND";

                productCbBox.SelectedValue = maH;
                unitPriceLabel.Text = donGia;
                totalPriceLb.Text = thanhTien;
                totalAllPriceLb.Text = calculateToTalAllPrice().ToString("N0", new System.Globalization.CultureInfo("de-DE")) + "VND"; ;
                lastPriceLb.Text = calculateLastPrice().ToString("N0", new System.Globalization.CultureInfo("de-DE")) + "VND"; ;
                quantity.Value = sl;

                addItemBt.Visible = false;
                updateItemBt.Visible = true;
                cancelUpdateItemBt.Visible = true;
                label6.Text = "Cập nhật chi tiết";
            }
        }

        private void cancelUpdateItemBt_Click(object sender, EventArgs e)
        {
            label6.Text = "Thêm các chi tiết";
            updateItemBt.Visible = false;
            cancelUpdateItemBt.Visible = false;
            addItemBt.Visible = true;
            quantity.Value = 1;
        }

        private void updateItemBt_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = DGVNewNhapCT.Rows[rowIndex];
            string maH = row.Cells["MaH"].Value.ToString();
            int sl = int.Parse(quantity.Value.ToString());
            int tt = sl * (int)hangRepository.getHang(maH).DonGia;
            string thanhTien = tt.ToString("N0", new System.Globalization.CultureInfo("de-DE")) + "VND";

            DataRow foundRow = dataTable.Select($"MaH = '{maH}'").First();

            foundRow["SoLuong"] = sl;
            foundRow["ThanhTien"] = thanhTien;
            foundRow["tt"] = tt;

            DGVNewNhapCT.DataSource = null;
            DGVNewNhapCT.DataSource = dataTable;
            DGVNewNhapCT.Columns["MaH"].Visible = false;
            DGVNewNhapCT.Columns["tt"].Visible = false;
            cancelUpdateItemBt_Click(sender, e);
        }

        private void saveXuatBt_Click(object sender, EventArgs e)
        {
            using (var db = new Model1())
            {
                Nhap newNhap = new Nhap();

                newNhap.MaHD = this.maHDN;
                newNhap.NgayNhap = DateTime.Parse(this.dateLabel.Text);
                newNhap.ThueSuatGTGT = this.tax;
                newNhap.MaNB = this.empNameCbBox.SelectedValue.ToString();
                newNhap.TongTT = calculateLastPrice();
                newNhap.CongTH = calculateToTalAllPrice();


                List<NhapChiTiet> nhapChiTiets = new List<NhapChiTiet>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    string maH = dr["MaH"].ToString();
                    NhapChiTiet nhapChiTiet = new NhapChiTiet();
                    nhapChiTiet.MaHD = this.maHDN;
                    nhapChiTiet.MaH = maH;
                    nhapChiTiet.DonGiaNhap = hangRepository.getHang(maH).DonGia;
                    nhapChiTiet.SoLuong = int.Parse(dr["SoLuong"].ToString());

                    nhapChiTiets.Add(nhapChiTiet);
                }

                newNhap.NhapChiTiets = nhapChiTiets;

                try
                {
                    db.Nhaps.Add(newNhap);
                    db.SaveChanges();

                    dataTable.Clear();
                    this.Close();
                    MessageBox.Show("Thêm hóa đơn xuất thành công");

                    CreateSuccessfully?.Invoke(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm mới thất bại" + ex);
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}

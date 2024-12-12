using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using test.Model;
using test.Repository;

namespace test
{
    public partial class FormCreateHoaDonXuat : Form
    {
        string connectionString = "Data Source=HDUYSTRIX;Initial Catalog=NhatNamFood;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection connection;
        DataTable dataTable;
        HangRepository hangRepository = new HangRepository();
        KhachHangRepository khachHangRepository = new KhachHangRepository();
        XuatRepository xuatRepository = new XuatRepository();
        string maHDX;
        FormXuat formXuat = new FormXuat();
        public event EventHandler CreateSuccessfully;

        public FormCreateHoaDonXuat()
        {
            InitializeComponent();
            InitConnectDb();
            loadData();
            maHDX = autoId();
            label9.Text = maHDX;
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
                List<KhachHang> khs = khachHangRepository.getListKhachHang();

                productCbBox.DataSource = hangs;
                productCbBox.DisplayMember = "TenH";
                productCbBox.ValueMember = "MaH";

                cusNameCbBox.DataSource = khs;
                cusNameCbBox.DisplayMember = "TenKH";
                cusNameCbBox.ValueMember = "MaKH";

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

        int uP;
        private void productCbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            Hang selectedHang = cb.SelectedItem as Hang;
            int sl = (int)quantity.Value;

            string lastPrice = ((int)selectedHang.DonGia * sl).ToString("N0", new System.Globalization.CultureInfo("de-DE"));
            string unitPrice = selectedHang.DonGia.ToString("N0", new System.Globalization.CultureInfo("de-DE"));
            this.uP = (int)selectedHang.DonGia;

            int tongSLKho = this.tongSLKho(selectedHang.MaH);
            label12.Text = tongSLKho.ToString();

            unitPriceLabel.Text = unitPrice + "VND";
            lastPriceLabel.Text = lastPrice + "VND";
        }

        private void quantity_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = sender as NumericUpDown;
            int quantity = (int)numericUpDown.Value;

            string lastPrice = (this.uP * quantity).ToString("N0", new System.Globalization.CultureInfo("de-DE")) + "VND";

            lastPriceLabel.Text = lastPrice;
            string thanhTien = lastPrice;
        }

        private void addItemBt_Click(object sender, EventArgs e)
        {
            int sl = (int)quantity.Value;
            string maH = productCbBox.SelectedValue.ToString();
            int lastPrice = (int)quantity.Value * (int)hangRepository.getHang(maH).DonGia;
            bool isExist = false;

            foreach (DataRow row in dataTable.Rows)
            {
                if (row["MaH"].ToString() == maH)
                {
                    int newSl = int.Parse(row["SoLuong"].ToString()) + sl;
                    
                    if(newSl > this.tongSLKho(maH))
                    {
                        MessageBox.Show("Số lượng trong kho không đủ");
                        isExist = true;
                    }
                    else
                    {
                        int newThanhTien = newSl * (int)hangRepository.getHang(maH).DonGia;
                        row["SoLuong"] = newSl.ToString();
                        row["ThanhTien"] = newThanhTien.ToString("N0", new System.Globalization.CultureInfo("de-DE")) + "VND";

                        isExist = true;
                        
                    }
                    break;
                }
            }

            if (!isExist)
            {
                DataRow newRow = dataTable.NewRow();

                if (sl > this.tongSLKho(maH))
                {
                    MessageBox.Show("Số lượng trong kho không đủ");
                }
                else
                {
                    newRow["MaH"] = maH;
                    newRow["TenH"] = hangRepository.getHang(maH).TenH;
                    newRow["SoLuong"] = sl;
                    newRow["tt"] = sl * lastPrice;
                    newRow["ThanhTien"] = (sl * lastPrice).ToString("N0", new System.Globalization.CultureInfo("de-DE")) + "VND";
                    newRow["ThaoTac"] = "Xóa";

                    dataTable.Rows.Add(newRow);

                    DGVNewXuatCT.DataSource = dataTable;
                    DGVNewXuatCT.Columns["MaH"].Visible = false;
                    DGVNewXuatCT.Columns["tt"].Visible = false;
                    saveXuatBt.Enabled = true;
                }
            }
            quantity.Value = 1;
        }

        public int tongSLKho(string maH)
        {
            int slKho = 0;
            try
            {
                if (connection.State != ConnectionState.Open) connection.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT dbo.fTongSLNhapHH(@MaH) - dbo.fTongSLXuatHH(@MaH)", connection))
                {
                    cmd.Parameters.AddWithValue("@MaH", maH);
                    slKho = (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return slKho;
        }

        private string autoId()
        {
            string lastId = xuatRepository.getLastId();
            int lastNumber = int.Parse(lastId.Substring(3));
            int numberOfZeroNeedToPad = 9 - lastNumber.ToString().Length;
            string prefix = "HDX";

            return prefix.PadRight(numberOfZeroNeedToPad, '0') + ++lastNumber;
        }

        private void DGVNewXuatCT_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == DGVNewXuatCT.Columns.Count - 1 && e.RowIndex >= 0 && e.RowIndex < dataTable.Rows.Count)
            {
                dataTable.Rows.RemoveAt(e.RowIndex);
                if (dataTable.Rows.Count == 0) {
                    saveXuatBt.Enabled = false;
                }
            }
            cancelUpdateItemBt_Click(sender, e);
        }

        
        private void saveXuatBt_Click(object sender, EventArgs e)
        {
            using(var db = new Model1())
            {
                Xuat newXuat = new Xuat();

                newXuat.MaHDX = this.maHDX;
                newXuat.NgayXK = DateTime.Parse(this.dateLabel.Text);
                newXuat.MaKH = cusNameCbBox.SelectedValue.ToString();

                decimal tongCong = 0;


                List<XuatChiTiet> xuatChiTiets = new List<XuatChiTiet>();
                foreach (DataRow dr in dataTable.Rows)
                {
                    XuatChiTiet xuatChiTiet = new XuatChiTiet();
                    xuatChiTiet.MaHDX = this.maHDX;
                    xuatChiTiet.MaH = dr["MaH"].ToString();
                    xuatChiTiet.SoLuong = int.Parse(dr["SoLuong"].ToString());
                    tongCong += int.Parse(dr["tt"].ToString());

                    xuatChiTiets.Add(xuatChiTiet);
                }

                newXuat.XuatChiTiets = xuatChiTiets;
                newXuat.TongCong = tongCong;

                try
                {
                    db.Xuats.Add(newXuat);
                    db.SaveChanges();

                    dataTable.Clear();
                    this.Close();
                    formXuat.Show();
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

        int rowIndex;
        private void DGVNewXuatCT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
            if (rowIndex >= 0 && rowIndex < dataTable.Rows.Count) {
                DataGridViewRow row = DGVNewXuatCT.Rows[rowIndex];

                string maH = row.Cells["MaH"].Value.ToString();
                int sl = int.Parse(row.Cells["SoLuong"].Value.ToString());
                Hang thisHang = hangRepository.getHang(maH);
                string donGia = thisHang.DonGia.ToString("N0", new System.Globalization.CultureInfo("de-DE")) + "VND";
                string thanhTien = (sl * (int)thisHang.DonGia).ToString("N0", new System.Globalization.CultureInfo("de-DE")) + "VND";

                productCbBox.SelectedValue = maH;
                unitPriceLabel.Text = donGia;
                lastPriceLabel.Text = thanhTien;
                quantity.Value = sl;

                addItemBt.Visible = false;
                updateItemBt.Visible = true;
                cancelUpdateItemBt.Visible = true;
                label6.Text = "Cập nhật chi tiết";
            }
        }
        private void updateItemBt_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = DGVNewXuatCT.Rows[rowIndex];
            string maH = row.Cells["MaH"].Value.ToString();
            int sl = int.Parse(quantity.Value.ToString());

            if (sl > tongSLKho(maH))
            {
                MessageBox.Show("Số lượng trong kho không đủ");
            }
            else
            {
                int tt = sl * (int)hangRepository.getHang(maH).DonGia;
                string thanhTien = tt.ToString("N0", new System.Globalization.CultureInfo("de-DE")) + "VND";

                DataRow foundRow = dataTable.Select($"MaH = '{maH}'").First();

                foundRow["SoLuong"] = sl;
                foundRow["ThanhTien"] = thanhTien;
                foundRow["tt"] = tt;

                DGVNewXuatCT.DataSource = null;
                DGVNewXuatCT.DataSource = dataTable;
                DGVNewXuatCT.Columns["MaH"].Visible = false;
                DGVNewXuatCT.Columns["tt"].Visible = false;
                cancelUpdateItemBt_Click(sender, e);
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

        private void backBt_Click(object sender, EventArgs e)
        {
            formXuat.Show();
            this.Close();
        }
    }
}

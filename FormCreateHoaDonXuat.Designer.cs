﻿namespace test
{
    partial class FormCreateHoaDonXuat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.DGVNewXuatCT = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cusNameCbBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.productCbBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.unitPriceLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.quantity = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.lastPriceLabel = new System.Windows.Forms.Label();
            this.addItemBt = new System.Windows.Forms.Button();
            this.saveXuatBt = new System.Windows.Forms.Button();
            this.hiddenLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVNewXuatCT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(645, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hóa đơn chi tiết xuất";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DGVNewXuatCT
            // 
            this.DGVNewXuatCT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVNewXuatCT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVNewXuatCT.Location = new System.Drawing.Point(12, 120);
            this.DGVNewXuatCT.Name = "DGVNewXuatCT";
            this.DGVNewXuatCT.Size = new System.Drawing.Size(445, 336);
            this.DGVNewXuatCT.TabIndex = 1;
            this.DGVNewXuatCT.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVNewXuatCT_CellDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Thông tin chung";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên khách hàng";
            // 
            // cusNameCbBox
            // 
            this.cusNameCbBox.FormattingEnabled = true;
            this.cusNameCbBox.Location = new System.Drawing.Point(134, 60);
            this.cusNameCbBox.Name = "cusNameCbBox";
            this.cusNameCbBox.Size = new System.Drawing.Size(220, 21);
            this.cusNameCbBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(399, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ngày xuất:";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(463, 63);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(15, 13);
            this.dateLabel.TabIndex = 3;
            this.dateLabel.Text = "lb";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(463, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "Thêm các chi tiết";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(463, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Mặt hàng:";
            // 
            // productCbBox
            // 
            this.productCbBox.FormattingEnabled = true;
            this.productCbBox.Location = new System.Drawing.Point(466, 171);
            this.productCbBox.Name = "productCbBox";
            this.productCbBox.Size = new System.Drawing.Size(191, 21);
            this.productCbBox.TabIndex = 7;
            this.productCbBox.SelectedIndexChanged += new System.EventHandler(this.productCbBox_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(463, 206);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Đơn giá:";
            // 
            // unitPriceLabel
            // 
            this.unitPriceLabel.AutoSize = true;
            this.unitPriceLabel.Location = new System.Drawing.Point(533, 206);
            this.unitPriceLabel.Name = "unitPriceLabel";
            this.unitPriceLabel.Size = new System.Drawing.Size(30, 13);
            this.unitPriceLabel.TabIndex = 8;
            this.unitPriceLabel.Text = "VND";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(463, 243);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Số lượng:";
            // 
            // quantity
            // 
            this.quantity.Location = new System.Drawing.Point(466, 259);
            this.quantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantity.Name = "quantity";
            this.quantity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.quantity.Size = new System.Drawing.Size(191, 20);
            this.quantity.TabIndex = 10;
            this.quantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantity.ValueChanged += new System.EventHandler(this.quantity_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(463, 309);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Thành tiền:";
            // 
            // lastPriceLabel
            // 
            this.lastPriceLabel.AutoSize = true;
            this.lastPriceLabel.Location = new System.Drawing.Point(533, 309);
            this.lastPriceLabel.Name = "lastPriceLabel";
            this.lastPriceLabel.Size = new System.Drawing.Size(30, 13);
            this.lastPriceLabel.TabIndex = 11;
            this.lastPriceLabel.Text = "VND";
            // 
            // addItemBt
            // 
            this.addItemBt.Location = new System.Drawing.Point(466, 340);
            this.addItemBt.Name = "addItemBt";
            this.addItemBt.Size = new System.Drawing.Size(191, 23);
            this.addItemBt.TabIndex = 12;
            this.addItemBt.Text = "Thêm chi tiết";
            this.addItemBt.UseVisualStyleBackColor = true;
            this.addItemBt.Click += new System.EventHandler(this.addItemBt_Click);
            // 
            // saveXuatBt
            // 
            this.saveXuatBt.Enabled = false;
            this.saveXuatBt.Location = new System.Drawing.Point(466, 415);
            this.saveXuatBt.Name = "saveXuatBt";
            this.saveXuatBt.Size = new System.Drawing.Size(191, 41);
            this.saveXuatBt.TabIndex = 13;
            this.saveXuatBt.Text = "Lưu hóa đơn";
            this.saveXuatBt.UseVisualStyleBackColor = true;
            this.saveXuatBt.Click += new System.EventHandler(this.saveXuatBt_Click);
            // 
            // hiddenLabel1
            // 
            this.hiddenLabel1.AutoSize = true;
            this.hiddenLabel1.Location = new System.Drawing.Point(598, 206);
            this.hiddenLabel1.Name = "hiddenLabel1";
            this.hiddenLabel1.Size = new System.Drawing.Size(0, 13);
            this.hiddenLabel1.TabIndex = 14;
            // 
            // FormCreateHoaDonXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 468);
            this.Controls.Add(this.hiddenLabel1);
            this.Controls.Add(this.saveXuatBt);
            this.Controls.Add(this.addItemBt);
            this.Controls.Add(this.lastPriceLabel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.quantity);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.unitPriceLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.productCbBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cusNameCbBox);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DGVNewXuatCT);
            this.Controls.Add(this.label1);
            this.Name = "FormCreateHoaDonXuat";
            this.Text = "Thêm mới chi tiết HD xuất";
            ((System.ComponentModel.ISupportInitialize)(this.DGVNewXuatCT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVNewXuatCT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cusNameCbBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox productCbBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label unitPriceLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown quantity;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lastPriceLabel;
        private System.Windows.Forms.Button addItemBt;
        private System.Windows.Forms.Button saveXuatBt;
        private System.Windows.Forms.Label hiddenLabel1;
    }
}
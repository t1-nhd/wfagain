namespace test
{
    partial class FormXuat
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
            this.dataGridXuat = new System.Windows.Forms.DataGridView();
            this.createXuatBt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridXuat)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(653, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sách xuất";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridXuat
            // 
            this.dataGridXuat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridXuat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridXuat.Location = new System.Drawing.Point(12, 99);
            this.dataGridXuat.Name = "dataGridXuat";
            this.dataGridXuat.Size = new System.Drawing.Size(653, 408);
            this.dataGridXuat.TabIndex = 1;
            this.dataGridXuat.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridXuat_RowHeaderMouseClick);
            // 
            // createXuatBt
            // 
            this.createXuatBt.Location = new System.Drawing.Point(590, 9);
            this.createXuatBt.Name = "createXuatBt";
            this.createXuatBt.Size = new System.Drawing.Size(75, 31);
            this.createXuatBt.TabIndex = 2;
            this.createXuatBt.Text = "Thêm";
            this.createXuatBt.UseVisualStyleBackColor = true;
            this.createXuatBt.Click += new System.EventHandler(this.createXuatBt_Click);
            // 
            // FormXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 519);
            this.Controls.Add(this.createXuatBt);
            this.Controls.Add(this.dataGridXuat);
            this.Controls.Add(this.label1);
            this.Name = "FormXuat";
            this.Text = "FormXuat";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridXuat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridXuat;
        private System.Windows.Forms.Button createXuatBt;
    }
}
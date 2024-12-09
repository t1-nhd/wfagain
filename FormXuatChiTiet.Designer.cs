namespace test
{
    partial class FormXuatChiTiet
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
            this.dataGridXuatCT = new System.Windows.Forms.DataGridView();
            this.cthdx_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridXuatCT)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridXuatCT
            // 
            this.dataGridXuatCT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridXuatCT.Location = new System.Drawing.Point(16, 156);
            this.dataGridXuatCT.Name = "dataGridXuatCT";
            this.dataGridXuatCT.Size = new System.Drawing.Size(560, 170);
            this.dataGridXuatCT.TabIndex = 0;
            // 
            // cthdx_label
            // 
            this.cthdx_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cthdx_label.Location = new System.Drawing.Point(12, 9);
            this.cthdx_label.Name = "cthdx_label";
            this.cthdx_label.Size = new System.Drawing.Size(564, 23);
            this.cthdx_label.TabIndex = 1;
            this.cthdx_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormXuatChiTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 338);
            this.Controls.Add(this.cthdx_label);
            this.Controls.Add(this.dataGridXuatCT);
            this.Name = "FormXuatChiTiet";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridXuatCT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridXuatCT;
        private System.Windows.Forms.Label cthdx_label;
    }
}
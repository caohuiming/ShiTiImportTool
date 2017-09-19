namespace ShiTiImportTool
{
    partial class FrmImport
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnShiTiImport = new System.Windows.Forms.Button();
            this.btnDownloadExcel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnShiJuanManage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnShiTiImport
            // 
            this.btnShiTiImport.Location = new System.Drawing.Point(83, 89);
            this.btnShiTiImport.Name = "btnShiTiImport";
            this.btnShiTiImport.Size = new System.Drawing.Size(75, 23);
            this.btnShiTiImport.TabIndex = 0;
            this.btnShiTiImport.Text = "试题导入";
            this.btnShiTiImport.UseVisualStyleBackColor = true;
            this.btnShiTiImport.Click += new System.EventHandler(this.btnShiTiImport_Click);
            // 
            // btnDownloadExcel
            // 
            this.btnDownloadExcel.Location = new System.Drawing.Point(83, 47);
            this.btnDownloadExcel.Name = "btnDownloadExcel";
            this.btnDownloadExcel.Size = new System.Drawing.Size(97, 23);
            this.btnDownloadExcel.TabIndex = 1;
            this.btnDownloadExcel.Text = "获取试题模板";
            this.btnDownloadExcel.UseVisualStyleBackColor = true;
            this.btnDownloadExcel.Click += new System.EventHandler(this.btnDownloadExcel_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(83, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnShiJuanManage
            // 
            this.btnShiJuanManage.Location = new System.Drawing.Point(83, 143);
            this.btnShiJuanManage.Name = "btnShiJuanManage";
            this.btnShiJuanManage.Size = new System.Drawing.Size(75, 23);
            this.btnShiJuanManage.TabIndex = 2;
            this.btnShiJuanManage.Text = "试卷管理";
            this.btnShiJuanManage.UseVisualStyleBackColor = true;
            this.btnShiJuanManage.Click += new System.EventHandler(this.btnShiJuanManage_Click);
            // 
            // FrmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnShiJuanManage);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDownloadExcel);
            this.Controls.Add(this.btnShiTiImport);
            this.Name = "FrmImport";
            this.Text = "试题导入";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShiTiImport;
        private System.Windows.Forms.Button btnDownloadExcel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnShiJuanManage;
    }
}


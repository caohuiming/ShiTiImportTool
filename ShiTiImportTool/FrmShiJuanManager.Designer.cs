namespace ShiTiImportTool
{
    partial class FrmShiJuanManager
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbCenter = new System.Windows.Forms.GroupBox();
            this.dgvShiJuan = new System.Windows.Forms.DataGridView();
            this.pnlCenter_Top = new System.Windows.Forms.Panel();
            this.lblRowMsg = new System.Windows.Forms.Label();
            this.lblRowNums = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnPre = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.lblAllPageNum = new System.Windows.Forms.Label();
            this.txtCurrentPage = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblPostTimeEnd = new System.Windows.Forms.Label();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.lblCreateTimeBegin = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnDownloadExcel = new System.Windows.Forms.Button();
            this.btnEditPwd = new System.Windows.Forms.Button();
            this.btnShiTiImport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtShiJuanName = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shiJuanName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.goToShiTi = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel1.SuspendLayout();
            this.gbCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShiJuan)).BeginInit();
            this.pnlCenter_Top.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbCenter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1018, 509);
            this.panel1.TabIndex = 49;
            // 
            // gbCenter
            // 
            this.gbCenter.Controls.Add(this.dgvShiJuan);
            this.gbCenter.Controls.Add(this.pnlCenter_Top);
            this.gbCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCenter.Location = new System.Drawing.Point(0, 0);
            this.gbCenter.Name = "gbCenter";
            this.gbCenter.Size = new System.Drawing.Size(1018, 509);
            this.gbCenter.TabIndex = 44;
            this.gbCenter.TabStop = false;
            this.gbCenter.Text = "试卷列表";
            // 
            // dgvShiJuan
            // 
            this.dgvShiJuan.AllowUserToAddRows = false;
            this.dgvShiJuan.AllowUserToDeleteRows = false;
            this.dgvShiJuan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShiJuan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.shiJuanName,
            this.cT,
            this.uT,
            this.delete,
            this.edit,
            this.goToShiTi});
            this.dgvShiJuan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShiJuan.Location = new System.Drawing.Point(3, 45);
            this.dgvShiJuan.Name = "dgvShiJuan";
            this.dgvShiJuan.ReadOnly = true;
            this.dgvShiJuan.RowHeadersWidth = 30;
            this.dgvShiJuan.RowTemplate.Height = 23;
            this.dgvShiJuan.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvShiJuan.Size = new System.Drawing.Size(1012, 461);
            this.dgvShiJuan.TabIndex = 33;
            this.dgvShiJuan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShiJuan_CellClick);
            this.dgvShiJuan.DoubleClick += new System.EventHandler(this.dgvShiJuan_DoubleClick);
            // 
            // pnlCenter_Top
            // 
            this.pnlCenter_Top.Controls.Add(this.lblRowMsg);
            this.pnlCenter_Top.Controls.Add(this.lblRowNums);
            this.pnlCenter_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCenter_Top.Location = new System.Drawing.Point(3, 17);
            this.pnlCenter_Top.Name = "pnlCenter_Top";
            this.pnlCenter_Top.Size = new System.Drawing.Size(1012, 28);
            this.pnlCenter_Top.TabIndex = 36;
            // 
            // lblRowMsg
            // 
            this.lblRowMsg.AutoSize = true;
            this.lblRowMsg.Location = new System.Drawing.Point(3, 8);
            this.lblRowMsg.Name = "lblRowMsg";
            this.lblRowMsg.Size = new System.Drawing.Size(89, 12);
            this.lblRowMsg.TabIndex = 34;
            this.lblRowMsg.Text = "当前查询结果：";
            // 
            // lblRowNums
            // 
            this.lblRowNums.AutoSize = true;
            this.lblRowNums.Location = new System.Drawing.Point(93, 8);
            this.lblRowNums.Name = "lblRowNums";
            this.lblRowNums.Size = new System.Drawing.Size(53, 12);
            this.lblRowNums.TabIndex = 35;
            this.lblRowNums.Text = "0 个试卷";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnPre);
            this.pnlBottom.Controls.Add(this.btnNext);
            this.pnlBottom.Controls.Add(this.label26);
            this.pnlBottom.Controls.Add(this.lblAllPageNum);
            this.pnlBottom.Controls.Add(this.txtCurrentPage);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 587);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1018, 45);
            this.pnlBottom.TabIndex = 48;
            // 
            // btnPre
            // 
            this.btnPre.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPre.Location = new System.Drawing.Point(712, 10);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(75, 23);
            this.btnPre.TabIndex = 38;
            this.btnPre.Text = "上一页";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNext.Location = new System.Drawing.Point(934, 10);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 39;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // label26
            // 
            this.label26.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(802, 15);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(29, 12);
            this.label26.TabIndex = 40;
            this.label26.Text = "跳至";
            // 
            // lblAllPageNum
            // 
            this.lblAllPageNum.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAllPageNum.AutoSize = true;
            this.lblAllPageNum.Location = new System.Drawing.Point(881, 15);
            this.lblAllPageNum.Name = "lblAllPageNum";
            this.lblAllPageNum.Size = new System.Drawing.Size(35, 12);
            this.lblAllPageNum.TabIndex = 42;
            this.lblAllPageNum.Text = "共1页";
            // 
            // txtCurrentPage
            // 
            this.txtCurrentPage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtCurrentPage.Location = new System.Drawing.Point(837, 10);
            this.txtCurrentPage.Name = "txtCurrentPage";
            this.txtCurrentPage.Size = new System.Drawing.Size(38, 21);
            this.txtCurrentPage.TabIndex = 41;
            this.txtCurrentPage.Text = "1";
            this.txtCurrentPage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCurrentPage_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(487, 22);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(83, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(299, 40);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(156, 21);
            this.dtpEnd.TabIndex = 22;
            // 
            // lblPostTimeEnd
            // 
            this.lblPostTimeEnd.AutoSize = true;
            this.lblPostTimeEnd.Location = new System.Drawing.Point(257, 44);
            this.lblPostTimeEnd.Name = "lblPostTimeEnd";
            this.lblPostTimeEnd.Size = new System.Drawing.Size(23, 12);
            this.lblPostTimeEnd.TabIndex = 21;
            this.lblPostTimeEnd.Text = "---";
            // 
            // dtpBegin
            // 
            this.dtpBegin.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBegin.Location = new System.Drawing.Point(80, 40);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(156, 21);
            this.dtpBegin.TabIndex = 20;
            // 
            // lblCreateTimeBegin
            // 
            this.lblCreateTimeBegin.AutoSize = true;
            this.lblCreateTimeBegin.Location = new System.Drawing.Point(10, 44);
            this.lblCreateTimeBegin.Name = "lblCreateTimeBegin";
            this.lblCreateTimeBegin.Size = new System.Drawing.Size(65, 12);
            this.lblCreateTimeBegin.TabIndex = 19;
            this.lblCreateTimeBegin.Text = "创建时间：";
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnDownloadExcel);
            this.pnlTop.Controls.Add(this.btnEditPwd);
            this.pnlTop.Controls.Add(this.btnShiTiImport);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.txtShiJuanName);
            this.pnlTop.Controls.Add(this.lblCreateTimeBegin);
            this.pnlTop.Controls.Add(this.dtpBegin);
            this.pnlTop.Controls.Add(this.lblPostTimeEnd);
            this.pnlTop.Controls.Add(this.dtpEnd);
            this.pnlTop.Controls.Add(this.btnSearch);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1018, 78);
            this.pnlTop.TabIndex = 47;
            // 
            // btnDownloadExcel
            // 
            this.btnDownloadExcel.Location = new System.Drawing.Point(603, 22);
            this.btnDownloadExcel.Name = "btnDownloadExcel";
            this.btnDownloadExcel.Size = new System.Drawing.Size(97, 23);
            this.btnDownloadExcel.TabIndex = 26;
            this.btnDownloadExcel.Text = "获取试题模板";
            this.btnDownloadExcel.UseVisualStyleBackColor = true;
            this.btnDownloadExcel.Click += new System.EventHandler(this.btnDownloadExcel_Click);
            // 
            // btnEditPwd
            // 
            this.btnEditPwd.Location = new System.Drawing.Point(855, 22);
            this.btnEditPwd.Name = "btnEditPwd";
            this.btnEditPwd.Size = new System.Drawing.Size(75, 23);
            this.btnEditPwd.TabIndex = 25;
            this.btnEditPwd.Text = "修改密码";
            this.btnEditPwd.UseVisualStyleBackColor = true;
            this.btnEditPwd.Click += new System.EventHandler(this.btnEditPwd_Click);
            // 
            // btnShiTiImport
            // 
            this.btnShiTiImport.Location = new System.Drawing.Point(737, 22);
            this.btnShiTiImport.Name = "btnShiTiImport";
            this.btnShiTiImport.Size = new System.Drawing.Size(75, 23);
            this.btnShiTiImport.TabIndex = 25;
            this.btnShiTiImport.Text = "试卷导入";
            this.btnShiTiImport.UseVisualStyleBackColor = true;
            this.btnShiTiImport.Click += new System.EventHandler(this.btnShiTiImport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "试卷名称：";
            // 
            // txtShiJuanName
            // 
            this.txtShiJuanName.Location = new System.Drawing.Point(80, 10);
            this.txtShiJuanName.Name = "txtShiJuanName";
            this.txtShiJuanName.Size = new System.Drawing.Size(375, 21);
            this.txtShiJuanName.TabIndex = 23;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "试卷编号";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // shiJuanName
            // 
            this.shiJuanName.DataPropertyName = "shiJuanName";
            this.shiJuanName.HeaderText = "试卷名称";
            this.shiJuanName.Name = "shiJuanName";
            this.shiJuanName.ReadOnly = true;
            this.shiJuanName.Width = 150;
            // 
            // cT
            // 
            this.cT.DataPropertyName = "cT";
            this.cT.HeaderText = "创建时间";
            this.cT.Name = "cT";
            this.cT.ReadOnly = true;
            this.cT.Width = 130;
            // 
            // uT
            // 
            this.uT.DataPropertyName = "uT";
            this.uT.HeaderText = "修改时间";
            this.uT.Name = "uT";
            this.uT.ReadOnly = true;
            // 
            // delete
            // 
            this.delete.HeaderText = "删除";
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Text = "删除";
            this.delete.UseColumnTextForLinkValue = true;
            // 
            // edit
            // 
            this.edit.HeaderText = "修改";
            this.edit.Name = "edit";
            this.edit.ReadOnly = true;
            this.edit.Text = "修改";
            this.edit.UseColumnTextForLinkValue = true;
            // 
            // goToShiTi
            // 
            this.goToShiTi.HeaderText = "查看试题";
            this.goToShiTi.Name = "goToShiTi";
            this.goToShiTi.ReadOnly = true;
            this.goToShiTi.Text = "查看试题";
            this.goToShiTi.UseColumnTextForLinkValue = true;
            // 
            // FrmShiJuanManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 632);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "FrmShiJuanManager";
            this.Text = "试卷管理";
            this.Load += new System.EventHandler(this.FrmShiJuanManager_Load);
            this.panel1.ResumeLayout(false);
            this.gbCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShiJuan)).EndInit();
            this.pnlCenter_Top.ResumeLayout(false);
            this.pnlCenter_Top.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbCenter;
        private System.Windows.Forms.DataGridView dgvShiJuan;
        private System.Windows.Forms.Panel pnlCenter_Top;
        private System.Windows.Forms.Label lblRowMsg;
        private System.Windows.Forms.Label lblRowNums;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblAllPageNum;
        private System.Windows.Forms.TextBox txtCurrentPage;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblPostTimeEnd;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.Label lblCreateTimeBegin;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtShiJuanName;
        private System.Windows.Forms.Button btnDownloadExcel;
        private System.Windows.Forms.Button btnShiTiImport;
        private System.Windows.Forms.Button btnEditPwd;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn shiJuanName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cT;
        private System.Windows.Forms.DataGridViewTextBoxColumn uT;
        private System.Windows.Forms.DataGridViewLinkColumn delete;
        private System.Windows.Forms.DataGridViewLinkColumn edit;
        private System.Windows.Forms.DataGridViewLinkColumn goToShiTi;
    }
}
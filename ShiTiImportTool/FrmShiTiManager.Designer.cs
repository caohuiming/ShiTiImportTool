namespace ShiTiImportTool
{
    partial class FrmShiTiManager
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
            this.txtZhengWen = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbCenter = new System.Windows.Forms.GroupBox();
            this.dgvShiTi = new System.Windows.Forms.DataGridView();
            this.pnlCenter_Top = new System.Windows.Forms.Panel();
            this.lblRowMsg = new System.Windows.Forms.Label();
            this.lblRowNums = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.lblAllPageNum = new System.Windows.Forms.Label();
            this.txtCurrentPage = new System.Windows.Forms.TextBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblShiJuanName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTiXing = new System.Windows.Forms.ComboBox();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shiJuanId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bianHao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiXing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zhengWen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xuanXiang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.daAn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.daAnJieXi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.panel1.SuspendLayout();
            this.gbCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShiTi)).BeginInit();
            this.pnlCenter_Top.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtZhengWen
            // 
            this.txtZhengWen.Location = new System.Drawing.Point(80, 48);
            this.txtZhengWen.Name = "txtZhengWen";
            this.txtZhengWen.Size = new System.Drawing.Size(375, 21);
            this.txtZhengWen.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbCenter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1018, 509);
            this.panel1.TabIndex = 52;
            // 
            // gbCenter
            // 
            this.gbCenter.Controls.Add(this.dgvShiTi);
            this.gbCenter.Controls.Add(this.pnlCenter_Top);
            this.gbCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCenter.Location = new System.Drawing.Point(0, 0);
            this.gbCenter.Name = "gbCenter";
            this.gbCenter.Size = new System.Drawing.Size(1018, 509);
            this.gbCenter.TabIndex = 44;
            this.gbCenter.TabStop = false;
            this.gbCenter.Text = "试题列表";
            // 
            // dgvShiTi
            // 
            this.dgvShiTi.AllowUserToAddRows = false;
            this.dgvShiTi.AllowUserToDeleteRows = false;
            this.dgvShiTi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShiTi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.shiJuanId,
            this.bianHao,
            this.tiXing,
            this.zhengWen,
            this.xuanXiang,
            this.daAn,
            this.daAnJieXi,
            this.delete});
            this.dgvShiTi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShiTi.Location = new System.Drawing.Point(3, 45);
            this.dgvShiTi.Name = "dgvShiTi";
            this.dgvShiTi.ReadOnly = true;
            this.dgvShiTi.RowHeadersWidth = 30;
            this.dgvShiTi.RowTemplate.Height = 23;
            this.dgvShiTi.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvShiTi.Size = new System.Drawing.Size(1012, 461);
            this.dgvShiTi.TabIndex = 33;
            this.dgvShiTi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShiTi_CellClick);
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
            this.lblRowNums.Text = "0 道试题";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(512, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(83, 32);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            this.pnlBottom.TabIndex = 51;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.label4);
            this.pnlTop.Controls.Add(this.cmbTiXing);
            this.pnlTop.Controls.Add(this.lblShiJuanName);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.txtZhengWen);
            this.pnlTop.Controls.Add(this.btnSearch);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1018, 78);
            this.pnlTop.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "试题正文：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 25;
            this.label2.Text = "当前试卷：";
            // 
            // lblShiJuanName
            // 
            this.lblShiJuanName.AutoSize = true;
            this.lblShiJuanName.Location = new System.Drawing.Point(70, 13);
            this.lblShiJuanName.Name = "lblShiJuanName";
            this.lblShiJuanName.Size = new System.Drawing.Size(53, 12);
            this.lblShiJuanName.TabIndex = 26;
            this.lblShiJuanName.Text = "试卷名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(256, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 31;
            this.label4.Text = "题型：";
            // 
            // cmbTiXing
            // 
            this.cmbTiXing.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTiXing.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTiXing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTiXing.FormattingEnabled = true;
            this.cmbTiXing.Location = new System.Drawing.Point(303, 10);
            this.cmbTiXing.Name = "cmbTiXing";
            this.cmbTiXing.Size = new System.Drawing.Size(153, 20);
            this.cmbTiXing.TabIndex = 32;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "试题编号";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // shiJuanId
            // 
            this.shiJuanId.DataPropertyName = "shiJuanId";
            this.shiJuanId.HeaderText = "试卷编号";
            this.shiJuanId.Name = "shiJuanId";
            this.shiJuanId.ReadOnly = true;
            // 
            // bianHao
            // 
            this.bianHao.DataPropertyName = "bianHao";
            this.bianHao.HeaderText = "编号";
            this.bianHao.Name = "bianHao";
            this.bianHao.ReadOnly = true;
            // 
            // tiXing
            // 
            this.tiXing.DataPropertyName = "tiXing";
            this.tiXing.HeaderText = "题型";
            this.tiXing.Name = "tiXing";
            this.tiXing.ReadOnly = true;
            this.tiXing.Width = 150;
            // 
            // zhengWen
            // 
            this.zhengWen.DataPropertyName = "zhengWen";
            this.zhengWen.HeaderText = "正文";
            this.zhengWen.Name = "zhengWen";
            this.zhengWen.ReadOnly = true;
            this.zhengWen.Width = 130;
            // 
            // xuanXiang
            // 
            this.xuanXiang.DataPropertyName = "xuanXiang";
            this.xuanXiang.HeaderText = "选项";
            this.xuanXiang.Name = "xuanXiang";
            this.xuanXiang.ReadOnly = true;
            // 
            // daAn
            // 
            this.daAn.DataPropertyName = "daAn";
            this.daAn.HeaderText = "答案";
            this.daAn.Name = "daAn";
            this.daAn.ReadOnly = true;
            // 
            // daAnJieXi
            // 
            this.daAnJieXi.DataPropertyName = "daAnJieXi";
            this.daAnJieXi.HeaderText = "答案解析";
            this.daAnJieXi.Name = "daAnJieXi";
            this.daAnJieXi.ReadOnly = true;
            // 
            // delete
            // 
            this.delete.HeaderText = "删除";
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Text = "删除";
            this.delete.UseColumnTextForLinkValue = true;
            // 
            // FrmShiTiManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 632);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "FrmShiTiManager";
            this.Text = "试题管理";
            this.Load += new System.EventHandler(this.FrmShiTiManager_Load);
            this.panel1.ResumeLayout(false);
            this.gbCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShiTi)).EndInit();
            this.pnlCenter_Top.ResumeLayout(false);
            this.pnlCenter_Top.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtZhengWen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbCenter;
        private System.Windows.Forms.DataGridView dgvShiTi;
        private System.Windows.Forms.Panel pnlCenter_Top;
        private System.Windows.Forms.Label lblRowMsg;
        private System.Windows.Forms.Label lblRowNums;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblAllPageNum;
        private System.Windows.Forms.TextBox txtCurrentPage;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblShiJuanName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTiXing;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn shiJuanId;
        private System.Windows.Forms.DataGridViewTextBoxColumn bianHao;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiXing;
        private System.Windows.Forms.DataGridViewTextBoxColumn zhengWen;
        private System.Windows.Forms.DataGridViewTextBoxColumn xuanXiang;
        private System.Windows.Forms.DataGridViewTextBoxColumn daAn;
        private System.Windows.Forms.DataGridViewTextBoxColumn daAnJieXi;
        private System.Windows.Forms.DataGridViewLinkColumn delete;
    }
}
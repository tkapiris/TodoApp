namespace TodoApp.Win
{
    partial class Main
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.AddBtn = new System.Windows.Forms.Button();
            this.FinishBtn = new System.Windows.Forms.Button();
            this.TitleTxt = new System.Windows.Forms.TextBox();
            this.TodoGV = new System.Windows.Forms.DataGridView();
            this.DetailLbl = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FinishLb = new System.Windows.Forms.Label();
            this.StartLb = new System.Windows.Forms.Label();
            this.FinishDt = new System.Windows.Forms.DateTimePicker();
            this.StartDt = new System.Windows.Forms.DateTimePicker();
            this.TodoCommentsGv = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TodoGV)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TodoCommentsGv)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TodoGV, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.DetailLbl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1435, 845);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Controls.Add(this.AddBtn, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.FinishBtn, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.TitleTxt, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(998, 35);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(3, 3);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(94, 29);
            this.AddBtn.TabIndex = 0;
            this.AddBtn.Text = "Add";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // FinishBtn
            // 
            this.FinishBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.FinishBtn.Location = new System.Drawing.Point(901, 3);
            this.FinishBtn.Name = "FinishBtn";
            this.FinishBtn.Size = new System.Drawing.Size(94, 29);
            this.FinishBtn.TabIndex = 1;
            this.FinishBtn.Text = "Complete";
            this.FinishBtn.UseVisualStyleBackColor = true;
            this.FinishBtn.Click += new System.EventHandler(this.FinishBtn_Click);
            // 
            // TitleTxt
            // 
            this.TitleTxt.Location = new System.Drawing.Point(103, 3);
            this.TitleTxt.Name = "TitleTxt";
            this.TitleTxt.Size = new System.Drawing.Size(404, 27);
            this.TitleTxt.TabIndex = 2;
            // 
            // TodoGV
            // 
            this.TodoGV.AllowUserToAddRows = false;
            this.TodoGV.AllowUserToDeleteRows = false;
            this.TodoGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TodoGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TodoGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.TodoGV.Location = new System.Drawing.Point(3, 44);
            this.TodoGV.MultiSelect = false;
            this.TodoGV.Name = "TodoGV";
            this.TodoGV.ReadOnly = true;
            this.TodoGV.RowHeadersWidth = 51;
            this.TodoGV.RowTemplate.Height = 29;
            this.TodoGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TodoGV.Size = new System.Drawing.Size(998, 798);
            this.TodoGV.TabIndex = 0;
            this.TodoGV.SelectionChanged += new System.EventHandler(this.TodoGV_SelectionChanged);
            // 
            // DetailLbl
            // 
            this.DetailLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DetailLbl.AutoSize = true;
            this.DetailLbl.Location = new System.Drawing.Point(1173, 10);
            this.DetailLbl.Name = "DetailLbl";
            this.DetailLbl.Size = new System.Drawing.Size(93, 20);
            this.DetailLbl.TabIndex = 2;
            this.DetailLbl.Text = "Todo Details";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.TodoCommentsGv, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1007, 44);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(425, 798);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.FinishLb);
            this.panel1.Controls.Add(this.StartLb);
            this.panel1.Controls.Add(this.FinishDt);
            this.panel1.Controls.Add(this.StartDt);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 131);
            this.panel1.TabIndex = 1;
            // 
            // FinishLb
            // 
            this.FinishLb.AutoSize = true;
            this.FinishLb.Location = new System.Drawing.Point(72, 69);
            this.FinishLb.Name = "FinishLb";
            this.FinishLb.Size = new System.Drawing.Size(85, 20);
            this.FinishLb.TabIndex = 3;
            this.FinishLb.Text = "Finish Date:";
            // 
            // StartLb
            // 
            this.StartLb.AutoSize = true;
            this.StartLb.Location = new System.Drawing.Point(78, 34);
            this.StartLb.Name = "StartLb";
            this.StartLb.Size = new System.Drawing.Size(79, 20);
            this.StartLb.TabIndex = 2;
            this.StartLb.Text = "Start Date:";
            // 
            // FinishDt
            // 
            this.FinishDt.Enabled = false;
            this.FinishDt.Location = new System.Drawing.Point(163, 62);
            this.FinishDt.Name = "FinishDt";
            this.FinishDt.Size = new System.Drawing.Size(250, 27);
            this.FinishDt.TabIndex = 1;
            // 
            // StartDt
            // 
            this.StartDt.Enabled = false;
            this.StartDt.Location = new System.Drawing.Point(163, 29);
            this.StartDt.Name = "StartDt";
            this.StartDt.Size = new System.Drawing.Size(250, 27);
            this.StartDt.TabIndex = 0;
            // 
            // TodoCommentsGv
            // 
            this.TodoCommentsGv.AllowUserToAddRows = false;
            this.TodoCommentsGv.AllowUserToDeleteRows = false;
            this.TodoCommentsGv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TodoCommentsGv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TodoCommentsGv.Location = new System.Drawing.Point(3, 140);
            this.TodoCommentsGv.Name = "TodoCommentsGv";
            this.TodoCommentsGv.ReadOnly = true;
            this.TodoCommentsGv.RowHeadersWidth = 51;
            this.TodoCommentsGv.RowTemplate.Height = 29;
            this.TodoCommentsGv.Size = new System.Drawing.Size(419, 655);
            this.TodoCommentsGv.TabIndex = 2;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1456, 866);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(350, 300);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TodoGV)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TodoCommentsGv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView TodoGV;
        private TableLayoutPanel tableLayoutPanel2;
        private Button AddBtn;
        private Button FinishBtn;
        private TextBox TitleTxt;
        private Label DetailLbl;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel panel1;
        private Label FinishLb;
        private Label StartLb;
        private DateTimePicker FinishDt;
        private DateTimePicker StartDt;
        private DataGridView TodoCommentsGv;
    }
}
namespace MuteSound
{
    partial class config
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
            this.lbProcc = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btRegister = new System.Windows.Forms.Button();
            this.lvBinds = new System.Windows.Forms.ListView();
            this.chProcces = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chHotkey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btAdd = new System.Windows.Forms.Button();
            this.tbProcc = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btRemove = new System.Windows.Forms.Button();
            this.btRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbProcc
            // 
            this.lbProcc.FormattingEnabled = true;
            this.lbProcc.Location = new System.Drawing.Point(12, 13);
            this.lbProcc.Name = "lbProcc";
            this.lbProcc.Size = new System.Drawing.Size(119, 277);
            this.lbProcc.Sorted = true;
            this.lbProcc.TabIndex = 0;
            this.lbProcc.Click += new System.EventHandler(this.lbProcc_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btRegister);
            this.groupBox1.Location = new System.Drawing.Point(137, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(115, 110);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hotkeys";
            // 
            // btRegister
            // 
            this.btRegister.Location = new System.Drawing.Point(6, 19);
            this.btRegister.Name = "btRegister";
            this.btRegister.Size = new System.Drawing.Size(99, 72);
            this.btRegister.TabIndex = 5;
            this.btRegister.Text = "Register HotKey";
            this.btRegister.UseVisualStyleBackColor = true;
            this.btRegister.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btRegister_KeyDown);
            // 
            // lvBinds
            // 
            this.lvBinds.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chProcces,
            this.chHotkey});
            this.lvBinds.FullRowSelect = true;
            this.lvBinds.Location = new System.Drawing.Point(258, 21);
            this.lvBinds.Name = "lvBinds";
            this.lvBinds.Size = new System.Drawing.Size(156, 269);
            this.lvBinds.TabIndex = 2;
            this.lvBinds.UseCompatibleStateImageBehavior = false;
            this.lvBinds.View = System.Windows.Forms.View.Details;
            // 
            // chProcces
            // 
            this.chProcces.Text = "Procces";
            // 
            // chHotkey
            // 
            this.chHotkey.Text = "Hotkey";
            this.chHotkey.Width = 92;
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(141, 171);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(111, 24);
            this.btAdd.TabIndex = 3;
            this.btAdd.Text = "Add";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // tbProcc
            // 
            this.tbProcc.Location = new System.Drawing.Point(141, 145);
            this.tbProcc.Name = "tbProcc";
            this.tbProcc.Size = new System.Drawing.Size(111, 20);
            this.tbProcc.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(258, 293);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 20);
            this.button1.TabIndex = 5;
            this.button1.Text = "Done";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btRemove
            // 
            this.btRemove.Location = new System.Drawing.Point(141, 201);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(111, 24);
            this.btRemove.TabIndex = 6;
            this.btRemove.Text = "Remove";
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // btRefresh
            // 
            this.btRefresh.Location = new System.Drawing.Point(12, 293);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(119, 20);
            this.btRefresh.TabIndex = 7;
            this.btRefresh.Text = "Refresh";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Processname";
            // 
            // config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 323);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbProcc);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.lvBinds);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbProcc);
            this.Name = "config";
            this.Text = "config";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbProcc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvBinds;
        private System.Windows.Forms.ColumnHeader chProcces;
        private System.Windows.Forms.ColumnHeader chHotkey;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.TextBox tbProcc;
        private System.Windows.Forms.Button btRegister;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.Label label1;
    }
}
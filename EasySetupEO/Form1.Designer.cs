namespace easysetup
{
    partial class mainwindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Add the TextBox control declarations for Server Name and Server IP.
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.TextBox txtServerIP;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainwindow));
            servername = new GroupBox();
            label1 = new Label();
            txtServerName = new TextBox();
            serverip = new GroupBox();
            label2 = new Label();
            txtServerIP = new TextBox();
            serverport = new GroupBox();
            txtmsgport = new TextBox();
            txtnpcport = new TextBox();
            txtloginport = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            savebtn = new Button();
            groupBox1 = new GroupBox();
            txtdbpass = new TextBox();
            txtdbuser = new TextBox();
            txtdbname = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            btncrtoem = new Button();
            servername.SuspendLayout();
            serverip.SuspendLayout();
            serverport.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // servername
            // 
            servername.Controls.Add(label1);
            servername.Controls.Add(txtServerName);
            servername.Location = new Point(14, 14);
            servername.Margin = new Padding(4, 3, 4, 3);
            servername.Name = "servername";
            servername.Padding = new Padding(4, 3, 4, 3);
            servername.Size = new Size(266, 62);
            servername.TabIndex = 0;
            servername.TabStop = false;
            servername.Text = "Server Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 25);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 1;
            label1.Text = "Server Name :";
            // 
            // txtServerName
            // 
            txtServerName.Location = new Point(108, 22);
            txtServerName.Margin = new Padding(4, 3, 4, 3);
            txtServerName.Name = "txtServerName";
            txtServerName.Size = new Size(134, 23);
            txtServerName.TabIndex = 0;
            // 
            // serverip
            // 
            serverip.Controls.Add(label2);
            serverip.Controls.Add(txtServerIP);
            serverip.Location = new Point(14, 83);
            serverip.Margin = new Padding(4, 3, 4, 3);
            serverip.Name = "serverip";
            serverip.Padding = new Padding(4, 3, 4, 3);
            serverip.Size = new Size(266, 62);
            serverip.TabIndex = 1;
            serverip.TabStop = false;
            serverip.Text = "Server IP";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 25);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 1;
            label2.Text = "Server IP :";
            // 
            // txtServerIP
            // 
            txtServerIP.Location = new Point(108, 22);
            txtServerIP.Margin = new Padding(4, 3, 4, 3);
            txtServerIP.Name = "txtServerIP";
            txtServerIP.Size = new Size(134, 23);
            txtServerIP.TabIndex = 0;
            // 
            // serverport
            // 
            serverport.Controls.Add(txtmsgport);
            serverport.Controls.Add(txtnpcport);
            serverport.Controls.Add(txtloginport);
            serverport.Controls.Add(label5);
            serverport.Controls.Add(label4);
            serverport.Controls.Add(label3);
            serverport.Location = new Point(14, 152);
            serverport.Margin = new Padding(4, 3, 4, 3);
            serverport.Name = "serverport";
            serverport.Padding = new Padding(4, 3, 4, 3);
            serverport.Size = new Size(266, 122);
            serverport.TabIndex = 2;
            serverport.TabStop = false;
            serverport.Text = "Server Port";
            // 
            // txtmsgport
            // 
            txtmsgport.Location = new Point(108, 52);
            txtmsgport.Margin = new Padding(4, 3, 4, 3);
            txtmsgport.Name = "txtmsgport";
            txtmsgport.Size = new Size(134, 23);
            txtmsgport.TabIndex = 5;
            // 
            // txtnpcport
            // 
            txtnpcport.Location = new Point(108, 82);
            txtnpcport.Margin = new Padding(4, 3, 4, 3);
            txtnpcport.Name = "txtnpcport";
            txtnpcport.Size = new Size(134, 23);
            txtnpcport.TabIndex = 4;
            // 
            // txtloginport
            // 
            txtloginport.Location = new Point(108, 22);
            txtloginport.Margin = new Padding(4, 3, 4, 3);
            txtloginport.Name = "txtloginport";
            txtloginport.Size = new Size(134, 23);
            txtloginport.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(31, 85);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 2;
            label5.Text = "NPC Port :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 59);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 1;
            label4.Text = "MSG Port :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 31);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(68, 15);
            label3.TabIndex = 0;
            label3.Text = "Login Port :";
            // 
            // savebtn
            // 
            savebtn.Location = new Point(149, 440);
            savebtn.Margin = new Padding(4, 3, 4, 3);
            savebtn.Name = "savebtn";
            savebtn.Size = new Size(131, 57);
            savebtn.TabIndex = 3;
            savebtn.Text = "Save";
            savebtn.UseVisualStyleBackColor = true;
            savebtn.Click += savebtn_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtdbpass);
            groupBox1.Controls.Add(txtdbuser);
            groupBox1.Controls.Add(txtdbname);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Location = new Point(14, 282);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(266, 138);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Database Connection";
            // 
            // txtdbpass
            // 
            txtdbpass.Location = new Point(108, 93);
            txtdbpass.Margin = new Padding(4, 3, 4, 3);
            txtdbpass.Name = "txtdbpass";
            txtdbpass.Size = new Size(134, 23);
            txtdbpass.TabIndex = 5;
            // 
            // txtdbuser
            // 
            txtdbuser.Location = new Point(108, 63);
            txtdbuser.Margin = new Padding(4, 3, 4, 3);
            txtdbuser.Name = "txtdbuser";
            txtdbuser.Size = new Size(134, 23);
            txtdbuser.TabIndex = 4;
            // 
            // txtdbname
            // 
            txtdbname.Location = new Point(108, 31);
            txtdbname.Margin = new Padding(4, 3, 4, 3);
            txtdbname.Name = "txtdbname";
            txtdbname.Size = new Size(134, 23);
            txtdbname.TabIndex = 3;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(29, 97);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(63, 15);
            label8.TabIndex = 2;
            label8.Text = "Password :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(27, 67);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(66, 15);
            label7.TabIndex = 1;
            label7.Text = "Username :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(29, 35);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(61, 15);
            label6.TabIndex = 0;
            label6.Text = "Database :";
            // 
            // btncrtoem
            // 
            btncrtoem.Location = new Point(14, 440);
            btncrtoem.Margin = new Padding(4, 3, 4, 3);
            btncrtoem.Name = "btncrtoem";
            btncrtoem.Size = new Size(128, 57);
            btncrtoem.TabIndex = 5;
            btncrtoem.Text = "Create Oem.dat";
            btncrtoem.UseVisualStyleBackColor = true;
            btncrtoem.Click += btncrtoem_Click;
            // 
            // mainwindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 517);
            Controls.Add(btncrtoem);
            Controls.Add(groupBox1);
            Controls.Add(savebtn);
            Controls.Add(serverport);
            Controls.Add(serverip);
            Controls.Add(servername);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "mainwindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Easy Setup EO";
            Load += mainwindow_Load;
            servername.ResumeLayout(false);
            servername.PerformLayout();
            serverip.ResumeLayout(false);
            serverip.PerformLayout();
            serverport.ResumeLayout(false);
            serverport.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox servername;
        private System.Windows.Forms.GroupBox serverip;
        private System.Windows.Forms.GroupBox serverport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.TextBox txtmsgport;
        private System.Windows.Forms.TextBox txtnpcport;
        private System.Windows.Forms.TextBox txtloginport;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtdbpass;
        private System.Windows.Forms.TextBox txtdbuser;
        private System.Windows.Forms.TextBox txtdbname;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btncrtoem;
    }
}

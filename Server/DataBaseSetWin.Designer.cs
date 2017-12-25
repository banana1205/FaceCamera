namespace Server
{
    partial class DataBaseSetWin
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
            this.tb_Server = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_DataBase = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_uid = new System.Windows.Forms.TextBox();
            this.tb_pwd = new System.Windows.Forms.TextBox();
            this.btn_testConnection = new System.Windows.Forms.Button();
            this.btn_use = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // tb_Server
            // 
            this.tb_Server.Location = new System.Drawing.Point(100, 39);
            this.tb_Server.Name = "tb_Server";
            this.tb_Server.Size = new System.Drawing.Size(245, 21);
            this.tb_Server.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "DataBase";
            // 
            // tb_DataBase
            // 
            this.tb_DataBase.Location = new System.Drawing.Point(100, 81);
            this.tb_DataBase.Name = "tb_DataBase";
            this.tb_DataBase.Size = new System.Drawing.Size(245, 21);
            this.tb_DataBase.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "用户名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "密码";
            // 
            // tb_uid
            // 
            this.tb_uid.Location = new System.Drawing.Point(100, 117);
            this.tb_uid.Name = "tb_uid";
            this.tb_uid.Size = new System.Drawing.Size(100, 21);
            this.tb_uid.TabIndex = 6;
            // 
            // tb_pwd
            // 
            this.tb_pwd.Location = new System.Drawing.Point(100, 149);
            this.tb_pwd.Name = "tb_pwd";
            this.tb_pwd.Size = new System.Drawing.Size(100, 21);
            this.tb_pwd.TabIndex = 7;
            // 
            // btn_testConnection
            // 
            this.btn_testConnection.Location = new System.Drawing.Point(100, 194);
            this.btn_testConnection.Name = "btn_testConnection";
            this.btn_testConnection.Size = new System.Drawing.Size(75, 23);
            this.btn_testConnection.TabIndex = 8;
            this.btn_testConnection.Text = "测试连接";
            this.btn_testConnection.UseVisualStyleBackColor = true;
            this.btn_testConnection.Click += new System.EventHandler(this.btn_testConnection_Click);
            // 
            // btn_use
            // 
            this.btn_use.Location = new System.Drawing.Point(100, 248);
            this.btn_use.Name = "btn_use";
            this.btn_use.Size = new System.Drawing.Size(75, 23);
            this.btn_use.TabIndex = 9;
            this.btn_use.Text = "应用";
            this.btn_use.UseVisualStyleBackColor = true;
            this.btn_use.Click += new System.EventHandler(this.btn_use_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(181, 248);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 10;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // DataBaseSetWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 315);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_use);
            this.Controls.Add(this.btn_testConnection);
            this.Controls.Add(this.tb_pwd);
            this.Controls.Add(this.tb_uid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_DataBase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_Server);
            this.Controls.Add(this.label1);
            this.Name = "DataBaseSetWin";
            this.Text = "DataBaseSetWin";
            this.Load += new System.EventHandler(this.DataBaseSetWin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Server;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_DataBase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_uid;
        private System.Windows.Forms.TextBox tb_pwd;
        private System.Windows.Forms.Button btn_testConnection;
        private System.Windows.Forms.Button btn_use;
        private System.Windows.Forms.Button btn_Cancel;
    }
}
﻿using System.Windows.Forms;
namespace uReclutmentWinForm
{
    partial class LogIn
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
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.lblLoading = new System.Windows.Forms.Label();
            this.iconCLose = new FontAwesome.Sharp.IconPictureBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnRegistration = new System.Windows.Forms.Button();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblRegistration = new System.Windows.Forms.LinkLabel();
            this.lblToLogIn = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblReset = new System.Windows.Forms.LinkLabel();
            this.lblChangePassword = new System.Windows.Forms.LinkLabel();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.iconCLose)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(225, 186);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(130, 20);
            this.txtUser.TabIndex = 0;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(164, 189);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(63, 13);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "User Name:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(171, 221);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(225, 218);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(130, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // btnLogIn
            // 
            this.btnLogIn.Location = new System.Drawing.Point(184, 262);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(135, 41);
            this.btnLogIn.TabIndex = 4;
            this.btnLogIn.Text = "LogIn";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold);
            this.lblLoading.Location = new System.Drawing.Point(6, 354);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(104, 29);
            this.lblLoading.TabIndex = 5;
            this.lblLoading.Text = "Loading...";
            this.lblLoading.Visible = false;
            // 
            // iconCLose
            // 
            this.iconCLose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconCLose.BackColor = System.Drawing.SystemColors.Control;
            this.iconCLose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconCLose.ForeColor = System.Drawing.Color.Red;
            this.iconCLose.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.iconCLose.IconColor = System.Drawing.Color.Red;
            this.iconCLose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCLose.IconSize = 27;
            this.iconCLose.Location = new System.Drawing.Point(477, 3);
            this.iconCLose.Name = "iconCLose";
            this.iconCLose.Size = new System.Drawing.Size(27, 28);
            this.iconCLose.TabIndex = 6;
            this.iconCLose.TabStop = false;
            this.iconCLose.Click += new System.EventHandler(this.iconCLose_Click);
            // 
            // panelTop
            // 
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(479, 29);
            this.panelTop.TabIndex = 7;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseDown);
            this.panelTop.MouseHover += new System.EventHandler(this.panelTop_MouseHover);
            // 
            // btnRegistration
            // 
            this.btnRegistration.Location = new System.Drawing.Point(184, 293);
            this.btnRegistration.Name = "btnRegistration";
            this.btnRegistration.Size = new System.Drawing.Size(135, 41);
            this.btnRegistration.TabIndex = 8;
            this.btnRegistration.Text = "Registration";
            this.btnRegistration.UseVisualStyleBackColor = true;
            this.btnRegistration.Visible = false;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(189, 256);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Email:";
            this.lblEmail.Visible = false;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(225, 253);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '*';
            this.txtEmail.Size = new System.Drawing.Size(130, 20);
            this.txtEmail.TabIndex = 9;
            this.txtEmail.Visible = false;
            // 
            // lblRegistration
            // 
            this.lblRegistration.AutoSize = true;
            this.lblRegistration.Location = new System.Drawing.Point(349, 276);
            this.lblRegistration.Name = "lblRegistration";
            this.lblRegistration.Size = new System.Drawing.Size(63, 13);
            this.lblRegistration.TabIndex = 11;
            this.lblRegistration.TabStop = true;
            this.lblRegistration.Text = "Registration";
            this.lblRegistration.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblToLogIn
            // 
            this.lblToLogIn.AutoSize = true;
            this.lblToLogIn.Location = new System.Drawing.Point(349, 307);
            this.lblToLogIn.Name = "lblToLogIn";
            this.lblToLogIn.Size = new System.Drawing.Size(50, 13);
            this.lblToLogIn.TabIndex = 12;
            this.lblToLogIn.TabStop = true;
            this.lblToLogIn.Text = "To LogIn";
            this.lblToLogIn.Visible = false;
            this.lblToLogIn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblToLogIn_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::uReclutmentWinForm.Properties.Resources.MainImage;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(183, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(171, 133);
            this.panel1.TabIndex = 13;
            // 
            // lblReset
            // 
            this.lblReset.AutoSize = true;
            this.lblReset.Location = new System.Drawing.Point(349, 293);
            this.lblReset.Name = "lblReset";
            this.lblReset.Size = new System.Drawing.Size(84, 13);
            this.lblReset.TabIndex = 14;
            this.lblReset.TabStop = true;
            this.lblReset.Text = "Reset Password";
            this.lblReset.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblReset_LinkClicked);
            // 
            // lblChangePassword
            // 
            this.lblChangePassword.AutoSize = true;
            this.lblChangePassword.Location = new System.Drawing.Point(414, 276);
            this.lblChangePassword.Name = "lblChangePassword";
            this.lblChangePassword.Size = new System.Drawing.Size(93, 13);
            this.lblChangePassword.TabIndex = 15;
            this.lblChangePassword.TabStop = true;
            this.lblChangePassword.Text = "Change Password";
            this.lblChangePassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblChangePassword_LinkClicked);
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Location = new System.Drawing.Point(147, 256);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(81, 13);
            this.lblNewPassword.TabIndex = 17;
            this.lblNewPassword.Text = "New Password:";
            this.lblNewPassword.Visible = false;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(225, 253);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(130, 20);
            this.txtNewPassword.TabIndex = 16;
            this.txtNewPassword.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(183, 293);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(135, 41);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 387);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.lblChangePassword);
            this.Controls.Add(this.lblReset);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblToLogIn);
            this.Controls.Add(this.lblRegistration);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnRegistration);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.iconCLose);
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogIn";
            this.Load += new System.EventHandler(this.LogIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iconCLose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtUser;
        private Label lblUserName;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogIn;
        private Label lblLoading;
        private FontAwesome.Sharp.IconPictureBox iconCLose;
        private Panel panelTop;
        private Button btnRegistration;
        private Label lblEmail;
        private TextBox txtEmail;
        private LinkLabel lblRegistration;
        private LinkLabel lblToLogIn;
        private Panel panel1;
        private LinkLabel lblReset;
        private LinkLabel lblChangePassword;
        private Label lblNewPassword;
        private TextBox txtNewPassword;
        private Button btnSave;
    }
}
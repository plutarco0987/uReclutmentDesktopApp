using Entities;
using Entities.DataContext;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using uReclutmentConfigurations.Control;
using MessageBox = System.Windows.Forms.MessageBox;
using User = Entities.DataContext.User;

namespace uReclutmentConfigurations
{
    public partial class LogIn : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr intPtr, int wMsg, int wParam, int lParam);

        public LogIn()
        {
            //get the settitngs            
            getSettings();

            InitializeComponent();
            txtUser.Focus();
            this.AcceptButton = btnLogIn;
        }

        private async void getSettings() {
            string result = await ApiControl<Settings>.Get(Program.BaseUrl + "Settings/GetAllSettings");
            FormatData<Settings> information = new FormatData<Settings>();
            if(result!= "")
            {
                information = JsonSerializer.Deserialize<FormatData<Settings>>(result);
                if (Program.Settings != null)
                {
                    Program.Settings.Clear();
                }
                foreach (var item in information.Data)
                {
                    Program.Settings.Add(item.Name, item.Value);
                }
            }                        
        }
     

        private async void btnLogIn_Click(object sender, EventArgs e)
        {
            lblLoading.Visible = true;
            string errorMessage = string.Empty;
            if (txtUser.Text == string.Empty)
                errorMessage = "Please add one username";
            else if (txtPassword.Text == string.Empty)
                errorMessage = "Please add the password";
            if (txtUser.Text.Length == 0 && txtPassword.Text.Length == 0)
                errorMessage = "Please enter the information";

            if (errorMessage == string.Empty)
            {
                string result;
                //is require send the email aux for can get the information good 
                User user = new User()
                {
                    UserName = txtUser.Text,
                    Password = Program.Encrypt(txtPassword.Text.ToString()),
                    Email="Email@test.com"
                };

                try
                {
                    result = await ApiControl<User>.Post(Program.BaseUrl + "User/Validation", user);
                    FormatData<bool> information = new FormatData<bool>();
                    if(result != string.Empty)
                    {
                        information = JsonSerializer.Deserialize<FormatData<bool>>(result);

                        if (information.ErrorLocation == string.Empty || information.ErrorLocation == null)
                        {
                            if (information.Data.First())
                            {
                                Program.LoginUser = user.UserName;
                                //go to mainview                            
                                this.Hide();
                                MainView mainView = new MainView();
                                mainView.Show();
                            }
                            else
                            {
                                MessageBox.Show("The user or the password is grong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show(information.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Server is not working", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                }
            }
            else
            {
                MessageBox.Show(errorMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            lblLoading.Visible = false;
        }

        private void iconCLose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panelTop_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblEmail.Visible = true;
            txtEmail.Visible = true;
            lblToLogIn.Visible = true;
            lblRegistration.Visible = false;
            btnLogIn.Visible = false;
            btnRegistration.Visible = true;
            lblReset.Visible = false;
            lblChangePassword.Visible = false;
        }

        private void lblToLogIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblChangePassword.Visible = true;
            lblReset.Visible = true;
            lblEmail.Visible = false;
            txtEmail.Visible = false;
            lblToLogIn.Visible = false;
            lblRegistration.Visible = true;
            btnLogIn.Visible = true;
            btnRegistration.Visible = false;
            btnSave.Visible = true;

            txtNewPassword.Visible = false;
            lblChangePassword.Visible = true;
            lblNewPassword.Visible = false;
            btnSave.Visible = false;
            lblPassword.Text = "Password:";
            lblPassword.Location = new System.Drawing.Point(199, 255);
        }

        private  void LogIn_Load(object sender, EventArgs e)
        {
           
        }

        private async void lblChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblPassword.Text = "Current Password:";
            lblPassword.Location = new System.Drawing.Point(156, 255);
            lblEmail.Visible = false;
            txtEmail.Visible = false;
            txtNewPassword.Visible = true;
            lblChangePassword.Visible = false;
            lblNewPassword.Visible = true;
            btnSave.Visible= true;
            lblToLogIn.Visible = true;

            btnLogIn.Visible = false;
            lblRegistration.Visible = false;
            lblReset.Visible = false;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            string errorMessage = string.Empty;
            if (txtUser.Text == string.Empty)
                errorMessage = "Please add one username";
            else if (txtPassword.Text == string.Empty)
                errorMessage = "Please add the password";
            if (txtUser.Text.Length == 0 && txtPassword.Text.Length == 0)
                errorMessage = "Please enter the information";


            if (errorMessage == string.Empty)
            {
                User user = new User()
                {
                    UserName = txtUser.Text,
                    Password = Program.Encrypt(txtNewPassword.Text.ToString())
                };

                //change the password
                var result = await ApiControl<User>.Post(Program.BaseUrl + "User/EditUser/"+ Program.Encrypt(txtPassword.Text.ToString()), user);
                FormatData<User> information = new FormatData<User>();
                information = JsonSerializer.Deserialize<FormatData<User>>(result);
                if (information.Result)
                {
                    txtUser.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    MessageBox.Show("The password was updated");
                }
                else
                {
                    MessageBox.Show(information.MessageToFrontEnd, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(errorMessage, "Good", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void lblReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string randumValue = Program.RandomString();            
            string errorMessage = string.Empty;
            if (txtUser.Text == string.Empty)
                errorMessage = "Please add one username";


            if (errorMessage == string.Empty)
            {
                //note: for don't have errors the user can't have information null because the value is required
                User user = new User()
                {
                    UserName = txtUser.Text,
                    Password = Program.Encrypt(randumValue),
                    Email="logintotest"
                };


                var result = await ApiControl<User>.Post(Program.BaseUrl + "User/Reset", user);
                FormatData<User> information = new FormatData<User>();
                if(result!="")
                    information = JsonSerializer.Deserialize<FormatData<User>>(result);

              
                string Body = System.IO.File.ReadAllText("../../../text.htm");
                Body = Body.Replace("#Password", randumValue);
                Program.SendEmail(Body, information.Data.First().Email);

                if (information.Result)
                {
                    txtUser.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    MessageBox.Show("The email was send to: " + information.Data.First().Email, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //MessageBox.Show("The password was updated", "Good", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(information.MessageToFrontEnd, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                                
            }
            else
            {
                MessageBox.Show(errorMessage);
            }                       
        }

        

    }
}

using Entities;
using Entities.DataContext;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
 
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using uReclutmentWinForm.Control;
using Zuby.ADGV;

namespace uReclutmentWinForm.views
{
    public partial class User : Form
    {
        public string currentPassword { get; set; } 

        public User()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public async Task<bool> InitialTable()
        {
            string error = string.Empty;
            DataTable dataGet = await ApiControl<Entities.DataContext.User>.GetDataTable(Program.BaseUrl + "User/GetAllUser");

            //dataGet.DefaultView.Sort = "UserId desc";


            DataTable.DataSource = dataGet;
            DataTable.Sort(DataTable.Columns[0], ListSortDirection.Ascending);
            DataTable.ClearSelection();


            btnNew.Enabled = true;
            if (dataGet.Rows.Count == 0)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;

            return true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    
        private void DataTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {            
        }

        private void DataTable_SelectionChanged(object sender, EventArgs e)
        {
            btnNew.Enabled = true;
            btnSave.Enabled = true;
            Entities.DataContext.User user = new Entities.DataContext.User();
            if (DataTable.SelectedRows.Count != 0)
            {
                user.UserId = (int)DataTable.SelectedRows[0].Cells[0].Value;
                user.UserName = (string)DataTable.SelectedRows[0].Cells[1].Value;
                user.Password = (string)DataTable.SelectedRows[0].Cells[2].Value;
                user.Email = (string)DataTable.SelectedRows[0].Cells[3].Value;
                this.AcceptButton = btnSave;
            }
            else
            {
                this.AcceptButton = btnNew;
            }

            currentPassword = user.Password;
            txtPassword.Text = user.Password;
            txtUserId.Text = user.UserId.ToString();
            txtName.Text = user.UserName;          
            txtEmail.Text= user.Email;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataTable.ClearSelection();
            txtPassword.Text = string.Empty;
            txtUserId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            btnNew.Enabled = false;
            btnSave.Enabled = true;
            txtName.Focus();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            bool Enter = true;
            if (txtEmail.Text != "")
            {
                //email validation
                Match match = Regex.Match(txtEmail.Text, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
                if (!match.Success)
                {
                    Enter = false;
                    MessageBox.Show( "You require add a valid email", "error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                }
            }
            if (Enter)
            {
                btnSave.Enabled = false;
                Entities.DataContext.User user = new Entities.DataContext.User();
                if (!btnNew.Enabled)
                {
                    user.UserName = txtName.Text;
                    user.Password = Program.Encrypt(txtPassword.Text);
                    user.Email = txtEmail.Text;
                }
                else
                {
                    user.UserName = txtName.Text;

                    if (currentPassword == txtPassword.Text)
                        user.Password = (string)DataTable.SelectedRows[0].Cells[2].Value;
                    else
                        user.Password = Program.Encrypt(txtPassword.Text);


                    user.Email = txtEmail.Text;
                }

                string result = "";

                try
                {
                    //create
                    if (!btnNew.Enabled)
                    {
                        result = await ApiControl<Entities.DataContext.User>.Post(Program.BaseUrl + "User/AddUser", user);
                    }
                    else
                    {
                        //update                                        
                        result = await ApiControl<Entities.DataContext.User>.Put(Program.BaseUrl + "User/Update/" + txtUserId.Text, user);
                    }

                    if (result == "")
                    {
                        MessageBox.Show("Service is not working", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        FormatData<User> information = new FormatData<User>();
                        var serializer = new JsonSerializer();

                        using (var sr = new StreamReader(result))
                        using (var jsonTextReader = new JsonTextReader(sr))
                        {
                            var jsObj = serializer.Deserialize<FormatData<User>>(jsonTextReader);
                        }
                        //information = JsonSerializer.Deserialize<FormatData<User>>(result);
                        MessageBox.Show(information.MessageToFrontEnd);
                        bool initial = InitialTable().Result;
                        btnNew.Enabled = true;
                        btnSave.Enabled = false;

                        txtPassword.Text = string.Empty;
                        txtUserId.Text = string.Empty;
                        txtName.Text = string.Empty;
                        txtEmail.Text = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    btnSave.Enabled = true;
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }                            
        }

        private void DataTable_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {
            if (e.SortString.Length == 0)
            {
                return;
            }
            string[] strtok = e.SortString.Split(',');
            foreach (string str in strtok)
            {
                string[] columnorder = str.Split(']');
                ListSortDirection lds = ListSortDirection.Ascending;
                if (columnorder[1].Trim().Equals("DESC"))
                {
                    lds = ListSortDirection.Descending;
                }
                DataTable.Sort(DataTable.Columns[columnorder[0].Replace('[', ' ').Trim()], lds);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            
            //if (txtEmail.Text != "")
            //{
            //    //email validation
            //    Match match = Regex.Match(txtEmail.Text, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            //    if (!match.Success)
            //    {
            //        MessageBox.Show("Error", "You require add a valid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        txtEmail.Focus();
            //    }
            //}            
        }
    }
}

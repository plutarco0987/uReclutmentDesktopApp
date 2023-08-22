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
 
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using uReclutmentWinForm.Control;
using Zuby.ADGV;

namespace uReclutmentWinForm.views
{
    public partial class Settings : Form
    {
        public  Settings()
        {
            InitializeComponent();            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public async Task<bool> InitialTable()
        {
            string error = string.Empty;
            DataTable dataGet = await ApiControl<Entities.DataContext.Settings>.GetDataTable(Program.BaseUrl + "Settings/GetAllSettings");

            //first we create the first table of active and then we will sort that table of ids 
            DataTable dtActive= new DataTable();
            dtActive = dataGet.Clone();
            dtActive.Clear();
            DataTable dtNOActive = new DataTable();
            dtNOActive = dataGet.Clone();
            dtNOActive.Clear();
            foreach (DataRow dr in dataGet.Rows)
            {
                if ((bool)dr[3])
                    dtActive.ImportRow(dr);
                else
                    dtNOActive.ImportRow(dr);
            }
            dtActive.DefaultView.Sort = "SettingsId desc";
            dtNOActive.DefaultView.Sort = "SettingsId desc";

            dtActive.Merge(dtNOActive);
            
            DataTable.DataSource = dtActive;
            DataTable.Sort(DataTable.Columns[3], ListSortDirection.Descending);
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
            Entities.DataContext.Settings settings = new Entities.DataContext.Settings();
            if (DataTable.SelectedRows.Count != 0)
            {
                settings.SettingsId = (int)DataTable.SelectedRows[0].Cells[0].Value;
                settings.Name = (string)DataTable.SelectedRows[0].Cells[1].Value;
                settings.Value = (string)DataTable.SelectedRows[0].Cells[2].Value;
                settings.Active = (bool)DataTable.SelectedRows[0].Cells[3].Value;
                settings.NameCreated = (string)DataTable.SelectedRows[0].Cells[4].Value;
                settings.DateCreated = (DateTime)DataTable.SelectedRows[0].Cells[5].Value;
                settings.NameModified = (string)DataTable.SelectedRows[0].Cells[6].Value;
                settings.DateModified = (DateTime)DataTable.SelectedRows[0].Cells[7].Value;

                this.AcceptButton = btnSave;
            }
            else
            {
                this.AcceptButton = btnNew;
            }
            txtName.Text = settings.Name;
            txtSettingsId.Text = settings.SettingsId.ToString();
            txtValue.Text = settings.Value;
            chkActive.Checked = settings.Active;
            lblDateCreated.Text  = settings.DateCreated!=null ?settings.DateCreated.ToString() :"";
            lblNameCreated.Text = settings.NameCreated;
            lblNameModified.Text = settings.NameModified;
            lblDateModified.Text = settings.DateModified!=null ? settings.DateModified.ToString() :"";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataTable.ClearSelection();
            txtName.Text = string.Empty;
            txtSettingsId.Text = string.Empty;
            txtValue.Text = string.Empty;
            chkActive.Checked = false;
            lblDateCreated.Text = string.Empty;
            lblNameCreated.Text = string.Empty;
            lblNameModified.Text = string.Empty;
            lblDateModified.Text = string.Empty;
            btnNew.Enabled = false;
            btnSave.Enabled = true;

            txtName.Focus();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            DateTime now = DateTime.Now;
            Entities.DataContext.Settings settings = new Entities.DataContext.Settings();
            if (!btnNew.Enabled)
            {
                settings.Name = txtName.Text;
                settings.Value = txtValue.Text;
                settings.Active = chkActive.Checked;
                settings.DateCreated = now;
                settings.NameCreated = Program.LoginUser;
                settings.DateModified = now;
                settings.NameModified = Program.LoginUser;
            }
            else
            {
                settings.Name = txtName.Text;
                settings.Value = txtValue.Text;
                settings.Active = chkActive.Checked;
                settings.NameCreated = (string)DataTable.SelectedRows[0].Cells[4].Value;
                settings.NameModified = Program.LoginUser;
                settings.DateCreated = (DateTime)DataTable.SelectedRows[0].Cells[5].Value;
                settings.DateModified = now;
            }


            string result = "";

            try
            {
                //create
                if (!btnNew.Enabled)
                {
                    result = await ApiControl<Entities.DataContext.Settings>.Post(Program.BaseUrl + "Settings/AddSetting", settings);
                }
                else
                {
                    //update                    
                    //settings.DateCreated = DateTime.Parse(lblDateCreated.Text);
                    //settings.NameCreated = lblNameCreated.Text;
                    result = await ApiControl<Entities.DataContext.Settings>.Put(Program.BaseUrl + "Settings/UpdateSetting/"+txtSettingsId.Text, settings);
                }

                if (result == "")
                {
                    MessageBox.Show("Service is not working", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = true;
                }
                else
                {
                    FormatData<Settings> information = new FormatData<Settings>();
                    var serializer = new JsonSerializer();

                    using (var sr = new StreamReader(result))
                    using (var jsonTextReader = new JsonTextReader(sr))
                    {
                        var jsObj = serializer.Deserialize<FormatData<User>>(jsonTextReader);
                    }
                    //information = JsonSerializer.Deserialize<FormatData<Settings>>(result);
                    MessageBox.Show(information.MessageToFrontEnd);
                    bool initial = InitialTable().Result;
                    btnNew.Enabled = true;
                    btnSave.Enabled = false;

                    txtName.Text = string.Empty;
                    txtSettingsId.Text = string.Empty;
                    txtValue.Text = string.Empty;
                    chkActive.Checked = false;
                    lblDateCreated.Text = string.Empty;
                    lblNameCreated.Text = string.Empty;
                    lblNameModified.Text = string.Empty;
                    lblDateModified.Text = string.Empty;
                }                
            }
            catch (Exception ex)
            {
                btnSave.Enabled = true;
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (chkPdf.Checked && chkExcel.Checked)
            {
                string error = "";
                DataTable data = Program.GetDataGridViewAsDataTable(DataTable);
                bool pdf = Program.ExportToPdf(data, out error);
                if (!pdf)
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    bool excel = Program.ExportToExcel(data, out error);
                    if (!excel)
                        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (pdf && excel)
                        MessageBox.Show("The table was Exported (PDF and Excel) in the path of the settings");
                }
            }
            else if (chkPdf.Checked)
            {
                string error = "";
                DataTable data = Program.GetDataGridViewAsDataTable(DataTable);

                if (Program.ExportToPdf(data, out error))
                    MessageBox.Show("The table was Exported in the path of the settings");
                else
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (chkExcel.Checked)
            {
                string error = "";
                DataTable data = Program.GetDataGridViewAsDataTable(DataTable);

                if (Program.ExportToExcel(data, out error))
                    MessageBox.Show("The table was Exported in the path of the settings");
                else
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Please select at least one option");

        }
    }
}

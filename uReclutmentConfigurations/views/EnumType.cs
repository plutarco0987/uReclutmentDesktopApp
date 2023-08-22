using Entities;
using Entities.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using uReclutmentConfigurations.Control;
using Zuby.ADGV;

namespace uReclutmentConfigurations.views
{
    public partial class EnumType : Form
    {
        public EnumType()
        {
            InitializeComponent();            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public async Task<bool> InitialTable()
        {
            string error = string.Empty;
            DataTable dataGet = await ApiControl<Entities.DataContext.EnumType>.GetDataTable(Program.BaseUrl + "EnumType/GetAllEnumType");

            //first we create the first table of active and then we will sort that table of ids 
            DataTable dtActive= new DataTable();
            dtActive = dataGet.Clone();
            dtActive.Clear();
            DataTable dtNOActive = new DataTable();
            dtNOActive = dataGet.Clone();
            dtNOActive.Clear();
            foreach (DataRow dr in dataGet.Rows)
            {
                if ((bool)dr[6])
                    dtActive.ImportRow(dr);
                else
                    dtNOActive.ImportRow(dr);
            }
            dtActive.DefaultView.Sort = "EnumTypeId desc";
            dtNOActive.DefaultView.Sort = "EnumTypeId desc";

            dtActive.Merge(dtNOActive);
            
            DataTable.DataSource = dtActive;
            DataTable.Sort(DataTable.Columns[6], ListSortDirection.Descending);
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
            Entities.DataContext.EnumType enumType = new Entities.DataContext.EnumType();
            if (DataTable.SelectedRows.Count != 0)
            {
                enumType.EnumTypeId = (int)DataTable.SelectedRows[0].Cells[0].Value;
                enumType.Name = (string)DataTable.SelectedRows[0].Cells[1].Value;
                enumType.NameCreated = (string?)DataTable.SelectedRows[0].Cells[2].Value;
                enumType.DateCreated = (DateTime)DataTable.SelectedRows[0].Cells[3].Value;
                enumType.NameModified = (string?)DataTable.SelectedRows[0].Cells[4].Value;
                enumType.DateModified = (DateTime)DataTable.SelectedRows[0].Cells[5].Value;
                enumType.Active= (bool)DataTable.SelectedRows[0].Cells[6].Value;
                               
                this.AcceptButton = btnSave;
            }
            else
            {
                this.AcceptButton = btnNew;
            }
            txtName.Text = enumType.Name;
            txtEnumTypeId.Text = enumType.EnumTypeId.ToString();            
            chkActive.Checked = enumType.Active;
            lblDateCreated.Text = enumType.DateCreated != null && enumType.DateCreated != new DateTime() ? enumType.DateCreated.ToString() : "";
            lblNameCreated.Text = enumType.NameCreated;
            lblNameModified.Text = enumType.NameModified;
            lblDateModified.Text = enumType.DateModified != null && enumType.DateModified != new DateTime() ? enumType.DateModified.ToString() : "";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataTable.ClearSelection();
            txtName.Text = string.Empty;
            txtEnumTypeId.Text = string.Empty;            
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
            Entities.DataContext.EnumType enumType = new Entities.DataContext.EnumType();
            if (!btnNew.Enabled)
            {
                enumType.Name = txtName.Text;
                enumType.Active = chkActive.Checked;
                enumType.DateCreated = now;
                enumType.NameCreated = Program.LoginUser;
                enumType.DateModified = now;
                enumType.NameModified = Program.LoginUser;
            }
            else
            {
                enumType.Name = txtName.Text;
                enumType.Active = chkActive.Checked;
                enumType.NameCreated = (string?)DataTable.SelectedRows[0].Cells[2].Value;
                enumType.NameModified = Program.LoginUser;
                enumType.DateCreated = (DateTime)DataTable.SelectedRows[0].Cells[3].Value;
                enumType.DateModified = now;
            }


            string result = "";

            try
            {
                //create
                if (!btnNew.Enabled)
                {
                    result = await ApiControl<Entities.DataContext.EnumType>.Post(Program.BaseUrl + "EnumType/AddEnumType", enumType);
                }
                else
                {
                    //update                    
                    //settings.DateCreated = DateTime.Parse(lblDateCreated.Text);
                    //settings.NameCreated = lblNameCreated.Text;
                    result = await ApiControl<Entities.DataContext.EnumType>.Put(Program.BaseUrl + "EnumType/UpdateEnumType/" + txtEnumTypeId.Text, enumType);
                }

                if (result == "")
                {
                    MessageBox.Show("Service is not working", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = true;
                }
                else
                {
                    FormatData<Meeting> information = new FormatData<Meeting>();
                    information = JsonSerializer.Deserialize<FormatData<Meeting>>(result);
                    MessageBox.Show(information.MessageToFrontEnd);
                    bool initial = InitialTable().Result;
                    btnNew.Enabled = true;
                    btnSave.Enabled = false;

                    txtName.Text = string.Empty;
                    txtEnumTypeId.Text = string.Empty;                    
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

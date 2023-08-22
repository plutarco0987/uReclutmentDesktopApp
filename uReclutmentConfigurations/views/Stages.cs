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
    public partial class Stages : Form
    {
        public Stages()
        {
            InitializeComponent();
            
        }

        private void ReconcilerConsoleWindow_Load(object sender, EventArgs e)
        {
            SetColor();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public async Task<bool> InitialTable()
        {
            string error = string.Empty;
            DataTable dataGet = await ApiControl<Entities.DataContext.Stages>.GetDataTable(Program.BaseUrl + "Stages/GetAllStages");


            //first we create the first table of active and then we will sort that table of ids 
            DataTable dtActive= new DataTable();
            dtActive = dataGet.Clone();
            dtActive.Clear();
            DataTable dtNOActive = new DataTable();            dtNOActive = dataGet.Clone();
            dtNOActive.Clear();
            foreach (DataRow dr in dataGet.Rows)
            {
                if ((bool)dr[8])
                    dtActive.ImportRow(dr);
                else
                    dtNOActive.ImportRow(dr);
            }
            dtActive.DefaultView.Sort = "StagesId desc";
            dtNOActive.DefaultView.Sort = "StagesId desc";

            dtActive.Merge(dtNOActive);
            
            DataTable.DataSource = dtActive;
            DataTable.Sort(DataTable.Columns[8], ListSortDirection.Descending);
            DataTable.ClearSelection();

            SetColor();

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

        public void SetColor()
        {
            foreach (DataGridViewRow item in DataTable.Rows)
            {                
                string rgb = "0,0,0";
                if (item.Cells[2]!=null)
                        rgb= item.Cells[2].Value.ToString();

                string[] arrayRGB = rgb.Split(",");

                item.Cells[2].Style.BackColor = Color.FromArgb(int.Parse(arrayRGB[0]), int.Parse(arrayRGB[1]), int.Parse(arrayRGB[2]));
            }
        }

        private void DataTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {            
        }

        private void DataTable_SelectionChanged(object sender, EventArgs e)
        {
            btnNew.Enabled = true;
            btnSave.Enabled = true;
            Entities.DataContext.Stages stage = new Entities.DataContext.Stages();
            if (DataTable.SelectedRows.Count != 0)
            {
                stage.StagesId= (int)DataTable.SelectedRows[0].Cells[0].Value;
                stage.Name= (string)DataTable.SelectedRows[0].Cells[1].Value;
                stage.Color = (string)DataTable.SelectedRows[0].Cells[2].Value;
                stage.Order = (int)DataTable.SelectedRows[0].Cells[3].Value;
                stage.NameCreated = (string?)DataTable.SelectedRows[0].Cells[4].Value;
                stage.DateCreated = (DateTime)DataTable.SelectedRows[0].Cells[5].Value;
                stage.NameModified = (string?)DataTable.SelectedRows[0].Cells[6].Value;
                stage.DateModified = (DateTime)DataTable.SelectedRows[0].Cells[7].Value;

                string[] colors=stage.Color.Split(',');
                panelColor.BackColor = Color.FromArgb(int.Parse(colors[0]), int.Parse(colors[1]), int.Parse(colors[2]));

                this.AcceptButton = btnSave;
            }
            else
            {
                stage.Order = 1;
                this.AcceptButton = btnNew;
            }
            txtName.Text = stage.Name;
            txtStagesId.Text = stage.StagesId.ToString();
            txtColor.Text = stage.Color;
            txtOrder.Value = stage.Order;
            chkActive.Checked = stage.Active;
            lblDateCreated.Text = stage.DateCreated!=null ? stage.DateCreated.ToString() :"";
            lblNameCreated.Text = stage.NameCreated;
            lblNameModified.Text = stage.NameModified;
            lblDateModified.Text = stage.DateModified!=null ? stage.DateModified.ToString() :"";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataTable.ClearSelection();
            txtName.Text = string.Empty;
            txtStagesId.Text = string.Empty;
            txtColor.Text = string.Empty;
            txtOrder.Value = 1;
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
            Entities.DataContext.Stages stage = new Entities.DataContext.Stages();
            if (!btnNew.Enabled)
            {
                stage.Name = txtName.Text;
                stage.Color = txtColor.Text;
                stage.Order = (int)txtOrder.Value;
                stage.Active = chkActive.Checked;
                stage.NameCreated = Program.LoginUser;
                stage.NameModified = Program.LoginUser;
                stage.DateCreated = DateTime.Now;
                stage.DateModified = stage.DateCreated;
            }
            else
            {
                stage.Name = txtName.Text;
                stage.Color = txtColor.Text;
                stage.Order = (int)txtOrder.Value;
                stage.Active = chkActive.Checked;
                stage.NameCreated = (string?)DataTable.SelectedRows[0].Cells[4].Value;
                stage.NameModified = Program.LoginUser;
                stage.DateCreated = (DateTime)DataTable.SelectedRows[0].Cells[5].Value;
                stage.DateModified = DateTime.Now;
            }        
        
            string result = "";

            try
            {
                //create
                if (!btnNew.Enabled)
                {
                    result = await ApiControl<Entities.DataContext.Stages>.Post(Program.BaseUrl + "Stages/AddStage", stage);
                }
                else
                {
                    //update                    
                    stage.DateCreated = DateTime.Parse(lblDateCreated.Text);
                    stage.NameCreated = lblNameCreated.Text;
                    result = await ApiControl<Entities.DataContext.Stages>.Put(Program.BaseUrl + "Stages/UpdateStage/" + txtStagesId.Text, stage);
                }

                if (result == "")
                {
                    MessageBox.Show("Service is not working", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = true;
                }
                else
                {
                    FormatData<Stages> information = new FormatData<Stages>();
                    information = JsonSerializer.Deserialize<FormatData<Stages>>(result);
                    MessageBox.Show(information.MessageToFrontEnd);
                    bool initial = InitialTable().Result;
                    btnNew.Enabled = true;
                    btnSave.Enabled = false;

                    txtName.Text = string.Empty;
                    txtStagesId.Text = string.Empty;
                    txtColor.Text = string.Empty;
                    chkActive.Checked = false;
                    txtOrder.Value = 1;
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

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            panelColor.BackColor = colorDialog1.Color;            //color in RGB will be saved 
            txtColor.Text = string.Format("{0},{1},{2}", colorDialog1.Color.R, colorDialog1.Color.G, colorDialog1.Color.B);
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

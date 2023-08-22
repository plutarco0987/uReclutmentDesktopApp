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
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using uReclutmentConfigurations.Control;
using Zuby.ADGV;

namespace uReclutmentConfigurations.views
{
    public partial class Requirements : Form
    {
        private Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();
        private Dictionary<int, string> dictionaryVacancy = new Dictionary<int, string>();
        private Dictionary<int, Entities.DataContext.VacancyFormat> dictionaryVacancyAll = new Dictionary<int, Entities.DataContext.VacancyFormat>();
        public Requirements()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public async Task<bool> InitialVacancys()
        {
            List<Entities.DataContext.VacancyFormat> dataGet = await ApiControl<Entities.DataContext.VacancyFormat>.GetDictionary(Program.BaseUrl + "Vacancy/GetAllVacancy");

            dictionaryVacancy = dataGet.ToDictionary(keySelector: x => x.VacancyId, elementSelector: x => x.Name);
            dictionaryVacancyAll = dataGet.ToDictionary(keySelector: x => x.VacancyId, elementSelector: x => x);
            return true;
        }
        public async Task<bool> InitialTable()
        {
            string error = string.Empty;

            DataTable dataGet = await ApiControl<Entities.DataContext.Requirements>.GetDataTable(Program.BaseUrl + "Requirements/GetAllRequirements");

            //first we create the first table of active and then we will sort that table of ids 
            DataTable dtActive = new DataTable();
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
            dtActive.DefaultView.Sort = "RequirementsId desc";
            dtNOActive.DefaultView.Sort = "RequirementsId desc";

            dtActive.Merge(dtNOActive);

            btnNew.Enabled = true;
            if (dataGet.Rows.Count == 0)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;

            InitialCmbBoxes(dictionaryVacancy);

            AddColumn(dtActive);

            DataTable.DataSource = dtActive;
            DataTable.Columns[12].Visible = false;
            DataTable.Sort(DataTable.Columns[6], ListSortDirection.Descending);
            DataTable.ClearSelection();





            return true;
        }

        private void AddColumn(DataTable data)
        {
            data.Columns.Add("VacancyName");
            foreach (DataRow item in data.Rows)
            {
                string value = string.Empty;
                dictionaryVacancy.TryGetValue(int.Parse(item.ItemArray[1].ToString()), out value);
                item.SetField("VacancyName", value);
            }
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
            Entities.DataContext.Requirements requirements = new Entities.DataContext.Requirements();
            if (DataTable.SelectedRows.Count != 0)
            {
                requirements.RequirementsId = (int)DataTable.SelectedRows[0].Cells[0].Value;
                requirements.VacancyId = (int)DataTable.SelectedRows[0].Cells[1].Value;
                requirements.Name = (string)DataTable.SelectedRows[0].Cells[2].Value;
                requirements.Description = (string)DataTable.SelectedRows[0].Cells[3].Value;

                requirements.Required = (bool)DataTable.SelectedRows[0].Cells[4].Value;
                requirements.AgeExperience = (string)DataTable.SelectedRows[0].Cells[5].Value;


                requirements.Active = (bool)DataTable.SelectedRows[0].Cells[6].Value;
                requirements.NameCreated = (string?)DataTable.SelectedRows[0].Cells[7].Value;
                requirements.DateCreated = (DateTime)DataTable.SelectedRows[0].Cells[8].Value;
                requirements.NameModified = (string?)DataTable.SelectedRows[0].Cells[9].Value;
                requirements.DateModified = (DateTime)DataTable.SelectedRows[0].Cells[10].Value;

                requirements.Benefits = (bool)DataTable.SelectedRows[0].Cells[11].Value;


                //AddColumn((DataTable) DataTable.DataSource);

                ComboboxItem itemBox = new ComboboxItem();
                itemBox.Text = (string)DataTable.SelectedRows[0].Cells[13].Value;
                itemBox.Value = (int)DataTable.SelectedRows[0].Cells[1].Value;

                cmbVacancy.Text = itemBox.Text;
                this.AcceptButton = btnSave;
            }
            else
            {
                cmbVacancy.Text = "";
                this.AcceptButton = btnNew;
            }

            txtRequirementId.Text = requirements.RequirementsId.ToString();
            txtName.Text = requirements.Name;
            txtDescription.Text = requirements.Description;
            chkBenefice.Checked = requirements.Benefits;
            chkRequired.Checked = requirements.Required;
            txtOrder.Text = requirements.AgeExperience;
            chkActive.Checked = requirements.Active;
            lblDateCreated.Text = requirements.DateCreated != null ? requirements.DateCreated.ToString() : "";
            lblNameCreated.Text = requirements.NameCreated;
            lblNameModified.Text = requirements.NameModified;
            lblDateModified.Text = requirements.DateModified != null ? requirements.DateModified.ToString() : "";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataTable.ClearSelection();

            txtRequirementId.Text = string.Empty;
            cmbVacancy.Text = "";
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            chkRequired.Checked = false;
            chkBenefice.Checked = false;
            txtOrder.Text = string.Empty;
            chkActive.Checked = false;
            lblDateCreated.Text = string.Empty;
            lblNameCreated.Text = string.Empty;
            lblNameModified.Text = string.Empty;
            lblDateModified.Text = string.Empty;
            btnNew.Enabled = false;
            btnSave.Enabled = true;

            cmbVacancy.Focus();
        }

        private void InitialCmbBoxes(DataTable dataTable)
        {
            if (dataTable != null)
            {
                Dictionary<int, string> pairs = new Dictionary<int, string>();

                foreach (DataRow item in dataTable.Rows)
                {
                    if (!pairs.ContainsKey(int.Parse(item.ItemArray[1].ToString())))
                    {
                        pairs.Add(int.Parse(item.ItemArray[1].ToString()), item.ItemArray[13].ToString());
                    }
                }
                cmbVacancy.Items.Clear();
                foreach (var item in pairs)
                {
                    ComboboxItem itemBox = new ComboboxItem();
                    itemBox.Text = item.Value;
                    itemBox.Value = item.Key;

                    cmbVacancy.Items.Add(itemBox);
                }

                keyValuePairs = pairs;
            }
        }
        private void InitialCmbBoxes(Dictionary<int, string> dataTable)
        {
            if (dataTable != null)
            {
                Dictionary<int, string> pairs = dataTable;

                cmbVacancy.Items.Clear();
                foreach (var item in pairs)
                {
                    ComboboxItem itemBox = new ComboboxItem();
                    itemBox.Text = item.Value;
                    itemBox.Value = item.Key;

                    cmbVacancy.Items.Add(itemBox);
                }

                keyValuePairs = pairs;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            DateTime now = DateTime.Now;
            Entities.Formats.RequirementsFormat requirements = new Entities.Formats.RequirementsFormat();
            if (!btnNew.Enabled)
            {
                requirements.VacancyId = keyValuePairs.FirstOrDefault(x => x.Value == cmbVacancy.Text).Key;

                requirements.Name = txtName.Text;
                requirements.Description = txtDescription.Text;

                requirements.Required = chkRequired.Checked;
                requirements.AgeExperience = txtOrder.Text;
                requirements.Active = chkActive.Checked;
                requirements.DateCreated = now;
                requirements.NameCreated = Program.LoginUser;
                requirements.DateModified = now;
                requirements.NameModified = Program.LoginUser;
                requirements.Benefits = chkBenefice.Checked;
                //requirements.Vacancy = new Entities.DataContext.Vacancy();
                //VacancyFormat vacancyFormat = new VacancyFormat();
                //dictionaryVacancyAll.TryGetValue(requirements.VacancyId, out vacancyFormat);
                //requirements.Vacancy = new Entities.DataContext.Vacancy(vacancyFormat);
                //requirements.Vacancy.Candidates = new List<Candidates>();
            }
            else
            {

                requirements.VacancyId = keyValuePairs.FirstOrDefault(x => x.Value == cmbVacancy.Text).Key;

                requirements.Name = txtName.Text;
                requirements.Description = txtDescription.Text;

                requirements.Required = chkRequired.Checked;
                requirements.AgeExperience = txtOrder.Text;
                requirements.Active = chkActive.Checked;
                requirements.Benefits = chkBenefice.Checked;
                requirements.DateCreated = (DateTime)DataTable.SelectedRows[0].Cells[8].Value;
                requirements.NameCreated = (string?)DataTable.SelectedRows[0].Cells[7].Value;
                requirements.DateModified = now;
                requirements.NameModified = Program.LoginUser;


                //VacancyFormat vacancyFormat = new VacancyFormat();
                //dictionaryVacancyAll.TryGetValue(requirements.VacancyId, out vacancyFormat);
                //requirements.Vacancy = new Entities.DataContext.Vacancy(vacancyFormat);
                //requirements.Vacancy.Candidates = new List<Candidates>();
            }

            string result = "";

            try
            {
                //create
                if (!btnNew.Enabled)
                {
                    result = await ApiControl<Entities.Formats.RequirementsFormat>.Post(Program.BaseUrl + "Requirements/AddRequirement", requirements);
                }
                else
                {
                    //update                    
                    //settings.DateCreated = DateTime.Parse(lblDateCreated.Text);
                    //settings.NameCreated = lblNameCreated.Text;
                    result = await ApiControl<Entities.Formats.RequirementsFormat>.Put(Program.BaseUrl + "Requirements/UpdateRequirement/" + txtRequirementId.Text, requirements);
                }

                if (result == "")
                {
                    MessageBox.Show("Service is not working", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = true;
                }
                else
                {
                    FormatData<Requirements> information = new FormatData<Requirements>();
                    information = JsonSerializer.Deserialize<FormatData<Requirements>>(result);
                    MessageBox.Show(information.MessageToFrontEnd);
                    bool initial = InitialTable().Result;
                    btnNew.Enabled = true;
                    btnSave.Enabled = false;
                    txtRequirementId.Text = string.Empty;
                    cmbVacancy.Text = "";
                    txtName.Text = string.Empty;
                    txtDescription.Text = string.Empty;
                    chkRequired.Checked = false;
                    txtOrder.Text = string.Empty;
                    chkActive.Checked = false;
                    lblDateCreated.Text = string.Empty;
                    lblNameCreated.Text = string.Empty;
                    lblNameModified.Text = string.Empty;
                    lblDateModified.Text = string.Empty;
                    btnNew.Enabled = false;
                    btnSave.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                btnSave.Enabled = true;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void Customers_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void txtDescription_MultilineChanged(object sender, EventArgs e)
        {

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

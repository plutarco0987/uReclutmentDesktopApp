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
    public partial class Vacancy : Form
    {
        private Dictionary<int,string> keyValuePairs= new Dictionary<int,string>();
        private Dictionary<int, string> dictionaryCustomers = new Dictionary<int, string>();
        public Vacancy()
        {
            InitializeComponent();

            //initial checkboxes
            string value = "";
            Program.Settings.TryGetValue("ContractType", out value);
            if (value != "")
            {
                string[] list = value.Split(",");
                cmbContractType.Items.AddRange(list);
            }
            //Status
            string value2 = "";
            Program.Settings.TryGetValue("VacancySatatus", out value2);
            if (value2 != "")
            {
                string[] list = value2.Split(",");
                cmbStatus.Items.AddRange(list);
            }
            //Departament
            string value3 = "";
            Program.Settings.TryGetValue("Departament", out value3);
            if (value3 != "")
            {
                string[] list = value3.Split(",");
                cmbDepartament.Items.AddRange(list);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public async Task<bool> InitialVacancys()
        {
            List<Entities.DataContext.Customers> dataGet = await ApiControl<Entities.DataContext.Customers>.GetDictionary(Program.BaseUrl + "Customers/GetAllCustomers");
            
            dictionaryCustomers = dataGet.ToDictionary(keySelector: x => x.CustomersId, elementSelector: x => x.Name);
            return true;
        }

        public async Task<bool> InitialTable()
        {
            string error = string.Empty;
            DataTable dataGet = await ApiControl<Entities.DataContext.VacancyFormat>.GetDataTable(Program.BaseUrl + "Vacancy/GetAllVacancy");

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
            dtActive.DefaultView.Sort = "VacancyId desc";
            dtNOActive.DefaultView.Sort = "VacancyId desc";

            dtActive.Merge(dtNOActive);

            btnNew.Enabled = true;
            if (dataGet.Rows.Count == 0)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;

            InitialCmbBoxes(dictionaryCustomers);
            

            DataTable.DataSource = dtActive;
            DataTable.Columns[11].Visible=false;
            DataTable.Sort(DataTable.Columns[6], ListSortDirection.Descending);
            DataTable.ClearSelection();

          



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
            Entities.DataContext.Vacancy vacancy = new Entities.DataContext.Vacancy();
            if (DataTable.SelectedRows.Count != 0)
            {
                vacancy.VacancyId = (int)DataTable.SelectedRows[0].Cells[0].Value;
                vacancy.CustomersId = (int)DataTable.SelectedRows[0].Cells[1].Value;
                vacancy.Name = (string)DataTable.SelectedRows[0].Cells[2].Value;
                vacancy.Description = (string)DataTable.SelectedRows[0].Cells[3].Value;
                vacancy.NamePosition = (string)DataTable.SelectedRows[0].Cells[4].Value;
                vacancy.Responsabilitys = (string)DataTable.SelectedRows[0].Cells[5].Value;
                vacancy.Active = (bool)DataTable.SelectedRows[0].Cells[6].Value;
                vacancy.NameCreated = (string?)DataTable.SelectedRows[0].Cells[7].Value;
                vacancy.DateCreated = (DateTime)DataTable.SelectedRows[0].Cells[8].Value;
                vacancy.NameModified = (string?)DataTable.SelectedRows[0].Cells[9].Value;
                vacancy.DateModified = (DateTime)DataTable.SelectedRows[0].Cells[10].Value;
                vacancy.ContractType = (string)DataTable.SelectedRows[0].Cells[13].Value;
                vacancy.Status = (string)DataTable.SelectedRows[0].Cells[14].Value;
                vacancy.Departament = (string)DataTable.SelectedRows[0].Cells[15].Value;

                ComboboxItem itemBox = new ComboboxItem();
                itemBox.Text = (string)DataTable.SelectedRows[0].Cells[12].Value;
                itemBox.Value = (int)DataTable.SelectedRows[0].Cells[1].Value;
                
                cmbCustomer.Text = itemBox.Text;
                this.AcceptButton = btnSave;
            }
            else
            {
                cmbCustomer.Text = "";
                this.AcceptButton = btnNew;
            }
            

            txtVacancy.Text = vacancy.VacancyId.ToString();
            
            txtName.Text = vacancy.Name;           
            txtDescription.Text = vacancy.Description;
            txtNamePosition.Text    = vacancy.NamePosition;
            txtResponsabilitys.Text = vacancy.Responsabilitys;
            chkActive.Checked = vacancy.Active;
            cmbContractType.Text = vacancy.ContractType;

            cmbStatus.Text= vacancy.Status;
            cmbDepartament.Text=vacancy.Departament;

            lblDateCreated.Text = vacancy.DateCreated!=null ? vacancy.DateCreated.ToString() :"";
            lblNameCreated.Text = vacancy.NameCreated;
            lblNameModified.Text = vacancy.NameModified;
            lblDateModified.Text = vacancy.DateModified!=null ? vacancy.DateModified.ToString() :"";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataTable.ClearSelection();
            cmbCustomer.Text = "";
            txtName.Text = string.Empty;
            txtVacancy.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtNamePosition.Text = string.Empty;      
            txtResponsabilitys.Text=string.Empty;
            cmbContractType.Text = string.Empty;
            cmbDepartament.Text = string.Empty;
            cmbStatus.Text = string.Empty;
            chkActive.Checked = false;
            lblDateCreated.Text = string.Empty;
            lblNameCreated.Text = string.Empty;
            lblNameModified.Text = string.Empty;
            lblDateModified.Text = string.Empty;
            btnNew.Enabled = false;
            btnSave.Enabled = true;

            cmbCustomer.Focus();
        }

        private void InitialCmbBoxes(DataTable dataTable)
        {
            if (dataTable != null)
            {
                Dictionary<int, string> pairs = new Dictionary<int, string>();

                foreach  (DataRow item in dataTable.Rows)
                {
                    if (!pairs.ContainsKey(int.Parse(item.ItemArray[1].ToString())))
                    {
                        pairs.Add(int.Parse(item.ItemArray[1].ToString()), item.ItemArray[13].ToString());
                    }
                }
                cmbCustomer.Items.Clear();
                foreach (var item in pairs)
                {
                    ComboboxItem itemBox = new ComboboxItem();
                    itemBox.Text = item.Value;
                    itemBox.Value = item.Key;

                    cmbCustomer.Items.Add(itemBox);
                }

                keyValuePairs = pairs;
            }
        }
        private void InitialCmbBoxes(Dictionary<int,string> dataTable)
        {
            if (dataTable != null)
            {
                Dictionary<int, string> pairs = dataTable;
                cmbCustomer.Items.Clear();
                foreach (var item in pairs)
                {
                    ComboboxItem itemBox = new ComboboxItem();
                    itemBox.Text = item.Value;
                    itemBox.Value = item.Key;

                    cmbCustomer.Items.Add(itemBox);
                }

                keyValuePairs = pairs;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            DateTime now = DateTime.Now;
            Entities.DataContext.VacancyFormat vacancy = new Entities.DataContext.VacancyFormat();
            if (!btnNew.Enabled)
            {
                vacancy.CustomersId = keyValuePairs.FirstOrDefault(x => x.Value == cmbCustomer.Text).Key;

                vacancy.Name = txtName.Text;
                vacancy.Description = txtDescription.Text;
                vacancy.NamePosition= txtNamePosition.Text;
                vacancy.Responsabilitys= txtResponsabilitys.Text;
                vacancy.Active = chkActive.Checked;
                vacancy.ContractType= cmbContractType.Text;
                vacancy.Status=cmbStatus.Text;
                vacancy.Departament = cmbDepartament.Text;
                vacancy.DateCreated = now;
                vacancy.NameCreated = Program.LoginUser;
                vacancy.DateModified = now;
                vacancy.NameModified = Program.LoginUser;

                vacancy.Questions = new List<string>();
                vacancy.QuestionsString = "";
                vacancy.CustomerName = cmbCustomer.Text;
            }
            else
            {
                vacancy.CustomersId = keyValuePairs.FirstOrDefault(x => x.Value == cmbCustomer.Text).Key;

                vacancy.Name = txtName.Text;
                vacancy.Description = txtDescription.Text;
                vacancy.NamePosition = txtNamePosition.Text;
                vacancy.Responsabilitys = txtResponsabilitys.Text;
                vacancy.Active = chkActive.Checked;
                vacancy.ContractType = cmbContractType.Text;
                vacancy.Status = cmbStatus.Text;
                vacancy.Departament = cmbDepartament.Text;
                vacancy.NameCreated = (string?)DataTable.SelectedRows[0].Cells[7].Value;
                vacancy.NameModified = Program.LoginUser;
                vacancy.DateCreated = (DateTime)DataTable.SelectedRows[0].Cells[8].Value;
                vacancy.DateModified = now;
                vacancy.Questions = new List<string>();
                vacancy.QuestionsString = "";
                vacancy.CustomerName = cmbCustomer.Text;
            }             

            string result = "";

            try
            {
                //create
                if (!btnNew.Enabled)
                {
                    result =  await ApiControl<Entities.DataContext.VacancyFormat>.Post(Program.BaseUrl + "Vacancy/AddVacancy", vacancy);
                }
                else
                {
                    //update                    
                    //settings.DateCreated = DateTime.Parse(lblDateCreated.Text);
                    //settings.NameCreated = lblNameCreated.Text;
                    result = await ApiControl<Entities.DataContext.VacancyFormat>.Put(Program.BaseUrl + "Vacancy/UpdateVacancy/" + txtVacancy.Text, vacancy);
                }

                if (result == "")
                {
                    MessageBox.Show("Service is not working", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = true;
                }
                else
                {
                    FormatData<VacancyFormat> information = new FormatData<VacancyFormat>();
                    information = JsonSerializer.Deserialize<FormatData<VacancyFormat>>(result);
                    MessageBox.Show(information.MessageToFrontEnd);
                    bool initial = InitialTable().Result;
                    btnNew.Enabled = true;
                    btnSave.Enabled = false;

                    txtName.Text = string.Empty;
                    cmbCustomer.Text= string.Empty;
                    txtVacancy.Text = string.Empty;
                    txtDescription.Text = string.Empty;
                    txtNamePosition.Text = string.Empty;                    
                    chkActive.Checked = false;
                    txtResponsabilitys.Text= string.Empty;
                    cmbContractType.Text = string.Empty;
                    cmbDepartament.Text = string.Empty;
                    cmbStatus.Text = string.Empty;

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

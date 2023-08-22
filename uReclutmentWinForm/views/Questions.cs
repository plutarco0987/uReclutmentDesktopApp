using Entities;
using Entities.DataContext;
using Entities.Formats;
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
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using uReclutmentWinForm.Control;
using Zuby.ADGV;

namespace uReclutmentWinForm.views
{
    public partial class Questions : Form
    {
        private Dictionary<int, string> dictionaryVacancy = new Dictionary<int, string>();
        private Dictionary<int, Entities.DataContext.VacancyFormat> dictionaryVacancyAll = new Dictionary<int, Entities.DataContext.VacancyFormat>();
        private Dictionary<int, string> dictionaryEnum = new Dictionary<int, string>();
        private Dictionary<int, Entities.DataContext.EnumType> dictionaryEnumAll = new Dictionary<int, Entities.DataContext.EnumType>();
        public Questions()
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
        public async Task<bool> InitialEnums()
        {
            List<Entities.DataContext.EnumType> dataGet = await ApiControl<Entities.DataContext.EnumType>.GetDictionary(Program.BaseUrl + "EnumType/GetAllEnumType");
            
            dictionaryEnum = dataGet.ToDictionary(keySelector: x => x.EnumTypeId, elementSelector: x => x.Name);
            dictionaryEnumAll = dataGet.ToDictionary(keySelector: x => x.EnumTypeId, elementSelector: x => x);
            return true;
        }
        public async Task<bool> InitialTable()
        {
            string error = string.Empty;

            DataTable dataGet = await ApiControl<Entities.Formats.QuestionsFormat>.GetDataTable(Program.BaseUrl + "Questions/GetAllQuestions");

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
            dtActive.DefaultView.Sort = "QuestionsId desc";
            dtNOActive.DefaultView.Sort = "QuestionsId desc";

            dtActive.Merge(dtNOActive);

            btnNew.Enabled = true;
            if (dataGet.Rows.Count == 0)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;

            InitialCmbBoxes(dictionaryVacancy, 1);
            InitialCmbBoxes(dictionaryEnum, 2);

            AddColumn(dtActive, "EnumType", 1);
            AddColumn(dtActive, "VacancyName", 2);

            DataTable.DataSource = dtActive;            
            DataTable.Sort(DataTable.Columns[6], ListSortDirection.Descending);
            DataTable.ClearSelection();
            return true;
        }

        private void AddColumn(DataTable data, string nameColumn, int position)
        {
            data.Columns.Add(nameColumn);
            foreach (DataRow item in data.Rows)
            {
                string value = string.Empty;
                if (position == 2)
                    dictionaryVacancy.TryGetValue(int.Parse(item.ItemArray[position].ToString()), out value);
                else
                    dictionaryEnum.TryGetValue(int.Parse(item.ItemArray[position].ToString()), out value);

                item.SetField(nameColumn, value);
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
            Entities.Formats.QuestionsFormat questions = new Entities.Formats.QuestionsFormat();
            if (DataTable.SelectedRows.Count != 0)
            {
                questions.QuestionsId = (int)DataTable.SelectedRows[0].Cells[0].Value;

                questions.EnumTypeId = (int)DataTable.SelectedRows[0].Cells[1].Value;
                questions.VacancyId = (int)DataTable.SelectedRows[0].Cells[2].Value;
                questions.Question = (string)DataTable.SelectedRows[0].Cells[3].Value;
                questions.Required = (bool)DataTable.SelectedRows[0].Cells[4].Value;
                questions.MaxLength = (int)DataTable.SelectedRows[0].Cells[5].Value;                


                questions.Active = (bool)DataTable.SelectedRows[0].Cells[6].Value;
                questions.NameCreated = (string)DataTable.SelectedRows[0].Cells[7].Value;
                questions.DateCreated = (DateTime)DataTable.SelectedRows[0].Cells[8].Value;
                questions.NameModified = (string)DataTable.SelectedRows[0].Cells[9].Value;
                questions.DateModified = (DateTime)DataTable.SelectedRows[0].Cells[10].Value;


                //AddColumn((DataTable) DataTable.DataSource);

                //cmbStages
                ComboboxItem itemBoxEnum = new ComboboxItem();
                itemBoxEnum.Text = (string)DataTable.SelectedRows[0].Cells[11].Value;
                itemBoxEnum.Value = (int)DataTable.SelectedRows[0].Cells[1].Value;
                //cmbVacancy
                ComboboxItem itemBoxVacancy = new ComboboxItem();
                itemBoxVacancy.Text = (string)DataTable.SelectedRows[0].Cells[12].Value;
                itemBoxVacancy.Value = (int)DataTable.SelectedRows[0].Cells[2].Value;

                cmbEnum.Text = itemBoxEnum.Text;
                cmbVacancy.Text = itemBoxVacancy.Text;

                this.AcceptButton = btnSave;
            }
            else
            {
                cmbEnum.Text = "";
                cmbVacancy.Text = "";
                questions.Question = "";                
                this.AcceptButton = btnNew;
            }

            txtCandidateId.Text = questions.QuestionsId.ToString();
            txtQuestion.Text = questions.Question.ToString();
            txtMaxLength.Value = questions.MaxLength;
            chkRequired.Checked = questions.Required;
            chkActive.Checked = questions.Active;
            
            lblDateCreated.Text = questions.DateCreated!=null ? questions.DateCreated.ToString() : "";
            lblNameCreated.Text = questions.NameCreated;
            lblNameModified.Text = questions.NameModified;
            lblDateModified.Text = questions.DateModified!=null ? questions.DateModified.ToString() :  "";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataTable.ClearSelection();

            txtCandidateId.Text = string.Empty;
            cmbEnum.Text = "";
            cmbVacancy.Text = "";
            txtQuestion.Text = string.Empty;            
            txtMaxLength.Value = 0;
            
            chkRequired.Checked = false;
            chkActive.Checked = false;
            lblDateCreated.Text = string.Empty;
            lblNameCreated.Text = string.Empty;
            lblNameModified.Text = string.Empty;
            lblDateModified.Text = string.Empty;
            btnNew.Enabled = false;
            btnSave.Enabled = true;

            cmbEnum.Focus();
        }

        private void InitialCmbBoxes(Dictionary<int, string> dataTable, int type)
        {
            if (dataTable != null)
            {
                Dictionary<int, string> pairs = dataTable;

                if (type == 1)
                    cmbVacancy.Items.Clear();
                else if (type == 2)
                    cmbEnum.Items.Clear();


                foreach (var item in pairs)
                {
                    ComboboxItem itemBox = new ComboboxItem();
                    itemBox.Text = item.Value;
                    itemBox.Value = item.Key;

                    if (type == 1)
                        cmbVacancy.Items.Add(itemBox);
                    else if (type == 2)
                        cmbEnum.Items.Add(itemBox);
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            DateTime now = DateTime.Now;
            Entities.Formats.QuestionsFormat questions = new Entities.Formats.QuestionsFormat();
            if (!btnNew.Enabled)
            {
                questions.EnumTypeId = dictionaryEnum.FirstOrDefault(x => x.Value == cmbEnum.Text).Key;
                questions.VacancyId = dictionaryVacancy.FirstOrDefault(x => x.Value == cmbVacancy.Text).Key;
                questions.Question = txtQuestion.Text;
                questions.MaxLength = (int)txtMaxLength.Value;                
                questions.Required = chkRequired.Checked;
                questions.Active = chkActive.Checked;
                questions.DateCreated = now;
                questions.NameCreated = Program.LoginUser;
                questions.DateModified = now;
                questions.NameModified = Program.LoginUser;
            }
            else
            {
                questions.EnumTypeId = dictionaryEnum.FirstOrDefault(x => x.Value == cmbEnum.Text).Key;
                questions.VacancyId = dictionaryVacancy.FirstOrDefault(x => x.Value == cmbVacancy.Text).Key;
                questions.Question = txtQuestion.Text;
                questions.MaxLength = (int)txtMaxLength.Value;
                questions.Required = chkRequired.Checked;                
                questions.Active = chkActive.Checked;
                questions.DateCreated = (DateTime)DataTable.SelectedRows[0].Cells[10].Value;
                questions.NameCreated = (string)DataTable.SelectedRows[0].Cells[9].Value;
                questions.DateModified = now;
                questions.NameModified = Program.LoginUser;
            }

            string result = "";

            try
            {                
                if (!btnNew.Enabled)
                {
                    result = await ApiControl<Entities.Formats.QuestionsFormat>.Post(Program.BaseUrl + "Questions/AddQuestions", questions);
                }
                else
                {
                    questions.DateCreated = DateTime.Parse(lblDateCreated.Text);
                    questions.NameCreated = lblNameCreated.Text;
                    result = await ApiControl<Entities.Formats.QuestionsFormat>.Put(Program.BaseUrl + "Questions/UpdateQuestions/" + txtCandidateId.Text, questions);
                }

                if (result == "")
                {
                    MessageBox.Show("Service is not working", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = true;
                }
                else
                {
                    FormatData<QuestionsFormat> information = new FormatData<QuestionsFormat>();
                    var serializer = new JsonSerializer();

                    using (var sr = new StreamReader(result))
                    using (var jsonTextReader = new JsonTextReader(sr))
                    {
                        var jsObj = serializer.Deserialize<FormatData<User>>(jsonTextReader);
                    }
                    //information = JsonSerializer.Deserialize<FormatData<QuestionsFormat>>(result);
                    MessageBox.Show(information.MessageToFrontEnd);
                    bool initial = InitialTable().Result;
                    btnNew.Enabled = true;
                    btnSave.Enabled = false;

                    txtCandidateId.Text = string.Empty;
                    cmbEnum.Text = "";
                    cmbVacancy.Text = "";
                    txtQuestion.Text = string.Empty;
                    txtMaxLength.Value = 0;
                    chkRequired.Checked = false;
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

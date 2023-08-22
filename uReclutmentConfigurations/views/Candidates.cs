using Entities;
using Entities.DataContext;
using Entities.Formats;
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
    public partial class Candidates : Form
    {
        private Dictionary<int, string> dictionaryVacancy = new Dictionary<int, string>();
        private Dictionary<int, Entities.DataContext.VacancyFormat> dictionaryVacancyAll = new Dictionary<int, Entities.DataContext.VacancyFormat>();
        private Dictionary<int, string> dictionaryStages = new Dictionary<int, string>();
        private Dictionary<int, Entities.DataContext.Stages> dictionaryStagesAll = new Dictionary<int, Entities.DataContext.Stages>();
        private Dictionary<int, Entities.DataContext.Files> dictionaryFiles = new Dictionary<int, Entities.DataContext.Files>();
        public Candidates()
        {
            InitializeComponent();
            InitialCombo("");


            //Contact
            string value = "";
            Program.Settings.TryGetValue("Contact", out value);
            if (value != "")
            {
                string[] list = value.Split(",");
                cmbContact.Items.AddRange(list);
            }
            //Recluter
            string value2 = "";
            Program.Settings.TryGetValue("Recruiter", out value2);
            if (value2 != "")
            {
                string[] list = value2.Split(",");
                cmbRecluter.Items.AddRange(list);
            }



            //RejectCandidate
            string value3 = "";
            Program.Settings.TryGetValue("RejectCandidate", out value3);
            if (value3 != "")
            {
                string[] list = value3.Split(",");
                cmbRejectCandidate.Items.AddRange(list);
            }
            //RejectEmcor
            string value4 = "";
            Program.Settings.TryGetValue("RejectEmcor", out value4);
            if (value4 != "")
            {
                string[] list = value4.Split(",");
                cmbRejectEmcor.Items.AddRange(list);
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void InitialCombo(string tags)
        {
            //this.listBox1.FormattingEnabled = true;
            //this.listBox1.HorizontalScrollbar = true;
            //this.listBox1.Items.AddRange(new object[] {
            //"Item 1, column 1",
            //"Item 2, column 1",
            //"Item 3, column 1",
            //"Item 4, column 1",
            //"Item 5, column 1",
            //"Item 1, column 2",
            //"Item 2, column 2",
            //"Item 3, column 2"});
            //this.listBox1.Location = new System.Drawing.Point(0, 0);
            //this.listBox1.MultiColumn = true;
            //this.listBox1.Name = "listBox1";
            //this.listBox1.ScrollAlwaysVisible = true;
            //this.listBox1.Size = new System.Drawing.Size(120, 95);
            //this.listBox1.TabIndex = 0;
            //this.listBox1.ColumnWidth = 85;
        }

        public async Task<bool> InitialVacancys()
        {
            List<Entities.DataContext.VacancyFormat> dataGet = await ApiControl<Entities.DataContext.VacancyFormat>.GetDictionary(Program.BaseUrl + "Vacancy/GetAllVacancy");
            //
            dictionaryVacancy = dataGet.ToDictionary(keySelector: x => x.VacancyId, elementSelector: x => x.Name);
            dictionaryVacancyAll = dataGet.ToDictionary(keySelector: x => x.VacancyId, elementSelector: x => x);
            return true;
        }
        public async Task<bool> InitialStages()
        {
            List<Entities.DataContext.Stages> dataGet = await ApiControl<Entities.DataContext.Stages>.GetDictionary(Program.BaseUrl + "Stages/GetAllStages");
            //
            dictionaryStages = dataGet.ToDictionary(keySelector: x => x.StagesId, elementSelector: x => x.Name);
            dictionaryStagesAll = dataGet.ToDictionary(keySelector: x => x.StagesId, elementSelector: x => x);
            return true;
        }
        public async Task<bool> InitialTable()
        {
            string error = string.Empty;

            DataTable dataGet = await ApiControl<Entities.DataContext.Candidates>.GetDataTable(Program.BaseUrl + "Candidates/GetAllCandidates");

            //first we create the first table of active and then we will sort that table of ids 
            DataTable dtActive = new DataTable();
            dtActive = dataGet.Clone();
            dtActive.Clear();
            DataTable dtNOActive = new DataTable();
            dtNOActive = dataGet.Clone();
            dtNOActive.Clear();
            foreach (DataRow dr in dataGet.Rows)
            {
                if ((bool)dr[8])
                    dtActive.ImportRow(dr);
                else
                    dtNOActive.ImportRow(dr);
            }
            dtActive.DefaultView.Sort = "CandidatesId desc";
            dtNOActive.DefaultView.Sort = "CandidatesId desc";

            dtActive.Merge(dtNOActive);

            btnNew.Enabled = true;
            if (dataGet.Rows.Count == 0)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;

            AddColumn(dtActive, "StageName", 1);
            AddColumn(dtActive, "VacancyName", 2);

            InitialCmbBoxes(dictionaryVacancy, 1);
            InitialCmbBoxes(dictionaryStages, 2);



            DataTable.DataSource = dtActive;
            //DataTable.Columns[18].Visible = false;
            DataTable.Columns[19].Visible = false;
            DataTable.Columns[20].Visible = false;
            DataTable.Columns[21].Visible = false;
            DataTable.Columns[21].Visible = false;
            DataTable.Columns[22].Visible = false;
            DataTable.Sort(DataTable.Columns[8], ListSortDirection.Descending);
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
                    dictionaryStages.TryGetValue(int.Parse(item.ItemArray[position].ToString()), out value);

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
            Entities.Formats.CandidatesFormat cancidate = new Entities.Formats.CandidatesFormat();
            if (DataTable.SelectedRows.Count != 0)
            {

                InitialTreeFiles((int)DataTable.SelectedRows[0].Cells[0].Value);

                

                cancidate.CandidatesId = (int)DataTable.SelectedRows[0].Cells[0].Value;

                cancidate.StagesId = (int)DataTable.SelectedRows[0].Cells[1].Value;
                cancidate.VacancyId = (int)DataTable.SelectedRows[0].Cells[2].Value;
                cancidate.Name = (string)DataTable.SelectedRows[0].Cells[3].Value;
                cancidate.Age = (int)DataTable.SelectedRows[0].Cells[4].Value;
                cancidate.Address = (string)DataTable.SelectedRows[0].Cells[5].Value;
                cancidate.City = (string)DataTable.SelectedRows[0].Cells[6].Value;
                cancidate.Country = (string)DataTable.SelectedRows[0].Cells[7].Value;


                cancidate.Active = (bool)DataTable.SelectedRows[0].Cells[8].Value;
                cancidate.NameCreated = (string?)DataTable.SelectedRows[0].Cells[9].Value;
                cancidate.DateCreated = (DateTime)DataTable.SelectedRows[0].Cells[10].Value;
                cancidate.NameModified = (string?)DataTable.SelectedRows[0].Cells[11].Value;
                cancidate.DateModified = (DateTime)DataTable.SelectedRows[0].Cells[12].Value;


                cancidate.Notes = (string?)DataTable.SelectedRows[0].Cells[13].Value;
                cancidate.RecluterName = (string?)DataTable.SelectedRows[0].Cells[14].Value;
                cancidate.Tags = (string?)DataTable.SelectedRows[0].Cells[15].Value;
                cancidate.ContactSource = (string?)DataTable.SelectedRows[0].Cells[16].Value;
                cancidate.RejectionEmcor = (string?)DataTable.SelectedRows[0].Cells[17].Value;
                cancidate.RejectionCandidate = (string?)DataTable.SelectedRows[0].Cells[18].Value;


                //AddColumn((DataTable) DataTable.DataSource);

                //cmbStages
                var x1 = DataTable.SelectedRows[0].Cells[23].Value;
                ComboboxItem itemBoxStages = new ComboboxItem();
                itemBoxStages.Text = x1 != null ? (string)x1 : "";
                itemBoxStages.Value = (int)DataTable.SelectedRows[0].Cells[1].Value;
                //cmbVacancy
                ComboboxItem itemBoxVacancy = new ComboboxItem();
                itemBoxVacancy.Text = DataTable.SelectedRows[0].Cells[24] != null ? (string)DataTable.SelectedRows[0].Cells[24].Value : "";
                itemBoxVacancy.Value = (int)DataTable.SelectedRows[0].Cells[2].Value;

                cmbStages.Text = itemBoxStages.Text;
                cmbVacancy.Text = itemBoxVacancy.Text;

                this.AcceptButton = btnSave;
            }
            else
            {
                cmbStages.Text = "";
                cmbVacancy.Text = "";

                cmbContact.Text = "";
                cmbRecluter.Text = "";
                cmbRejectCandidate.Text = "";
                cmbRejectEmcor.Text = "";
                this.AcceptButton = btnNew;
            }

            txtCandidateId.Text = cancidate.CandidatesId.ToString();
            txtName.Text = cancidate.Name;
            txtAge.Value = cancidate.Age;
            txtAdd.Text = cancidate.Address;
            txtCity.Text = cancidate.City;
            cmbCountry.Text = cancidate.Country;

            txtNotes.Text = cancidate.Notes;
            cmbRecluter.Text = cancidate.RecluterName;
            txtTags.Text = cancidate.Tags;
            cmbContact.Text = cancidate.ContactSource;
            cmbRejectEmcor.Text = cancidate.RejectionEmcor;
            cmbRejectCandidate.Text = cancidate.RejectionCandidate;


            chkActive.Checked = cancidate.Active;
            lblDateCreated.Text = cancidate.DateCreated != null && cancidate.DateCreated != new DateTime() ? cancidate.DateCreated.ToString() : "";
            lblNameCreated.Text = cancidate.NameCreated;
            lblNameModified.Text = cancidate.NameModified;
            lblDateModified.Text = cancidate.DateModified != null && cancidate.DateModified != new DateTime() ? cancidate.DateModified.ToString() : "";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataTable.ClearSelection();

            txtCandidateId.Text = string.Empty;
            cmbStages.Text = "";
            cmbVacancy.Text = "";
            txtName.Text = string.Empty;
            txtAdd.Text = string.Empty;
            txtAge.Value = 0;
            txtCity.Text = string.Empty;
            cmbCountry.Text = "";
            chkActive.Checked = false;

            cmbContact.Text = string.Empty;
            cmbRecluter.Text = string.Empty;
            cmbRejectEmcor.Text = string.Empty;
            cmbRejectCandidate.Text = string.Empty;
            txtTags.Text = string.Empty;
            txtNotes.Text = string.Empty;

            lblDateCreated.Text = string.Empty;
            lblNameCreated.Text = string.Empty;
            lblNameModified.Text = string.Empty;
            lblDateModified.Text = string.Empty;
            btnNew.Enabled = false;
            btnSave.Enabled = true;

            cmbStages.Focus();
        }

        private void InitialCmbBoxes(Dictionary<int, string> dataTable, int type)
        {
            if (dataTable != null)
            {
                Dictionary<int, string> pairs = dataTable;

                if (type == 1)
                    cmbVacancy.Items.Clear();
                else if (type == 2)
                    cmbStages.Items.Clear();


                foreach (var item in pairs)
                {
                    ComboboxItem itemBox = new ComboboxItem();
                    itemBox.Text = item.Value;
                    itemBox.Value = item.Key;

                    if (type == 1)
                        cmbVacancy.Items.Add(itemBox);
                    else if (type == 2)
                        cmbStages.Items.Add(itemBox);
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            DateTime now = DateTime.Now;
            Entities.Formats.CandidatesFormat candidates = new Entities.Formats.CandidatesFormat();
            if (!btnNew.Enabled)
            {
                candidates.StagesId = dictionaryStages.FirstOrDefault(x => x.Value == cmbStages.Text).Key;
                candidates.VacancyId = dictionaryVacancy.FirstOrDefault(x => x.Value == cmbVacancy.Text).Key;

                candidates.Name = txtName.Text;
                candidates.Address = txtAdd.Text;
                candidates.Age = int.Parse(txtAge.Text);
                candidates.City = txtCity.Text;
                candidates.Country = cmbCountry.Text;

                candidates.ContactSource = cmbContact.Text;
                candidates.RecluterName = cmbRecluter.Text;
                candidates.RejectionCandidate = cmbRejectCandidate.Text;
                candidates.RejectionEmcor = cmbRejectEmcor.Text;
                candidates.Notes = txtNotes.Text;
                candidates.Tags = txtTags.Text;

                candidates.Active = chkActive.Checked;
                candidates.DateCreated = now;
                candidates.NameCreated = Program.LoginUser;
                candidates.DateModified = now;
                candidates.NameModified = Program.LoginUser;
            }
            else
            {
                candidates.StagesId = dictionaryStages.FirstOrDefault(x => x.Value == cmbStages.Text).Key;
                candidates.VacancyId = dictionaryVacancy.FirstOrDefault(x => x.Value == cmbVacancy.Text).Key;

                candidates.Name = txtName.Text;
                candidates.Address = txtAdd.Text;
                candidates.Age = int.Parse(txtAge.Text);
                candidates.City = txtCity.Text;
                candidates.Country = cmbCountry.Text;

                candidates.ContactSource = cmbContact.Text;
                candidates.RecluterName = cmbRecluter.Text;
                candidates.RejectionCandidate = cmbRejectCandidate.Text;
                candidates.RejectionEmcor = cmbRejectEmcor.Text;
                candidates.Notes = txtNotes.Text;
                candidates.Tags = txtTags.Text;

                candidates.Active = chkActive.Checked;
                candidates.DateCreated = (DateTime)DataTable.SelectedRows[0].Cells[10].Value;
                candidates.NameCreated = (string?)DataTable.SelectedRows[0].Cells[9].Value;
                candidates.DateModified = now;
                candidates.NameModified = Program.LoginUser;
            }

            string result = "";

            try
            {
                //create
                if (!btnNew.Enabled)
                {
                    result = await ApiControl<Entities.Formats.CandidatesFormat>.Post(Program.BaseUrl + "Candidates/AddCandidates", candidates);
                }
                else
                {
                    //update                    
                    //settings.DateCreated = DateTime.Parse(lblDateCreated.Text);
                    //settings.NameCreated = lblNameCreated.Text;
                    result = await ApiControl<Entities.Formats.CandidatesFormat>.Put(Program.BaseUrl + "Candidates/UpdateCandidates/" + txtCandidateId.Text, candidates);
                }

                if (result == "")
                {
                    MessageBox.Show("Service is not working", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = true;
                }
                else
                {
                    FormatData<CandidatesFormat> information = new FormatData<CandidatesFormat>();
                    information = JsonSerializer.Deserialize<FormatData<CandidatesFormat>>(result);
                    MessageBox.Show(information.MessageToFrontEnd);
                    bool initial = InitialTable().Result;
                    btnNew.Enabled = true;
                    btnSave.Enabled = false;
                    txtCandidateId.Text = string.Empty;
                    cmbStages.Text = "";
                    cmbVacancy.Text = "";
                    txtName.Text = string.Empty;
                    txtAdd.Text = string.Empty;
                    txtAge.Value = 0;
                    txtCity.Text = string.Empty;
                    cmbCountry.Text = "";
                    chkActive.Checked = false;
                    cmbContact.Text = string.Empty;
                    cmbRecluter.Text = string.Empty;
                    cmbRejectEmcor.Text = string.Empty;
                    cmbRejectCandidate.Text = string.Empty;
                    txtTags.Text = string.Empty;
                    txtNotes.Text = string.Empty;
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


        private async void treeViewFiles_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            //selecter for files
            if (treeViewFiles.SelectedNode != null)
            {
                pdfDocumentView1.Visible = true;

                string id = treeViewFiles.SelectedNode.Text.Split('|').First();
                if (id != "Files")
                {
                    string path = dictionaryFiles[int.Parse(id)].Path;
                    treeViewFiles.Enabled = false;
                    path = path.Replace('\\', 'µ');
                    string result = await ApiControl<byte[]>.Get(Program.BaseUrl + "Files/GetFile/" + path + "-ureclutmentKey1");
                    if (result != "")
                    {
                        byte[] buffer = JsonSerializer.Deserialize<byte[]>(result);
                        MemoryStream ms = new MemoryStream(buffer);
                        pdfDocumentView1.Load(ms);
                        treeViewFiles.Enabled = true;
                    }
                }
            }
        }

        public async void InitialTreeFiles(int CandidateId)
        {
            pdfDocumentView1.Unload();
            List<Entities.DataContext.Files> dataGet = await ApiControl<Entities.DataContext.Files>.GetDictionary(Program.BaseUrl + "Files/GetById/" + CandidateId.ToString());
            TreeNode nodeMain = new TreeNode();
            nodeMain.Text = "Files";
            dictionaryFiles.Clear();
            foreach (var item in dataGet)
            {
                dictionaryFiles.Add(item.FilesId, item);
                TreeNode nodeSecond = new TreeNode();
                nodeSecond.Text = item.FilesId + "|" + item.Name;
                nodeMain.Nodes.Add(nodeSecond);
            }
            treeViewFiles.Nodes.Clear();
            treeViewFiles.Nodes.Add(nodeMain);
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}

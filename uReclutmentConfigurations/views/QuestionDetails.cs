using Entities;
using Entities.DataContext;
using Entities.Formats;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
    public partial class QuestionDetails : Form
    {
        private Dictionary<int, string> dictionaryQuestion = new Dictionary<int, string>();
        private Dictionary<int, Entities.Formats.QuestionsFormat> dictionaryQuestionAll = new Dictionary<int, Entities.Formats.QuestionsFormat>();
        private Dictionary<int, string> dictionaryCandidates = new Dictionary<int, string>();
        private Dictionary<int, Entities.DataContext.Candidates> dictionaryCandidatesAll = new Dictionary<int, Entities.DataContext.Candidates>();
        private Dictionary<int, string> dictionaryComments = new Dictionary<int, string>();
        private List<CommentsFormat> comments= new List<CommentsFormat>();
        public QuestionDetails()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public async Task<bool> InitialQuestions()
        {
            List<Entities.Formats.QuestionsFormat> dataGet = await ApiControl<Entities.Formats.QuestionsFormat>.GetDictionary(Program.BaseUrl + "Questions/GetAllQuestions");
            
            dictionaryQuestion = dataGet.ToDictionary(keySelector: x => x.QuestionsId, elementSelector: x => x.QuestionsId.ToString());
            dictionaryQuestionAll = dataGet.ToDictionary(keySelector: x => x.QuestionsId, elementSelector: x => x);
            return true;
        }
        public async Task<bool> InitialCandidates()
        {
            List<Entities.DataContext.Candidates> dataGet = await ApiControl<Entities.DataContext.Candidates>.GetDictionary(Program.BaseUrl + "Candidates/GetAllCandidates");
            
            dictionaryCandidates = dataGet.ToDictionary(keySelector: x => x.CandidatesId, elementSelector: x => x.Name);
            dictionaryCandidatesAll = dataGet.ToDictionary(keySelector: x => x.CandidatesId, elementSelector: x => x);
            return true;
        }
        public async Task<bool> InitialComments()
        {
            List<Entities.Formats.CommentsFormat> dataGet = await ApiControl<Entities.Formats.CommentsFormat>.GetDictionary(Program.BaseUrl + "Comments/GetAllComments");            
            dictionaryComments = dataGet.ToDictionary(keySelector: x => x.CommentsId, elementSelector: x => x.Value);
            comments = dataGet;
            return true;
        }

        public async Task<bool> InitialTable()
        {
            string error = string.Empty;

            DataTable dataGet = await ApiControl<Entities.Formats.QuestionDetailsFormat>.GetDataTable(Program.BaseUrl + "QuestionDetails/GetAllQuestionDetails");

            //first we create the first table of active and then we will sort that table of ids 
            DataTable dtActive = new DataTable();
            dtActive = dataGet.Clone();
            dtActive.Clear();
            DataTable dtNOActive = new DataTable();
            dtNOActive = dataGet.Clone();
            dtNOActive.Clear();
            foreach (DataRow dr in dataGet.Rows)
            {
                if ((bool)dr[4])
                    dtActive.ImportRow(dr);
                else
                    dtNOActive.ImportRow(dr);
            }
            dtActive.DefaultView.Sort = "QuestionDetailsId desc";
            dtNOActive.DefaultView.Sort = "QuestionDetailsId desc";

            dtActive.Merge(dtNOActive);

            btnNew.Enabled = true;
            if (dataGet.Rows.Count == 0)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;

            InitialCmbBoxes(dictionaryCandidates, 1);
            InitialCmbBoxes(dictionaryQuestion, 2);

            //AddColumn(dtActive, "Question", 1);
            //AddColumn(dtActive, "CandidateName", 2);

            DataTable.DataSource = dtActive;            
            DataTable.Sort(DataTable.Columns[4], ListSortDirection.Descending);
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
                    dictionaryCandidates.TryGetValue(int.Parse(item.ItemArray[position].ToString()), out value);
                else
                    dictionaryQuestion.TryGetValue(int.Parse(item.ItemArray[position].ToString()), out value);

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
            Entities.Formats.QuestionDetailsFormat questions = new Entities.Formats.QuestionDetailsFormat();
            if (DataTable.SelectedRows.Count != 0)
            {
                btnSaveComment.Enabled = true;
                btnNewComment.Enabled = true;

                questions.QuestionDetailsId = (int)DataTable.SelectedRows[0].Cells[0].Value;
                questions.CandidateName = (string)DataTable.SelectedRows[0].Cells[1].Value;
                questions.Question = (string)DataTable.SelectedRows[0].Cells[2].Value;
                questions.Answer = (string)DataTable.SelectedRows[0].Cells[3].Value;
                questions.Active = (bool)DataTable.SelectedRows[0].Cells[4].Value;
                questions.QuestionsId = (int)DataTable.SelectedRows[0].Cells[5].Value;
                questions.CandidatesId = (int)DataTable.SelectedRows[0].Cells[6].Value;                
                                
                questions.DateCreated = (DateTime)DataTable.SelectedRows[0].Cells[7].Value;                
                questions.DateModified = (DateTime)DataTable.SelectedRows[0].Cells[8].Value;


                //AddColumn((DataTable) DataTable.DataSource);

                //cmbStages
                ComboboxItem itemBoxQuestion = new ComboboxItem();
                itemBoxQuestion.Text = DataTable.SelectedRows[0].Cells[5].Value.ToString();
                itemBoxQuestion.Value = (int)DataTable.SelectedRows[0].Cells[5].Value;
                //cmbVacancy
                ComboboxItem itemBoxCandidate = new ComboboxItem();
                itemBoxCandidate.Text = (string)DataTable.SelectedRows[0].Cells[1].Value;
                itemBoxCandidate.Value = (int)DataTable.SelectedRows[0].Cells[6].Value;

                cmbQuestionId.Text = itemBoxQuestion.Text;
                cmbCandidate.Text = itemBoxCandidate.Text;

                this.AcceptButton = btnSave;

                //Comments
                List<CommentsFormat> list = comments.FindAll(x=>x.QuestionDetailsId== questions.QuestionDetailsId);
                DataTable table= ApiControl<CommentsFormat>.ToDataTable(list);

                DataTableComments.DataSource= table;
                DataTableComments.Sort(DataTableComments.Columns[3], ListSortDirection.Descending);

            }
            else
            {
                cmbQuestionId.Text = "";
                cmbCandidate.Text = "";
                questions.Question = "";                
                this.AcceptButton = btnNew;
            }

            txtAnswerId.Text = questions.QuestionsId!=null ? questions.QuestionsId.ToString() : "";
            txtAnswer.Text = questions.Answer!=null ? questions.Answer.ToString() : "";
            txtQuestion.Text = questions.Question != null ? questions.Question.ToString() : "";
            chkActive.Checked = questions.Active;
            
            lblDateCreated.Text = questions.DateCreated!=null ? questions.DateCreated.ToString() : "";
            lblNameCreated.Text = "";
            lblNameModified.Text = "";
            lblDateModified.Text = questions.DateModified!=null ? questions.DateModified.ToString() :  "";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataTable.ClearSelection();

            txtAnswerId.Text = string.Empty;
            cmbQuestionId.Text = "";
            cmbCandidate.Text = "";
            txtAnswer.Text = string.Empty;            
            txtQuestion.Text = string.Empty;
            chkActive.Checked = false;
            lblDateCreated.Text = string.Empty;
            lblNameCreated.Text = string.Empty;
            lblNameModified.Text = string.Empty;
            lblDateModified.Text = string.Empty;
            btnNew.Enabled = false;
            btnSave.Enabled = true;


            btnSaveComment.Enabled = false;
            btnNewComment.Enabled = false;
            cmbQuestionId.Focus();
        }

        private void InitialCmbBoxes(Dictionary<int, string> dataTable, int type)
        {
            if (dataTable != null)
            {
                Dictionary<int, string> pairs = dataTable;

                if (type == 1)
                    cmbCandidate.Items.Clear();
                else if (type == 2)
                    cmbQuestionId.Items.Clear();


                foreach (var item in pairs)
                {
                    ComboboxItem itemBox = new ComboboxItem();
                    itemBox.Text = item.Value;
                    itemBox.Value = item.Key;

                    if (type == 1)
                        cmbCandidate.Items.Add(itemBox);
                    else if (type == 2)
                        cmbQuestionId.Items.Add(itemBox);
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            DateTime now = DateTime.Now;
            Entities.Formats.QuestionDetailsFormat questions = new Entities.Formats.QuestionDetailsFormat();
            if (!btnNew.Enabled)
            {                
                questions.CandidatesId = dictionaryCandidates.FirstOrDefault(x => x.Value == cmbCandidate.Text).Key;
                questions.Answer = txtAnswer.Text;
                questions.Question = txtQuestion.Text;
                questions.QuestionsId = int.Parse(cmbQuestionId.Text);
                questions.Active = chkActive.Checked;
                questions.DateCreated = now;                
                questions.DateModified = now;                
            }
            else
            {
                questions.CandidatesId = dictionaryCandidates.FirstOrDefault(x => x.Value == cmbCandidate.Text).Key;
                questions.Answer = txtAnswer.Text;
                questions.Question = txtQuestion.Text;
                questions.QuestionsId = int.Parse(cmbQuestionId.Text);
                questions.Active = chkActive.Checked;
                questions.DateCreated = (DateTime)DataTable.SelectedRows[0].Cells[7].Value;
                questions.DateModified = now;                
            }

            string result = "";

            try
            {
                if (!btnNew.Enabled)
                {
                    result = await ApiControl<Entities.Formats.QuestionDetailsFormat>.Post(Program.BaseUrl + "QuestionDetails/AddQuestionDetails", questions);
                }
                else
                {                                        
                    result = await ApiControl<Entities.Formats.QuestionDetailsFormat>.Put(Program.BaseUrl + "QuestionDetails/UpdateQuestionDetails/" + txtAnswerId.Text, questions);
                }

                if (result == "")
                {
                    MessageBox.Show("Service is not working", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = true;
                }
                else
                {
                    FormatData<QuestionDetailsFormat> information = new FormatData<QuestionDetailsFormat>();
                    information = JsonSerializer.Deserialize<FormatData<QuestionDetailsFormat>>(result);
                    MessageBox.Show(information.MessageToFrontEnd);
                    bool initial = InitialTable().Result;
                    btnNew.Enabled = true;
                    btnSave.Enabled = false;

                    txtAnswerId.Text = string.Empty;
                    cmbQuestionId.Text = "";
                    cmbCandidate.Text = "";
                    txtAnswer.Text = string.Empty;
                    txtQuestion.Text = string.Empty;
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cmbQuestionId_SelectedIndexChanged(object sender, EventArgs e)
        {
            //change the text in the txt of the question, this just if the user want to change the question and the answer 
            QuestionsFormat format = new QuestionsFormat();
            if (cmbQuestionId.Text != null && cmbQuestionId.Text != "")
            {
                if (dictionaryQuestionAll.TryGetValue(int.Parse(cmbQuestionId.Text), out format))
                    txtQuestion.Text = format.Question;
                else
                    txtQuestion.Text = "";
            }            
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void btnNewComment_Click(object sender, EventArgs e)
        {
            DataTableComments.ClearSelection();

            txtComment.Text = string.Empty;
            txtCommentId.Text = string.Empty;
            chkActiveComment.Checked = false;

            lblDateCreatedComment.Text = string.Empty;
            lblNameCreateComment.Text = string.Empty;
            lblNameModifiedComment.Text = string.Empty;
            lblDateModifiedComment.Text = string.Empty;
            btnNewComment.Enabled = false;
            btnSaveComment.Enabled = true;

            txtComment.Focus();
        }

        private async void btnSaveComment_Click(object sender, EventArgs e)
        {
            btnSaveComment.Enabled = false;
            DateTime now = DateTime.Now;
            Entities.Formats.CommentsFormat comment = new Entities.Formats.CommentsFormat();
            if (!btnNewComment.Enabled)
            {
                comment.Value = txtComment.Text;
                comment.Active = chkActiveComment.Checked;
                comment.QuestionDetailsId = (int)DataTable.SelectedRows[0].Cells[0].Value;
                

                comment.NameCreated = Program.LoginUser;
                comment.DateCreated = now;
                comment.NameModified = Program.LoginUser;
                comment.DateModified = now;
            }
            else
            {
                comment.Value = txtComment.Text;
                comment.Active = chkActiveComment.Checked;
                comment.QuestionDetailsId = (int)DataTable.SelectedRows[0].Cells[0].Value;


                comment.NameCreated = lblNameCreateComment.Text;
                comment.DateCreated = DateTime.Parse(lblDateCreatedComment.Text);
                comment.NameModified = Program.LoginUser;
                comment.DateModified = now;
            }

            string result = "";

            try
            {
                if (!btnNewComment.Enabled)
                {
                    result = await ApiControl<Entities.Formats.CommentsFormat>.Post(Program.BaseUrl + "Comments/AddComments", comment);
                }
                else
                {
                    result = await ApiControl<Entities.Formats.CommentsFormat>.Put(Program.BaseUrl + "Comments/UpdateComments/" + txtCommentId.Text, comment);
                }

                if (result == "")
                {
                    MessageBox.Show("Service is not working", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = true;
                }
                else
                {
                    FormatData<CommentsFormat> information = new FormatData<CommentsFormat>();
                    information = JsonSerializer.Deserialize<FormatData<CommentsFormat>>(result);
                    MessageBox.Show(information.MessageToFrontEnd);
                    await InitialComments();
                    bool initial = InitialTable().Result;                    

                    DataTableComments.DataSource = new DataTable();

                    txtComment.Text = string.Empty;
                    txtCommentId.Text = string.Empty;
                    chkActiveComment.Checked = false;

                    lblDateCreatedComment.Text = string.Empty;
                    lblNameCreateComment.Text = string.Empty;
                    lblNameModifiedComment.Text = string.Empty;
                    lblDateModifiedComment.Text = string.Empty;

                    btnNewComment.Enabled = false;
                    btnSaveComment.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                btnSave.Enabled = true;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataTableComments_SelectionChanged(object sender, EventArgs e)
        {
            btnNewComment.Enabled = true;
            btnSaveComment.Enabled= true;
            if (DataTableComments.SelectedRows.Count != 0)
            {
                txtCommentId.Text = ((int)DataTableComments.SelectedRows[0].Cells[0].Value).ToString();
                txtComment.Text = (string)DataTableComments.SelectedRows[0].Cells[2].Value;
                chkActiveComment.Checked = (bool)DataTableComments.SelectedRows[0].Cells[3].Value;

                lblDateCreatedComment.Text = ((DateTime)DataTableComments.SelectedRows[0].Cells[5].Value).ToString();
                lblNameCreateComment.Text = (string)DataTableComments.SelectedRows[0].Cells[4].Value;
                lblNameModifiedComment.Text = (string)DataTableComments.SelectedRows[0].Cells[6].Value;                
                lblDateModifiedComment.Text = ((DateTime)DataTableComments.SelectedRows[0].Cells[7].Value).ToString();
            }
            else
            {
                txtComment.Text = "";
                txtCommentId.Text = "";
                chkActiveComment.Checked = false;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (chkPdf.Checked && chkExcel.Checked)
            {
                string error = "";
                DataTable data = Program.GetDataGridViewAsDataTable(DataTableComments);
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
                DataTable data = Program.GetDataGridViewAsDataTable(DataTableComments);

                if (Program.ExportToPdf(data, out error))
                    MessageBox.Show("The table was Exported in the path of the settings");
                else
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (chkExcel.Checked)
            {
                string error = "";
                DataTable data = Program.GetDataGridViewAsDataTable(DataTableComments);

                if (Program.ExportToExcel(data, out error))
                    MessageBox.Show("The table was Exported in the path of the settings");
                else
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Please select at least one option");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (chkPdf.Checked && chkExcel.Checked)
            {
                string error = "";
                DataTable data = Program.GetDataGridViewAsDataTable(DataTable);
                DataTable data2 = Program.GetDataGridViewAsDataTable(DataTableComments);

                bool pdf = Program.ExportToPdf(data, out error,data2);
                if (!pdf)
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    bool excel = Program.ExportToExcel(data, out error,data2);
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
                DataTable data2 = Program.GetDataGridViewAsDataTable(DataTableComments);
                
                if (Program.ExportToPdf(data, out error, data2))
                    MessageBox.Show("The table was Exported in the path of the settings");
                else
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (chkExcel.Checked)
            {
                string error = "";
                DataTable data = Program.GetDataGridViewAsDataTable(DataTable);
                DataTable data2 = Program.GetDataGridViewAsDataTable(DataTableComments);
                
                if (Program.ExportToExcel(data, out error,data2))
                    MessageBox.Show("The table was Exported in the path of the settings");
                else
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Please select at least one option");
        }
    }
}

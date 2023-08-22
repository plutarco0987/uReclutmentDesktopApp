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
    public partial class Meetings : Form
    {
        private Dictionary<int, string> dictionaryCandidates = new Dictionary<int, string>();
        private Dictionary<int, Entities.DataContext.Candidates> dictionaryCandidatesAll = new Dictionary<int, Entities.DataContext.Candidates>();
        public Meetings()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public async Task<bool> InitialCandidates()
        {
            List<Entities.DataContext.Candidates> dataGet = await ApiControl<Entities.DataContext.Candidates>.GetDictionary(Program.BaseUrl + "Candidates/GetAllCandidates");

            dictionaryCandidates = dataGet.ToDictionary(keySelector: x => x.CandidatesId, elementSelector: x => x.Name);
            dictionaryCandidatesAll = dataGet.ToDictionary(keySelector: x => x.CandidatesId, elementSelector: x => x);
            return true;
        }

        public async Task<bool> InitialTable()
        {
            string error = string.Empty;

            DataTable dataGet = await ApiControl<Entities.Formats.MeetingsFormat>.GetDataTable(Program.BaseUrl + "Meetings/GetAllMeetings");

            ConvertColumnType(dataGet, "Time", typeof(string));
            //first we create the first table of active and then we will sort that table of ids 
            DataTable dtActive = new DataTable();
            dtActive = dataGet.Clone();
            dtActive.Clear();
            DataTable dtNOActive = new DataTable();
            dtNOActive = dataGet.Clone();
            dtNOActive.Clear();



            foreach (DataRow dr in dataGet.Rows)
            {
                dr[3] = MilisecondsToString((string)dr[3]);
                if ((bool)dr[4])
                    dtActive.ImportRow(dr);
                else
                    dtNOActive.ImportRow(dr);
            }
            dtActive.DefaultView.Sort = "MeetingsId desc";
            dtNOActive.DefaultView.Sort = "MeetingsId desc";

            dtActive.Merge(dtNOActive);



            btnNew.Enabled = true;
            if (dataGet.Rows.Count == 0)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;

            InitialCmbBoxes(dictionaryCandidatesAll, 1);

            AddColumn(dtActive, "CandidateName", 1);



            DataTable.DataSource = dtActive;
            DataTable.Sort(DataTable.Columns[5], ListSortDirection.Descending);
            DataTable.ClearSelection();
            return true;
        }

        public void ConvertColumnType(DataTable dt, string columnName, Type newType)
        {
            using (DataColumn dc = new DataColumn(columnName + "New", newType))
            {
                // Add the new column which has the new type, and move it to the ordinal of the old column
                int ordinal = dt.Columns[columnName].Ordinal;
                dt.Columns.Add(dc);
                dc.SetOrdinal(ordinal);

                // Get and convert the values of the old column, and insert them into the new
                foreach (DataRow dr in dt.Rows)
                    dr[dc.ColumnName] = Convert.ChangeType(dr[columnName], newType);

                // Remove the old column
                dt.Columns.Remove(columnName);

                // Give the new column the old column's name
                dc.ColumnName = columnName;
            }
        }

        private string MilisecondsToString(string milisecondsParam)
        {
            long miliseconds = long.Parse(milisecondsParam);
            TimeSpan t = TimeSpan.FromMilliseconds(miliseconds);
            string answer = string.Format("{0}:{1}:{2}:{3}",
                                    t.Hours,
                                    t.Minutes,
                                    t.Seconds,
                                    t.Milliseconds);
            return answer;
        }
        private long milisecondsToLong(string miliseconds,bool three=true)
        {
            long value = 0;

            string[] values = miliseconds.Split(":");

            value = value + int.Parse(values[0]) * 3600000;
            value = value + int.Parse(values[1]) * 60000;
            value = value + int.Parse(values[2]) * 1000;
            if(three)
                value = value + int.Parse(values[3]);


            return value;
        }

        private void AddColumn(DataTable data, string nameColumn, int position)
        {
            data.Columns.Add(nameColumn);
            foreach (DataRow item in data.Rows)
            {
                string value = string.Empty;
                dictionaryCandidates.TryGetValue(int.Parse(item.ItemArray[position].ToString()), out value);

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
            Entities.Formats.MeetingsFormat meetings = new Entities.Formats.MeetingsFormat();
            ComboboxItem itemBoxCandidate = new ComboboxItem();
            if (DataTable.SelectedRows.Count != 0)
            {
                meetings.MeetingsId = (int)DataTable.SelectedRows[0].Cells[0].Value;
                meetings.CandidatesId = (int)DataTable.SelectedRows[0].Cells[1].Value;
                meetings.NumberMeeting = (int)DataTable.SelectedRows[0].Cells[2].Value;
                meetings.Time = milisecondsToLong((string)DataTable.SelectedRows[0].Cells[3].Value);

                meetings.Active = (bool)DataTable.SelectedRows[0].Cells[4].Value;
                meetings.NameCreated = (string?)DataTable.SelectedRows[0].Cells[5].Value;
                meetings.DateCreated = (DateTime)DataTable.SelectedRows[0].Cells[6].Value;
                meetings.NameModified = (string?)DataTable.SelectedRows[0].Cells[7].Value;
                meetings.DateModified = (DateTime)DataTable.SelectedRows[0].Cells[8].Value;


                //AddColumn((DataTable) DataTable.DataSource);

                //cmbStages

                itemBoxCandidate.Text = ((int)DataTable.SelectedRows[0].Cells[1].Value).ToString();
                itemBoxCandidate.Value = (int)DataTable.SelectedRows[0].Cells[1].Value;

                cmbCandidateId.Text = itemBoxCandidate.Text;

                txtCandidateName.Text = (string)DataTable.SelectedRows[0].Cells[9].Value;

                this.AcceptButton = btnSave;
            }
            else
            {
                cmbCandidateId.Text = "";

                this.AcceptButton = btnNew;
            }


            txtMeetingId.Text = meetings.MeetingsId != null ? meetings.MeetingsId.ToString() : "";
            txtNoMeeting.Text = meetings.NumberMeeting != null ? meetings.NumberMeeting.ToString() : "";
            txtTime.Text = MilisecondsToString(meetings.Time != null ? meetings.Time.ToString() : "0");


            chkActive.Checked = meetings.Active;
            lblDateCreated.Text = meetings.DateCreated != null ? meetings.DateCreated.ToString() : "";
            lblNameCreated.Text = meetings.NameCreated;
            lblNameModified.Text = meetings.NameModified;
            lblDateModified.Text = meetings.DateModified != null ? meetings.DateModified.ToString() : "";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DataTable.ClearSelection();

            txtMeetingId.Text = string.Empty;
            cmbCandidateId.Text = "";

            txtNoMeeting.Value = 0;
            txtTime.Text = string.Empty;
            txtCandidateName.Text = string.Empty;

            chkActive.Checked = false;
            lblDateCreated.Text = string.Empty;
            lblNameCreated.Text = string.Empty;
            lblNameModified.Text = string.Empty;
            lblDateModified.Text = string.Empty;
            btnNew.Enabled = false;
            btnSave.Enabled = true;

            cmbCandidateId.Focus();
        }

        private void InitialCmbBoxes(Dictionary<int, Entities.DataContext.Candidates> dataTable, int type)
        {
            if (dataTable != null)
            {
                Dictionary<int, Entities.DataContext.Candidates> pairs = dataTable;

                cmbCandidateId.Items.Clear();


                foreach (var item in pairs)
                {
                    ComboboxItem itemBox = new ComboboxItem();
                    itemBox.Text = item.Value.CandidatesId.ToString();
                    itemBox.Value = item.Key;

                    cmbCandidateId.Items.Add(itemBox);
                }
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            DateTime now = DateTime.Now;
            Entities.Formats.MeetingsFormat meetings = new Entities.Formats.MeetingsFormat();
            if (!btnNew.Enabled)
            {



                meetings.CandidatesId = int.Parse(cmbCandidateId.Text);
                meetings.NumberMeeting = decimal.ToInt32(txtNoMeeting.Value);
                meetings.Time = milisecondsToLong(txtTime.Text);

                meetings.Active = chkActive.Checked;
                meetings.DateCreated = now;
                meetings.NameCreated = Program.LoginUser;
                meetings.DateModified = now;
                meetings.NameModified = Program.LoginUser;
            }
            else
            {
                meetings.CandidatesId = int.Parse(cmbCandidateId.Text);
                meetings.NumberMeeting = decimal.ToInt32(txtNoMeeting.Value);
                meetings.Time = milisecondsToLong(txtTime.Text);

                meetings.Active = chkActive.Checked;
                meetings.DateCreated = (DateTime)DataTable.SelectedRows[0].Cells[6].Value;
                meetings.NameCreated = (string?)DataTable.SelectedRows[0].Cells[5].Value;
                meetings.DateModified = now;
                meetings.NameModified = Program.LoginUser;
            }

            string result = "";

            try
            {
                if (!btnNew.Enabled)
                {
                    result = await ApiControl<Entities.Formats.MeetingsFormat>.Post(Program.BaseUrl + "Meetings/AddMeetings", meetings);
                }
                else
                {
                    result = await ApiControl<Entities.Formats.MeetingsFormat>.Put(Program.BaseUrl + "Meetings/UpdateMeetings/" + txtMeetingId.Text, meetings);
                }

                if (result == "")
                {
                    MessageBox.Show("Service is not working", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = true;
                }
                else
                {
                    FormatData<MeetingsFormat> information = new FormatData<MeetingsFormat>();
                    information = JsonSerializer.Deserialize<FormatData<MeetingsFormat>>(result);
                    MessageBox.Show(information.MessageToFrontEnd);
                    bool initial = InitialTable().Result;
                    btnNew.Enabled = true;
                    btnSave.Enabled = false;

                    txtMeetingId.Text = string.Empty;
                    cmbCandidateId.Text = "";
                    txtNoMeeting.Value = 0;
                    txtTime.Text = string.Empty;
                    txtCandidateName.Text = string.Empty;
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

        private void cmbCandidateId_SelectedIndexChanged(object sender, EventArgs e)
        {
            //change the txt of the name            
            txtCandidateName.Text = dictionaryCandidatesAll.FirstOrDefault(x => x.Value.CandidatesId.ToString() == cmbCandidateId.Text).Value.Name;
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

        private void btnAllTime_Click(object sender, EventArgs e)
        {
            //method for can display the timers

            
            if (DataTable.SelectedRows.Count != 0)
            {
                //checar el tiempo de reuniones de la tabla de un candidato seleccionado
                int idCandidate = (int)DataTable.SelectedRows[0].Cells[1].Value;
                long valueMetting = 0;
                DateTime current = DateTime.Now;
                DateTime now = DateTime.Now;
                foreach (DataGridViewRow item in DataTable.Rows)
                {
                    if (int.Parse(item.Cells[1].Value.ToString())==idCandidate)
                    {
                        valueMetting += milisecondsToLong ((string)DataTable.SelectedRows[0].Cells[3].Value);
                    }
                    if (int.Parse(item.Cells[1].Value.ToString()) == idCandidate && (string)item.Cells[2].Value == "0")
                    {
                        current = (DateTime)DataTable.SelectedRows[0].Cells[6].Value;
                    }
                }
                lblTime.Text= "Meetings Time: " +MilisecondsToString(valueMetting.ToString());
                TimeSpan span = now.Subtract(current);
                lblAllTime.Text = string.Format("All Time= Segundos: {0}; Minutos: {1}; Horas:{2}; Dias:{3};",span.Seconds,span.Minutes,span.Hours,span.Days);
                //checar la primera reunion del candidato seleccionado e imprimir cuanto tiempo le esta tomando hasta la hora de del sistema

            }
            else
            {
                MessageBox.Show("Please select one row", "Information");
            }            
        }
    }
}

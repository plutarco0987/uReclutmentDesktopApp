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
using Microsoft.Web.WebView2.Core;
using System.Diagnostics;
using Entities.Formats;
using System.Xml.Linq;
using Microsoft.VisualBasic;

namespace uReclutmentConfigurations
{


    public partial class Meeting : Form
    {
        private Dictionary<int, string> dictionaryVacancy = new Dictionary<int, string>();
        private Dictionary<int, Entities.DataContext.VacancyFormat> dictionaryVacancyAll = new Dictionary<int, Entities.DataContext.VacancyFormat>();
        private Dictionary<int, string> dictionaryCandidates = new Dictionary<int, string>();
        private Dictionary<int, Entities.DataContext.Candidates> dictionaryCandidatesAll = new Dictionary<int, Entities.DataContext.Candidates>();
        private Dictionary<int, string> dictionaryStages = new Dictionary<int, string>();
        private Dictionary<int, Entities.DataContext.Stages> dictionaryStagesAll = new Dictionary<int, Entities.DataContext.Stages>();

        private Dictionary<int, Entities.DataContext.Files> dictionaryFiles = new Dictionary<int, Entities.DataContext.Files>();

        private Stopwatch stopwatch = new Stopwatch();
        private DataTable dt;
        private static int noteID;
        private int andwerId;
        private int comentId = 0;
        private bool isNewComment = false;

        public Meeting()
        {
            InitializeComponent();
            webView.EnsureCoreWebView2Async();
            webViewMeeting.EnsureCoreWebView2Async();
        }

        public void Initial()
        {
            if (webView != null && webView.CoreWebView2 != null)
                webView.CoreWebView2.Navigate("https://www.Google.com/");

            InitialComboBoxes(cmbCandidates, dictionaryCandidates);
            InitialComboBoxes(cmbVacancy, dictionaryVacancy);

            panel1.BorderStyle = BorderStyle.FixedSingle;



        }
        private void InitialComboBoxes(ComboBox item, Dictionary<int, string> dictionary)
        {
            foreach (KeyValuePair<int, string> entry in dictionary)
            {
                ComboboxItem comboboxItem = new ComboboxItem();
                comboboxItem.Value = entry.Key;
                comboboxItem.Text = entry.Key + " - " + entry.Value;
                item.Items.Add(comboboxItem);
            }
        }

        public async Task<bool> InitialVacancys()
        {
            List<Entities.DataContext.VacancyFormat> dataGet = await ApiControl<Entities.DataContext.VacancyFormat>.GetDictionary(Program.BaseUrl + "Vacancy/GetAllVacancy");
            dataGet = dataGet.FindAll(x => x.Active);
            dictionaryVacancy = dataGet.ToDictionary(keySelector: x => x.VacancyId, elementSelector: x => x.Name);
            dictionaryVacancyAll = dataGet.ToDictionary(keySelector: x => x.VacancyId, elementSelector: x => x);
            return true;
        }

        public async Task<bool> InitialCandidates()
        {
            List<Entities.DataContext.Candidates> dataGet = await ApiControl<Entities.DataContext.Candidates>.GetDictionary(Program.BaseUrl + "Candidates/GetAllCandidates");
            dataGet = dataGet.FindAll(x => x.Active);
            dictionaryCandidates = dataGet.ToDictionary(keySelector: x => x.CandidatesId, elementSelector: x => x.Name);
            dictionaryCandidatesAll = dataGet.ToDictionary(keySelector: x => x.CandidatesId, elementSelector: x => x);
            return true;
        }
        public async Task<bool> InitialStages()
        {
            List<Entities.DataContext.Stages> dataGet = await ApiControl<Entities.DataContext.Stages>.GetDictionary(Program.BaseUrl + "Stages/GetAllStages");
            dataGet = dataGet.FindAll(x => x.Active);
            dictionaryStages = dataGet.ToDictionary(keySelector: x => x.StagesId, elementSelector: x => x.Name);
            dictionaryStagesAll = dataGet.ToDictionary(keySelector: x => x.StagesId, elementSelector: x => x);
            return true;
        }
        public async void InitialTreeFiles(int CandidateId)
        {
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


        private async void InitialResponsabilitys()
        {
            VacancyFormat vacancy = dictionaryVacancyAll[int.Parse(((ComboboxItem)cmbVacancy.SelectedItem).Value.ToString())];

            List<Entities.DataContext.Requirements> dataGet = await ApiControl<Entities.DataContext.Requirements>.GetDictionary(Program.BaseUrl + "Requirements/GetAllRequirements");
            List<Entities.DataContext.Requirements> requirements = dataGet.Where(x => x.VacancyId == vacancy.VacancyId && x.Active).ToList();

            txtRequirements.Text = "Requirements:\r\n\r\n";
            string benefises = string.Empty;
            foreach (var item in requirements)
            {
                if (!item.Benefits)
                {
                    if (item.Required)
                        txtRequirements.Text = txtRequirements.Text + "*Name:" + item.Name + "\r\n"
                            + "Description:" + item.Description + "\r\n"
                            + "Age Experience:" + item.AgeExperience;
                    else
                        txtRequirements.Text = txtRequirements.Text + "Name:" + item.Name + "\r\n"
                           + "Description:" + item.Description + "\r\n"
                           + "Age Experience:" + item.AgeExperience;

                    txtRequirements.Text = txtRequirements.Text + "\r\n";
                }
                else
                {
                    benefises = benefises + "Name:" + item.Name + "\r\n"
                           + "Description:" + item.Description;
                    benefises = benefises + "\r\n";
                }

            }

            txtRequirements.Text = txtRequirements.Text + "\r\n Benefices: \r\n";

            txtRequirements.Text = txtRequirements.Text + benefises;

            lblClient.Text = string.Format(lblClient.Text, vacancy.CustomerName);
        }


        private async void btnSearch_Click(object sender, EventArgs e)
        {
            webView.CoreWebView2.Navigate(txtSearch.Text);
        }

        private async void iconButton1_Click(object sender, EventArgs e)
        {
            if (cmbVacancy.Text != "" && cmbCandidates.Text != "")
            {
                Timer.Tick += new EventHandler(t_Tick);
                Timer.Interval = 1000;
                Timer.Start();
                stopwatch.Start();
                tabControl1.Enabled = true;

                //initial Tree
                dt = await ApiControl<QA>.GetDataTable(Program.BaseUrl + "Execute/GetQAC/" + ((ComboboxItem)cmbCandidates.SelectedItem).Value + "-" + ((ComboboxItem)cmbVacancy.SelectedItem).Value);
                CreateNodes();
                treeView1.ExpandAll();

                cmbCandidates.Enabled = false;
                cmbVacancy.Enabled = false;

                //Requirements

                //browser
                webView.EnsureCoreWebView2Async().Wait();
                webView.CoreWebView2.Navigate(txtSearch.Text);
                //FilesTree

                //Meeting
                webViewMeeting.EnsureCoreWebView2Async().Wait();
                webViewMeeting.CoreWebView2.Navigate("https://meet.google.com/");

                //files
                InitialTreeFiles(int.Parse(((ComboboxItem)cmbCandidates.SelectedItem).Value.ToString()));

                //responsabilitys
                InitialResponsabilitys();
            }
            else
            {
                MessageBox.Show("Please select one Candidate and one Vacancy");
            }

        }

        int timeElapsed = 0; int sec = 0, ms = 1, min = 0, hour = 0;

        void t_Tick(object sender, EventArgs e)
        {
            sec++;
            if (sec >= 60)
            {
                min++;
                sec = 0;
            }
            if (min >= 60)
            {
                hour++;
                min = 0;
            }
            lblTimer.Text = String.Format("{0:00}:{1:00}:{2:00}", hour, min, sec);
        }

        //NOTE: we just will sabe hours, minutes and seconds    
        private long milisecondsToLong(string miliseconds)
        {
            long value = 0;

            string[] values = miliseconds.Split(":");

            value = value + int.Parse(values[0]) * 3600000;
            value = value + int.Parse(values[1]) * 60000;
            value = value + int.Parse(values[2]) * 1000;


            return value;
        }

        private async void btnStop_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            Timer.Stop();
            stopwatch.Stop();
            MeetingsFormat metting = new MeetingsFormat();
            metting.Active = true;
            metting.CandidatesId = int.Parse(((ComboboxItem)cmbCandidates.SelectedItem).Value.ToString());
            metting.DateCreated = now;
            metting.DateModified = now;
            metting.NameCreated = Program.LoginUser;
            metting.NameModified = Program.LoginUser;
            metting.Time = milisecondsToLong(lblTimer.Text.ToString());

            string result = await ApiControl<Entities.Formats.MeetingsFormat>.Post(Program.BaseUrl + "Meetings/AddMeetingsInAMetting", metting);


            lblTimer.Text = "00:00:00";
            sec = 0;
            min = 0;
            hour = 0;

            //create the meeting



            tabControl1.Enabled = false;
            cmbCandidates.Enabled = true;
            cmbVacancy.Enabled = true;
            cmbCandidates.Text = string.Empty;
            cmbVacancy.Text = string.Empty;
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //var x= treeView1.SelectedNode.Text;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            isNewComment = false;
            btnSave.Text = "Save";
            var x = treeView1.SelectedNode.Text;

            DataRow[] rows = dt.Select("NoteName = '" + x + "'");
            if (rows.Count() > 0)
            {
                if ((int)rows.First().ItemArray[3] != 0)
                {
                    txtComment.Text = x;
                    comentId = (int)rows.First().ItemArray[3];
                    btnSave.Enabled = true;
                }
                else
                {
                    comentId = 0;
                    btnSave.Enabled = false;
                    txtComment.Text = "";
                }
            }
            else
            {
                comentId = 0;
                btnSave.Enabled = false;
                txtComment.Text = "";
            }
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs args)
        {

            treeView1.SelectedNode = treeView1.GetNodeAt(args.X, args.Y);

            string textQuestion = string.Empty;

            if (treeView1.SelectedNode != null)
            {
                //question,Answer, comment
                if (treeView1.SelectedNode.Parent == null)
                    textQuestion = treeView1.SelectedNode.Text;
                else
                    if (treeView1.SelectedNode.Parent.Parent == null)
                    textQuestion = treeView1.SelectedNode.Parent.Text;
                else
                        if (treeView1.SelectedNode.Parent.Parent.Parent == null)
                    textQuestion = treeView1.SelectedNode.Parent.Parent.Text;

                DataRow[] rows = dt.Select("NoteName = '" + textQuestion + "'");

                if (rows.Count() > 0)
                    andwerId = (int)rows.First().ItemArray[4];

                btnDelete.Enabled = true;
            }
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            isNewComment = true;
            txtComment.Text = string.Empty;
            txtComment.Focus();

            btnSave.Text = "Save New Comment";
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                contextMenuStrip1.Show(Cursor.Position);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            int option = 0;
            //edit comment
            if (btnSave.Text == "Save")
            {
                //this is the coment id
                if (comentId != 0)
                {
                    option = 1;
                }
            }
            else
            {
                //this is the coment id
                if (comentId == 0)
                {
                    option = 2;
                }
            }

            if (option == 1 || option == 2)
            {
                //current information
                DateTime now = DateTime.Now;
                Entities.Formats.CommentsFormat comment = new Entities.Formats.CommentsFormat();
                comment.Value = txtComment.Text;
                comment.Active = true;
                comment.QuestionDetailsId = andwerId;
                string result = string.Empty;
                if (option == 2)
                {
                    comment.NameCreated = Program.LoginUser;
                    comment.DateCreated = now;
                    comment.NameModified = Program.LoginUser;
                    comment.DateModified = now;
                    result = await ApiControl<Entities.Formats.CommentsFormat>.Post(Program.BaseUrl + "Comments/AddComments", comment);
                }
                else
                {
                    comment.NameModified = Program.LoginUser;
                    comment.DateModified = now;
                    result = await ApiControl<Entities.Formats.CommentsFormat>.Put(Program.BaseUrl + "Comments/UpdateCommentsExecute/" + comentId, comment);
                }

                if (result == "")
                {
                    MessageBox.Show("Service is not working", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    FormatData<CommentsFormat> information = new FormatData<CommentsFormat>();
                    information = JsonSerializer.Deserialize<FormatData<CommentsFormat>>(result);
                    MessageBox.Show(information.MessageToFrontEnd);

                    //reload tree
                    dt = await ApiControl<QA>.GetDataTable(Program.BaseUrl + "Execute/GetQAC/" + ((ComboboxItem)cmbCandidates.SelectedItem).Value + "-" + ((ComboboxItem)cmbVacancy.SelectedItem).Value);
                    CreateNodes();
                    treeView1.ExpandAll();
                    treeView1.SelectedNode = null;
                    txtComment.Text = string.Empty;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Error please contact to the admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            string result = string.Empty;
            Entities.Formats.CommentsFormat comment = new Entities.Formats.CommentsFormat();
            comment.Value = txtComment.Text;
            comment.QuestionDetailsId = andwerId;
            comment.NameModified = Program.LoginUser;
            comment.DateModified = DateTime.Now;
            comment.Active = false;

            result = await ApiControl<Entities.Formats.CommentsFormat>.Put(Program.BaseUrl + "Comments/UpdateCommentsExecute/" + comentId, comment);

            if (result == "")
                MessageBox.Show("Service is not working", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                MessageBox.Show("Comment deleted");
                //reload tree
                dt = await ApiControl<QA>.GetDataTable(Program.BaseUrl + "Execute/GetQAC/" + ((ComboboxItem)cmbCandidates.SelectedItem).Value + "-" + ((ComboboxItem)cmbVacancy.SelectedItem).Value);
                CreateNodes();
                treeView1.ExpandAll();
                treeView1.SelectedNode = null;
                txtComment.Text = string.Empty;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private async void treeViewFiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //selecter for files
            if (treeViewFiles.SelectedNode != null)
            {
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

        private void CreateNodes()
        {
            DataRow[] rows = new DataRow[dt.Rows.Count];
            dt.Rows.CopyTo(rows, 0);
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();

            TreeNode[] nodes = RecurseRows(rows);
            treeView1.Nodes.AddRange(nodes);
            treeView1.EndUpdate();
        }

        private TreeNode[] RecurseRows(DataRow[] rows)
        {
            List<TreeNode> nodeList = new List<TreeNode>();
            TreeNode node = null;

            foreach (DataRow dr in rows)
            {
                node = new TreeNode(dr["NoteName"].ToString());
                noteID = Convert.ToInt32(dr["NoteID"]);

                node.Name = noteID.ToString();
                node.ToolTipText = noteID.ToString();

                if (nodeList.Find(FindNode) == null)
                {
                    DataRow[] childRows = dt.Select("ParentNoteID = " + dr["NoteID"]);
                    if (childRows.Length > 0)
                    {
                        TreeNode[] childNodes = RecurseRows(childRows);
                        node.Nodes.AddRange(childNodes);
                    }
                    nodeList.Add(node);
                }
            }

            TreeNode[] nodeArr = nodeList.ToArray();
            return nodeArr;
        }


        private static bool FindNode(TreeNode n)
        {
            if (n.Nodes.Count == 0)
                return n.Name == noteID.ToString();
            else
            {
                while (n.Nodes.Count > 0)
                {
                    foreach (TreeNode tn in n.Nodes)
                    {
                        if (tn.Name == noteID.ToString())
                            return true;
                        else
                            n = tn;
                    }
                }
                return false;
            }
        }
    }
}

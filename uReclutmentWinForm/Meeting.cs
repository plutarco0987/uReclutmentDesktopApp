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
 
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using uReclutmentWinForm.Control;
//using Zuby.ADGV;
using Microsoft.Web.WebView2.Core;
using System.Diagnostics;
using Entities.Formats;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.IO;

namespace uReclutmentWinForm
{
   

    public partial class Meeting : Form
    {
        private Dictionary<int, string> dictionaryVacancy = new Dictionary<int, string>();
        private Dictionary<int, Entities.DataContext.VacancyFormat> dictionaryVacancyAll = new Dictionary<int, Entities.DataContext.VacancyFormat>();
        private Dictionary<int, string> dictionaryCandidates = new Dictionary<int, string>();
        private Dictionary<int, Entities.DataContext.Candidates> dictionaryCandidatesAll = new Dictionary<int, Entities.DataContext.Candidates>();
        private Dictionary<int, string> dictionaryStages = new Dictionary<int, string>();
        private Dictionary<int, Entities.DataContext.Stages> dictionaryStagesAll = new Dictionary<int, Entities.DataContext.Stages>();
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
        }
        private void InitialComboBoxes(ComboBox item,Dictionary<int, string> dictionary)
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
                webViewMeeting.CoreWebView2.Navigate(txtSearch.Text);
            }
            else
            {
                MessageBox.Show("Please select one Candidate and one Vacancy");
            }
            
        }       

        int timeElapsed = 0; int sec = 0, ms = 1, min = 0,hour=0;

        void t_Tick(object sender, EventArgs e)        
        {
            sec++;
            if (sec >= 60)
            {
                min++;
                sec= 0;
            }
            if(min>= 60)
            {
                hour++;
                min = 0;
            }
            lblTimer.Text = String.Format("{0:00}:{1:00}:{2:00}",hour,min, sec);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {            
            Timer.Stop();
            stopwatch.Stop();
            lblTimer.Text = "00:00:00";
            sec = 0;
            min = 0;
            hour = 0;

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

            DataRow[] rows= dt.Select("NoteName = '" + x + "'");
            if (rows.Count() > 0)
            {
                if ((int)rows.First().ItemArray[3] != 0)
                {
                    txtComment.Text = x;
                    comentId =(int) rows.First().ItemArray[3];
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
            if(e.Button == System.Windows.Forms.MouseButtons.Right)
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
                if (comentId != 0)
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
                    var serializer = new JsonSerializer();

                    using (var sr = new StreamReader(result))
                    using (var jsonTextReader = new JsonTextReader(sr))
                    {
                        var jsObj = serializer.Deserialize<FormatData<User>>(jsonTextReader);
                    }
                    //information = JsonSerializer.Deserialize<FormatData<CommentsFormat>>(result);
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

            if(result=="")
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

        private void treeViewFiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //selecter for files
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

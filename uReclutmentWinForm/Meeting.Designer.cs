using System.Windows.Forms;

namespace uReclutmentWinForm
{
    partial class Meeting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Meeting));
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.cmbCandidates = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStop = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbVacancy = new System.Windows.Forms.ComboBox();
            this.lblLoading = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.webViewMeeting = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.treeViewFiles = new System.Windows.Forms.TreeView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.txtRequirements = new System.Windows.Forms.TextBox();
            this.lblClient = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webViewMeeting)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCandidates
            // 
            this.cmbCandidates.FormattingEnabled = true;
            resources.ApplyResources(this.cmbCandidates, "cmbCandidates");
            this.cmbCandidates.Name = "cmbCandidates";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.iconButton1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbVacancy);
            this.groupBox1.Controls.Add(this.lblLoading);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbCandidates);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // btnStop
            // 
            this.btnStop.IconChar = FontAwesome.Sharp.IconChar.CircleStop;
            this.btnStop.IconColor = System.Drawing.Color.Black;
            this.btnStop.IconFont = FontAwesome.Sharp.IconFont.Auto;
            resources.ApplyResources(this.btnStop, "btnStop");
            this.btnStop.Name = "btnStop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.PlayCircle;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            resources.ApplyResources(this.iconButton1, "iconButton1");
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cmbVacancy
            // 
            this.cmbVacancy.FormattingEnabled = true;
            resources.ApplyResources(this.cmbVacancy, "cmbVacancy");
            this.cmbVacancy.Name = "cmbVacancy";
            // 
            // lblLoading
            // 
            resources.ApplyResources(this.lblLoading, "lblLoading");
            this.lblLoading.Name = "lblLoading";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lblTimer
            // 
            resources.ApplyResources(this.lblTimer, "lblTimer");
            this.lblTimer.Name = "lblTimer";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddStrip});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // AddStrip
            // 
            this.AddStrip.Name = "AddStrip";
            resources.ApplyResources(this.AddStrip, "AddStrip");
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.webViewMeeting);
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Controls.Add(this.btnDelete);
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.txtComment);
            this.tabPage1.Controls.Add(this.txtRequirements);
            this.tabPage1.Controls.Add(this.lblClient);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.treeView1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // webViewMeeting
            // 
            this.webViewMeeting.AllowExternalDrop = true;
            this.webViewMeeting.CreationProperties = null;
            this.webViewMeeting.DefaultBackgroundColor = System.Drawing.Color.White;
            resources.ApplyResources(this.webViewMeeting, "webViewMeeting");
            this.webViewMeeting.Name = "webViewMeeting";
            this.webViewMeeting.ZoomFactor = 1D;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            resources.ApplyResources(this.tabControl2, "tabControl2");
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.webView);
            this.tabPage3.Controls.Add(this.txtSearch);
            this.tabPage3.Controls.Add(this.btnSearch);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // webView
            // 
            this.webView.AllowExternalDrop = true;
            this.webView.CreationProperties = null;
            this.webView.DefaultBackgroundColor = System.Drawing.Color.White;
            resources.ApplyResources(this.webView, "webView");
            this.webView.Name = "webView";
            this.webView.ZoomFactor = 1D;
            // 
            // txtSearch
            // 
            resources.ApplyResources(this.txtSearch, "txtSearch");
            this.txtSearch.Name = "txtSearch";
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dataGridView1);
            this.tabPage4.Controls.Add(this.treeViewFiles);
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // treeViewFiles
            // 
            resources.ApplyResources(this.treeViewFiles, "treeViewFiles");
            this.treeViewFiles.Name = "treeViewFiles";
            this.treeViewFiles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFiles_AfterSelect);
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // txtComment
            // 
            this.txtComment.AcceptsReturn = true;
            resources.ApplyResources(this.txtComment, "txtComment");
            this.txtComment.Name = "txtComment";
            // 
            // txtRequirements
            // 
            this.txtRequirements.AcceptsReturn = true;
            resources.ApplyResources(this.txtRequirements, "txtRequirements");
            this.txtRequirements.Name = "txtRequirements";
            // 
            // lblClient
            // 
            resources.ApplyResources(this.lblClient, "lblClient");
            this.lblClient.Name = "lblClient";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // treeView1
            // 
            resources.ApplyResources(this.treeView1, "treeView1");
            this.treeView1.Name = "treeView1";
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseClick);
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            // 
            // Meeting
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(254)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Meeting";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webViewMeeting)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer Timer;
        private ComboBox cmbCandidates;
        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private ComboBox cmbVacancy;
        private Label lblLoading;
        private FontAwesome.Sharp.IconButton iconButton1;
        private Label label5;
        private FontAwesome.Sharp.IconButton btnStop;
        private Label lblTimer;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem AddStrip;
        private TabPage tabPage1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewMeeting;
        private TabControl tabControl2;
        private TabPage tabPage3;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private TextBox txtSearch;
        private Button btnSearch;
        private TabPage tabPage4;
        private TreeView treeViewFiles;
        private Button btnDelete;
        private Button btnSave;
        private TextBox txtComment;
        private TextBox txtRequirements;
        private Label lblClient;
        private Label label3;
        private TreeView treeView1;
        private TabControl tabControl1;
        private DataGridView dataGridView1;
    }
}
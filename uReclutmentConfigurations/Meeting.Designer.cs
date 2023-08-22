namespace uReclutmentConfigurations
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Meeting));
            Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings messageBoxSettings1 = new Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings();
            Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings pdfViewerPrinterSettings1 = new Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings();
            Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings textSearchSettings1 = new Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings();
            Timer = new System.Windows.Forms.Timer(components);
            cmbCandidates = new ComboBox();
            groupBox1 = new GroupBox();
            btnStop = new FontAwesome.Sharp.IconButton();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            label2 = new Label();
            cmbVacancy = new ComboBox();
            lblLoading = new Label();
            label1 = new Label();
            lblTimer = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            AddStrip = new ToolStripMenuItem();
            tabPage1 = new TabPage();
            panel1 = new Panel();
            webViewMeeting = new Microsoft.Web.WebView2.WinForms.WebView2();
            tabControl2 = new TabControl();
            tabPage3 = new TabPage();
            webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            txtSearch = new TextBox();
            btnSearch = new Button();
            tabPage4 = new TabPage();
            pdfDocumentView1 = new Syncfusion.Windows.Forms.PdfViewer.PdfDocumentView();
            treeViewFiles = new TreeView();
            btnDelete = new Button();
            btnSave = new Button();
            txtComment = new TextBox();
            txtRequirements = new TextBox();
            lblClient = new Label();
            label3 = new Label();
            treeView1 = new TreeView();
            tabControl1 = new TabControl();
            pdfConfig1 = new Syncfusion.Pdf.PdfConfig();
            groupBox1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webViewMeeting).BeginInit();
            tabControl2.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView).BeginInit();
            tabPage4.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // cmbCandidates
            // 
            cmbCandidates.FormattingEnabled = true;
            resources.ApplyResources(cmbCandidates, "cmbCandidates");
            cmbCandidates.Name = "cmbCandidates";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnStop);
            groupBox1.Controls.Add(iconButton1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cmbVacancy);
            groupBox1.Controls.Add(lblLoading);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmbCandidates);
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            // 
            // btnStop
            // 
            btnStop.IconChar = FontAwesome.Sharp.IconChar.CircleStop;
            btnStop.IconColor = Color.Black;
            btnStop.IconFont = FontAwesome.Sharp.IconFont.Auto;
            resources.ApplyResources(btnStop, "btnStop");
            btnStop.Name = "btnStop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // iconButton1
            // 
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.PlayCircle;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            resources.ApplyResources(iconButton1, "iconButton1");
            iconButton1.Name = "iconButton1";
            iconButton1.UseVisualStyleBackColor = true;
            iconButton1.Click += iconButton1_Click;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // cmbVacancy
            // 
            cmbVacancy.FormattingEnabled = true;
            resources.ApplyResources(cmbVacancy, "cmbVacancy");
            cmbVacancy.Name = "cmbVacancy";
            // 
            // lblLoading
            // 
            resources.ApplyResources(lblLoading, "lblLoading");
            lblLoading.Name = "lblLoading";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // lblTimer
            // 
            resources.ApplyResources(lblTimer, "lblTimer");
            lblTimer.Name = "lblTimer";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { AddStrip });
            contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(contextMenuStrip1, "contextMenuStrip1");
            contextMenuStrip1.Click += contextMenuStrip1_Click;
            // 
            // AddStrip
            // 
            AddStrip.Name = "AddStrip";
            resources.ApplyResources(AddStrip, "AddStrip");
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel1);
            tabPage1.Controls.Add(tabControl2);
            tabPage1.Controls.Add(btnDelete);
            tabPage1.Controls.Add(btnSave);
            tabPage1.Controls.Add(txtComment);
            tabPage1.Controls.Add(txtRequirements);
            tabPage1.Controls.Add(lblClient);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(treeView1);
            resources.ApplyResources(tabPage1, "tabPage1");
            tabPage1.Name = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(webViewMeeting);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // webViewMeeting
            // 
            webViewMeeting.AllowExternalDrop = true;
            webViewMeeting.CreationProperties = null;
            webViewMeeting.DefaultBackgroundColor = Color.White;
            resources.ApplyResources(webViewMeeting, "webViewMeeting");
            webViewMeeting.Name = "webViewMeeting";
            webViewMeeting.ZoomFactor = 1D;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage3);
            tabControl2.Controls.Add(tabPage4);
            resources.ApplyResources(tabControl2, "tabControl2");
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(webView);
            tabPage3.Controls.Add(txtSearch);
            tabPage3.Controls.Add(btnSearch);
            resources.ApplyResources(tabPage3, "tabPage3");
            tabPage3.Name = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // webView
            // 
            webView.AllowExternalDrop = true;
            webView.CreationProperties = null;
            webView.DefaultBackgroundColor = Color.White;
            resources.ApplyResources(webView, "webView");
            webView.Name = "webView";
            webView.ZoomFactor = 1D;
            // 
            // txtSearch
            // 
            resources.ApplyResources(txtSearch, "txtSearch");
            txtSearch.Name = "txtSearch";
            // 
            // btnSearch
            // 
            resources.ApplyResources(btnSearch, "btnSearch");
            btnSearch.Name = "btnSearch";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(pdfDocumentView1);
            tabPage4.Controls.Add(treeViewFiles);
            resources.ApplyResources(tabPage4, "tabPage4");
            tabPage4.Name = "tabPage4";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // pdfDocumentView1
            // 
            resources.ApplyResources(pdfDocumentView1, "pdfDocumentView1");
            pdfDocumentView1.BackColor = Color.FromArgb(237, 237, 237);
            pdfDocumentView1.CursorMode = Syncfusion.Windows.Forms.PdfViewer.PdfViewerCursorMode.SelectTool;
            pdfDocumentView1.EnableContextMenu = false;
            pdfDocumentView1.HorizontalScrollOffset = 1;
            pdfDocumentView1.IsTextSearchEnabled = true;
            pdfDocumentView1.IsTextSelectionEnabled = true;
            messageBoxSettings1.EnableNotification = true;
            pdfDocumentView1.MessageBoxSettings = messageBoxSettings1;
            pdfDocumentView1.MinimumZoomPercentage = 50;
            pdfDocumentView1.Name = "pdfDocumentView1";
            pdfDocumentView1.PageBorderThickness = 1;
            pdfViewerPrinterSettings1.Copies = 1;
            pdfViewerPrinterSettings1.PageOrientation = Syncfusion.Windows.PdfViewer.PdfViewerPrintOrientation.Auto;
            pdfViewerPrinterSettings1.PageSize = Syncfusion.Windows.PdfViewer.PdfViewerPrintSize.ActualSize;
            pdfViewerPrinterSettings1.PrintLocation = (PointF)resources.GetObject("pdfViewerPrinterSettings1.PrintLocation");
            pdfViewerPrinterSettings1.ShowPrintStatusDialog = true;
            pdfDocumentView1.PrinterSettings = pdfViewerPrinterSettings1;
            pdfDocumentView1.ReferencePath = null;
            pdfDocumentView1.ScrollDisplacementValue = 0;
            pdfDocumentView1.ShowHorizontalScrollBar = true;
            pdfDocumentView1.ShowVerticalScrollBar = true;
            pdfDocumentView1.SpaceBetweenPages = 8;
            textSearchSettings1.CurrentInstanceColor = Color.FromArgb(127, 255, 171, 64);
            textSearchSettings1.HighlightAllInstance = true;
            textSearchSettings1.OtherInstanceColor = Color.FromArgb(127, 254, 255, 0);
            pdfDocumentView1.TextSearchSettings = textSearchSettings1;
            pdfDocumentView1.ThemeName = "Default";
            pdfDocumentView1.VerticalScrollOffset = 0;
            pdfDocumentView1.VisualStyle = Syncfusion.Windows.Forms.PdfViewer.VisualStyle.Default;
            pdfDocumentView1.ZoomMode = Syncfusion.Windows.Forms.PdfViewer.ZoomMode.Default;
            // 
            // treeViewFiles
            // 
            resources.ApplyResources(treeViewFiles, "treeViewFiles");
            treeViewFiles.Name = "treeViewFiles";
            treeViewFiles.AfterSelect += treeViewFiles_AfterSelect;
            // 
            // btnDelete
            // 
            resources.ApplyResources(btnDelete, "btnDelete");
            btnDelete.Name = "btnDelete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            resources.ApplyResources(btnSave, "btnSave");
            btnSave.Name = "btnSave";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtComment
            // 
            txtComment.AcceptsReturn = true;
            resources.ApplyResources(txtComment, "txtComment");
            txtComment.Name = "txtComment";
            // 
            // txtRequirements
            // 
            txtRequirements.AcceptsReturn = true;
            resources.ApplyResources(txtRequirements, "txtRequirements");
            txtRequirements.Name = "txtRequirements";
            // 
            // lblClient
            // 
            resources.ApplyResources(lblClient, "lblClient");
            lblClient.Name = "lblClient";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // treeView1
            // 
            resources.ApplyResources(treeView1, "treeView1");
            treeView1.Name = "treeView1";
            treeView1.AfterSelect += treeView1_AfterSelect;
            treeView1.NodeMouseClick += treeView1_NodeMouseClick;
            treeView1.MouseClick += treeView1_MouseClick;
            treeView1.MouseDown += treeView1_MouseDown;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            resources.ApplyResources(tabControl1, "tabControl1");
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            // 
            // Meeting
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 254, 252);
            Controls.Add(lblTimer);
            Controls.Add(groupBox1);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Meeting";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)webViewMeeting).EndInit();
            tabControl2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)webView).EndInit();
            tabPage4.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private Syncfusion.Windows.Forms.PdfViewer.PdfDocumentView pdfDocumentView1;
        private Syncfusion.Pdf.PdfConfig pdfConfig1;
        private Panel panel1;
    }
}
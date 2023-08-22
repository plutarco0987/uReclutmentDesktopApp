namespace uReclutmentConfigurations.views
{
    partial class Candidates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Candidates));
            Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings messageBoxSettings1 = new Syncfusion.Windows.Forms.PdfViewer.MessageBoxSettings();
            Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings pdfViewerPrinterSettings1 = new Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings();
            Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings textSearchSettings1 = new Syncfusion.Windows.Forms.PdfViewer.TextSearchSettings();
            label1 = new Label();
            DataTable = new Zuby.ADGV.AdvancedDataGridView();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txtName = new TextBox();
            lblName = new Label();
            txtCandidateId = new TextBox();
            lblSettingsID = new Label();
            chkActive = new CheckBox();
            label2 = new Label();
            lblNameCreated = new Label();
            lblDateCreated = new Label();
            lblNameModified = new Label();
            lblDateModified = new Label();
            btnNew = new Button();
            btnSave = new Button();
            Description = new Label();
            label10 = new Label();
            cmbVacancy = new ComboBox();
            lblQuestions = new Label();
            label8 = new Label();
            cmbStages = new ComboBox();
            txtAdd = new TextBox();
            txtAge = new NumericUpDown();
            label11 = new Label();
            txtCity = new TextBox();
            label12 = new Label();
            label13 = new Label();
            cmbCountry = new ComboBox();
            chkExcel = new CheckBox();
            chkPdf = new CheckBox();
            btnExport = new Button();
            pdfDocumentView1 = new Syncfusion.Windows.Forms.PdfViewer.PdfDocumentView();
            treeViewFiles = new TreeView();
            label3 = new Label();
            txtNotes = new TextBox();
            cmbRecluter = new ComboBox();
            label9 = new Label();
            label15 = new Label();
            txtTags = new TextBox();
            cmbContact = new ComboBox();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            cmbRejectCandidate = new ComboBox();
            cmbRejectEmcor = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)DataTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtAge).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            label1.Click += label1_Click;
            // 
            // DataTable
            // 
            DataTable.AllowUserToAddRows = false;
            DataTable.FilterAndSortEnabled = true;
            DataTable.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            resources.ApplyResources(DataTable, "DataTable");
            DataTable.MultiSelect = false;
            DataTable.Name = "DataTable";
            DataTable.ReadOnly = true;
            DataTable.RowTemplate.Height = 25;
            DataTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataTable.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            DataTable.SortStringChanged += DataTable_SortStringChanged;
            DataTable.CellEndEdit += DataTable_CellEndEdit;
            DataTable.SelectionChanged += DataTable_SelectionChanged;
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // txtName
            // 
            resources.ApplyResources(txtName, "txtName");
            txtName.Name = "txtName";
            // 
            // lblName
            // 
            resources.ApplyResources(lblName, "lblName");
            lblName.Name = "lblName";
            // 
            // txtCandidateId
            // 
            resources.ApplyResources(txtCandidateId, "txtCandidateId");
            txtCandidateId.Name = "txtCandidateId";
            // 
            // lblSettingsID
            // 
            resources.ApplyResources(lblSettingsID, "lblSettingsID");
            lblSettingsID.Name = "lblSettingsID";
            // 
            // chkActive
            // 
            resources.ApplyResources(chkActive, "chkActive");
            chkActive.Name = "chkActive";
            chkActive.UseVisualStyleBackColor = true;
            chkActive.CheckedChanged += chkActive_CheckedChanged;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // lblNameCreated
            // 
            resources.ApplyResources(lblNameCreated, "lblNameCreated");
            lblNameCreated.Name = "lblNameCreated";
            // 
            // lblDateCreated
            // 
            resources.ApplyResources(lblDateCreated, "lblDateCreated");
            lblDateCreated.Name = "lblDateCreated";
            // 
            // lblNameModified
            // 
            resources.ApplyResources(lblNameModified, "lblNameModified");
            lblNameModified.Name = "lblNameModified";
            // 
            // lblDateModified
            // 
            resources.ApplyResources(lblDateModified, "lblDateModified");
            lblDateModified.Name = "lblDateModified";
            // 
            // btnNew
            // 
            resources.ApplyResources(btnNew, "btnNew");
            btnNew.Name = "btnNew";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // btnSave
            // 
            resources.ApplyResources(btnSave, "btnSave");
            btnSave.Name = "btnSave";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // Description
            // 
            resources.ApplyResources(Description, "Description");
            Description.Name = "Description";
            Description.Click += label3_Click;
            // 
            // label10
            // 
            resources.ApplyResources(label10, "label10");
            label10.Name = "label10";
            // 
            // cmbVacancy
            // 
            cmbVacancy.FormattingEnabled = true;
            resources.ApplyResources(cmbVacancy, "cmbVacancy");
            cmbVacancy.Name = "cmbVacancy";
            // 
            // lblQuestions
            // 
            resources.ApplyResources(lblQuestions, "lblQuestions");
            lblQuestions.Name = "lblQuestions";
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.Name = "label8";
            // 
            // cmbStages
            // 
            cmbStages.FormattingEnabled = true;
            resources.ApplyResources(cmbStages, "cmbStages");
            cmbStages.Name = "cmbStages";
            // 
            // txtAdd
            // 
            txtAdd.AcceptsReturn = true;
            resources.ApplyResources(txtAdd, "txtAdd");
            txtAdd.Name = "txtAdd";
            // 
            // txtAge
            // 
            resources.ApplyResources(txtAge, "txtAge");
            txtAge.Name = "txtAge";
            // 
            // label11
            // 
            resources.ApplyResources(label11, "label11");
            label11.Name = "label11";
            // 
            // txtCity
            // 
            resources.ApplyResources(txtCity, "txtCity");
            txtCity.Name = "txtCity";
            // 
            // label12
            // 
            resources.ApplyResources(label12, "label12");
            label12.Name = "label12";
            // 
            // label13
            // 
            resources.ApplyResources(label13, "label13");
            label13.Name = "label13";
            // 
            // cmbCountry
            // 
            cmbCountry.FormattingEnabled = true;
            cmbCountry.Items.AddRange(new object[] { resources.GetString("cmbCountry.Items"), resources.GetString("cmbCountry.Items1"), resources.GetString("cmbCountry.Items2"), resources.GetString("cmbCountry.Items3"), resources.GetString("cmbCountry.Items4"), resources.GetString("cmbCountry.Items5"), resources.GetString("cmbCountry.Items6"), resources.GetString("cmbCountry.Items7"), resources.GetString("cmbCountry.Items8"), resources.GetString("cmbCountry.Items9"), resources.GetString("cmbCountry.Items10"), resources.GetString("cmbCountry.Items11"), resources.GetString("cmbCountry.Items12"), resources.GetString("cmbCountry.Items13"), resources.GetString("cmbCountry.Items14"), resources.GetString("cmbCountry.Items15"), resources.GetString("cmbCountry.Items16"), resources.GetString("cmbCountry.Items17"), resources.GetString("cmbCountry.Items18"), resources.GetString("cmbCountry.Items19"), resources.GetString("cmbCountry.Items20"), resources.GetString("cmbCountry.Items21"), resources.GetString("cmbCountry.Items22"), resources.GetString("cmbCountry.Items23"), resources.GetString("cmbCountry.Items24"), resources.GetString("cmbCountry.Items25"), resources.GetString("cmbCountry.Items26"), resources.GetString("cmbCountry.Items27"), resources.GetString("cmbCountry.Items28"), resources.GetString("cmbCountry.Items29"), resources.GetString("cmbCountry.Items30"), resources.GetString("cmbCountry.Items31"), resources.GetString("cmbCountry.Items32"), resources.GetString("cmbCountry.Items33"), resources.GetString("cmbCountry.Items34"), resources.GetString("cmbCountry.Items35"), resources.GetString("cmbCountry.Items36"), resources.GetString("cmbCountry.Items37"), resources.GetString("cmbCountry.Items38"), resources.GetString("cmbCountry.Items39"), resources.GetString("cmbCountry.Items40"), resources.GetString("cmbCountry.Items41"), resources.GetString("cmbCountry.Items42"), resources.GetString("cmbCountry.Items43"), resources.GetString("cmbCountry.Items44"), resources.GetString("cmbCountry.Items45"), resources.GetString("cmbCountry.Items46"), resources.GetString("cmbCountry.Items47"), resources.GetString("cmbCountry.Items48"), resources.GetString("cmbCountry.Items49"), resources.GetString("cmbCountry.Items50"), resources.GetString("cmbCountry.Items51"), resources.GetString("cmbCountry.Items52"), resources.GetString("cmbCountry.Items53"), resources.GetString("cmbCountry.Items54"), resources.GetString("cmbCountry.Items55"), resources.GetString("cmbCountry.Items56"), resources.GetString("cmbCountry.Items57"), resources.GetString("cmbCountry.Items58"), resources.GetString("cmbCountry.Items59"), resources.GetString("cmbCountry.Items60"), resources.GetString("cmbCountry.Items61"), resources.GetString("cmbCountry.Items62"), resources.GetString("cmbCountry.Items63"), resources.GetString("cmbCountry.Items64"), resources.GetString("cmbCountry.Items65"), resources.GetString("cmbCountry.Items66"), resources.GetString("cmbCountry.Items67"), resources.GetString("cmbCountry.Items68"), resources.GetString("cmbCountry.Items69"), resources.GetString("cmbCountry.Items70"), resources.GetString("cmbCountry.Items71"), resources.GetString("cmbCountry.Items72"), resources.GetString("cmbCountry.Items73"), resources.GetString("cmbCountry.Items74"), resources.GetString("cmbCountry.Items75"), resources.GetString("cmbCountry.Items76"), resources.GetString("cmbCountry.Items77"), resources.GetString("cmbCountry.Items78"), resources.GetString("cmbCountry.Items79"), resources.GetString("cmbCountry.Items80"), resources.GetString("cmbCountry.Items81"), resources.GetString("cmbCountry.Items82"), resources.GetString("cmbCountry.Items83"), resources.GetString("cmbCountry.Items84"), resources.GetString("cmbCountry.Items85"), resources.GetString("cmbCountry.Items86"), resources.GetString("cmbCountry.Items87"), resources.GetString("cmbCountry.Items88"), resources.GetString("cmbCountry.Items89"), resources.GetString("cmbCountry.Items90"), resources.GetString("cmbCountry.Items91"), resources.GetString("cmbCountry.Items92"), resources.GetString("cmbCountry.Items93"), resources.GetString("cmbCountry.Items94"), resources.GetString("cmbCountry.Items95"), resources.GetString("cmbCountry.Items96"), resources.GetString("cmbCountry.Items97"), resources.GetString("cmbCountry.Items98"), resources.GetString("cmbCountry.Items99"), resources.GetString("cmbCountry.Items100"), resources.GetString("cmbCountry.Items101"), resources.GetString("cmbCountry.Items102"), resources.GetString("cmbCountry.Items103"), resources.GetString("cmbCountry.Items104"), resources.GetString("cmbCountry.Items105"), resources.GetString("cmbCountry.Items106"), resources.GetString("cmbCountry.Items107"), resources.GetString("cmbCountry.Items108"), resources.GetString("cmbCountry.Items109"), resources.GetString("cmbCountry.Items110"), resources.GetString("cmbCountry.Items111"), resources.GetString("cmbCountry.Items112"), resources.GetString("cmbCountry.Items113"), resources.GetString("cmbCountry.Items114"), resources.GetString("cmbCountry.Items115"), resources.GetString("cmbCountry.Items116"), resources.GetString("cmbCountry.Items117"), resources.GetString("cmbCountry.Items118"), resources.GetString("cmbCountry.Items119"), resources.GetString("cmbCountry.Items120"), resources.GetString("cmbCountry.Items121"), resources.GetString("cmbCountry.Items122"), resources.GetString("cmbCountry.Items123"), resources.GetString("cmbCountry.Items124"), resources.GetString("cmbCountry.Items125"), resources.GetString("cmbCountry.Items126"), resources.GetString("cmbCountry.Items127"), resources.GetString("cmbCountry.Items128"), resources.GetString("cmbCountry.Items129"), resources.GetString("cmbCountry.Items130"), resources.GetString("cmbCountry.Items131"), resources.GetString("cmbCountry.Items132"), resources.GetString("cmbCountry.Items133"), resources.GetString("cmbCountry.Items134"), resources.GetString("cmbCountry.Items135"), resources.GetString("cmbCountry.Items136"), resources.GetString("cmbCountry.Items137"), resources.GetString("cmbCountry.Items138"), resources.GetString("cmbCountry.Items139"), resources.GetString("cmbCountry.Items140"), resources.GetString("cmbCountry.Items141"), resources.GetString("cmbCountry.Items142"), resources.GetString("cmbCountry.Items143"), resources.GetString("cmbCountry.Items144"), resources.GetString("cmbCountry.Items145"), resources.GetString("cmbCountry.Items146"), resources.GetString("cmbCountry.Items147"), resources.GetString("cmbCountry.Items148"), resources.GetString("cmbCountry.Items149"), resources.GetString("cmbCountry.Items150"), resources.GetString("cmbCountry.Items151"), resources.GetString("cmbCountry.Items152"), resources.GetString("cmbCountry.Items153"), resources.GetString("cmbCountry.Items154"), resources.GetString("cmbCountry.Items155"), resources.GetString("cmbCountry.Items156"), resources.GetString("cmbCountry.Items157"), resources.GetString("cmbCountry.Items158"), resources.GetString("cmbCountry.Items159"), resources.GetString("cmbCountry.Items160"), resources.GetString("cmbCountry.Items161"), resources.GetString("cmbCountry.Items162"), resources.GetString("cmbCountry.Items163"), resources.GetString("cmbCountry.Items164"), resources.GetString("cmbCountry.Items165"), resources.GetString("cmbCountry.Items166"), resources.GetString("cmbCountry.Items167"), resources.GetString("cmbCountry.Items168"), resources.GetString("cmbCountry.Items169"), resources.GetString("cmbCountry.Items170"), resources.GetString("cmbCountry.Items171"), resources.GetString("cmbCountry.Items172"), resources.GetString("cmbCountry.Items173"), resources.GetString("cmbCountry.Items174"), resources.GetString("cmbCountry.Items175"), resources.GetString("cmbCountry.Items176"), resources.GetString("cmbCountry.Items177"), resources.GetString("cmbCountry.Items178"), resources.GetString("cmbCountry.Items179"), resources.GetString("cmbCountry.Items180"), resources.GetString("cmbCountry.Items181"), resources.GetString("cmbCountry.Items182"), resources.GetString("cmbCountry.Items183"), resources.GetString("cmbCountry.Items184"), resources.GetString("cmbCountry.Items185"), resources.GetString("cmbCountry.Items186"), resources.GetString("cmbCountry.Items187"), resources.GetString("cmbCountry.Items188"), resources.GetString("cmbCountry.Items189"), resources.GetString("cmbCountry.Items190"), resources.GetString("cmbCountry.Items191"), resources.GetString("cmbCountry.Items192"), resources.GetString("cmbCountry.Items193"), resources.GetString("cmbCountry.Items194") });
            resources.ApplyResources(cmbCountry, "cmbCountry");
            cmbCountry.Name = "cmbCountry";
            // 
            // chkExcel
            // 
            resources.ApplyResources(chkExcel, "chkExcel");
            chkExcel.Name = "chkExcel";
            chkExcel.UseVisualStyleBackColor = true;
            // 
            // chkPdf
            // 
            resources.ApplyResources(chkPdf, "chkPdf");
            chkPdf.Name = "chkPdf";
            chkPdf.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            resources.ApplyResources(btnExport, "btnExport");
            btnExport.Name = "btnExport";
            btnExport.UseVisualStyleBackColor = true;
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
            treeViewFiles.AfterSelect += treeViewFiles_AfterSelect_1;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // txtNotes
            // 
            txtNotes.AcceptsReturn = true;
            resources.ApplyResources(txtNotes, "txtNotes");
            txtNotes.Name = "txtNotes";
            // 
            // cmbRecluter
            // 
            cmbRecluter.FormattingEnabled = true;
            resources.ApplyResources(cmbRecluter, "cmbRecluter");
            cmbRecluter.Name = "cmbRecluter";
            // 
            // label9
            // 
            resources.ApplyResources(label9, "label9");
            label9.Name = "label9";
            // 
            // label15
            // 
            resources.ApplyResources(label15, "label15");
            label15.Name = "label15";
            // 
            // txtTags
            // 
            txtTags.AcceptsReturn = true;
            resources.ApplyResources(txtTags, "txtTags");
            txtTags.Name = "txtTags";
            // 
            // cmbContact
            // 
            cmbContact.FormattingEnabled = true;
            resources.ApplyResources(cmbContact, "cmbContact");
            cmbContact.Name = "cmbContact";
            // 
            // label16
            // 
            resources.ApplyResources(label16, "label16");
            label16.Name = "label16";
            label16.Click += label16_Click;
            // 
            // label17
            // 
            resources.ApplyResources(label17, "label17");
            label17.Name = "label17";
            // 
            // label18
            // 
            resources.ApplyResources(label18, "label18");
            label18.Name = "label18";
            // 
            // cmbRejectCandidate
            // 
            cmbRejectCandidate.FormattingEnabled = true;
            resources.ApplyResources(cmbRejectCandidate, "cmbRejectCandidate");
            cmbRejectCandidate.Name = "cmbRejectCandidate";
            // 
            // cmbRejectEmcor
            // 
            cmbRejectEmcor.FormattingEnabled = true;
            resources.ApplyResources(cmbRejectEmcor, "cmbRejectEmcor");
            cmbRejectEmcor.Name = "cmbRejectEmcor";
            // 
            // Candidates
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 254, 252);
            Controls.Add(cmbRejectEmcor);
            Controls.Add(cmbRejectCandidate);
            Controls.Add(label18);
            Controls.Add(label17);
            Controls.Add(cmbContact);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(txtTags);
            Controls.Add(cmbRecluter);
            Controls.Add(label9);
            Controls.Add(label3);
            Controls.Add(txtNotes);
            Controls.Add(pdfDocumentView1);
            Controls.Add(treeViewFiles);
            Controls.Add(chkExcel);
            Controls.Add(chkPdf);
            Controls.Add(btnExport);
            Controls.Add(cmbCountry);
            Controls.Add(label13);
            Controls.Add(txtCity);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(txtAge);
            Controls.Add(txtAdd);
            Controls.Add(label8);
            Controls.Add(cmbStages);
            Controls.Add(lblQuestions);
            Controls.Add(label10);
            Controls.Add(cmbVacancy);
            Controls.Add(Description);
            Controls.Add(btnSave);
            Controls.Add(btnNew);
            Controls.Add(lblDateModified);
            Controls.Add(lblNameModified);
            Controls.Add(lblDateCreated);
            Controls.Add(lblNameCreated);
            Controls.Add(label2);
            Controls.Add(chkActive);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(txtCandidateId);
            Controls.Add(lblSettingsID);
            Controls.Add(DataTable);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Candidates";
            Load += Customers_Load;
            ((System.ComponentModel.ISupportInitialize)DataTable).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtAge).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Zuby.ADGV.AdvancedDataGridView DataTable;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txtName;
        private Label lblName;
        private TextBox txtCandidateId;
        private Label lblSettingsID;
        private CheckBox chkActive;
        private Label label2;
        private Label lblNameCreated;
        private Label lblDateCreated;
        private Label lblNameModified;
        private Label lblDateModified;
        private Button btnNew;
        private Button btnSave;
        private Label Description;
        private Label label10;
        private ComboBox cmbVacancy;
        private Label lblQuestions;
        private Label label8;
        private ComboBox cmbStages;
        private TextBox txtAdd;
        private NumericUpDown txtAge;
        private Label label11;
        private TextBox txtCity;
        private Label label12;
        private Label label13;
        private ComboBox cmbCountry;
        private CheckBox chkExcel;
        private CheckBox chkPdf;
        private Button btnExport;
        private Syncfusion.Windows.Forms.PdfViewer.PdfDocumentView pdfDocumentView1;
        private TreeView treeViewFiles;
        private Label label3;
        private TextBox txtNotes;
        private ComboBox cmbRecluter;
        private Label label9;
        private Label label15;
        private TextBox txtTags;
        private ComboBox cmbContact;
        private Label label16;
        private Label label17;
        private Label label18;
        private ComboBox cmbRejectCandidate;
        private ComboBox cmbRejectEmcor;
    }
}
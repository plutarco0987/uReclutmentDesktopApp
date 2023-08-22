namespace uReclutmentConfigurations.views
{
    partial class Meetings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Meetings));
            label1 = new Label();
            DataTable = new Zuby.ADGV.AdvancedDataGridView();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            lblQuestion = new Label();
            txtMeetingId = new TextBox();
            lblSettingsID = new Label();
            chkActive = new CheckBox();
            label2 = new Label();
            lblNameCreated = new Label();
            lblDateCreated = new Label();
            lblNameModified = new Label();
            lblDateModified = new Label();
            btnNew = new Button();
            btnSave = new Button();
            label10 = new Label();
            lblQuestions = new Label();
            label8 = new Label();
            cmbCandidateId = new ComboBox();
            txtNoMeeting = new NumericUpDown();
            txtTime = new TextBox();
            txtCandidateName = new TextBox();
            label3 = new Label();
            chkExcel = new CheckBox();
            chkPdf = new CheckBox();
            btnExport = new Button();
            btnAllTime = new Button();
            lblTime = new Label();
            lblAllTime = new Label();
            ((System.ComponentModel.ISupportInitialize)DataTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNoMeeting).BeginInit();
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
            // lblQuestion
            // 
            resources.ApplyResources(lblQuestion, "lblQuestion");
            lblQuestion.Name = "lblQuestion";
            // 
            // txtMeetingId
            // 
            resources.ApplyResources(txtMeetingId, "txtMeetingId");
            txtMeetingId.Name = "txtMeetingId";
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
            // label10
            // 
            resources.ApplyResources(label10, "label10");
            label10.Name = "label10";
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
            // cmbCandidateId
            // 
            cmbCandidateId.FormattingEnabled = true;
            resources.ApplyResources(cmbCandidateId, "cmbCandidateId");
            cmbCandidateId.Name = "cmbCandidateId";
            cmbCandidateId.SelectedIndexChanged += cmbCandidateId_SelectedIndexChanged;
            // 
            // txtNoMeeting
            // 
            resources.ApplyResources(txtNoMeeting, "txtNoMeeting");
            txtNoMeeting.Maximum = new decimal(new int[] { 250, 0, 0, 0 });
            txtNoMeeting.Name = "txtNoMeeting";
            // 
            // txtTime
            // 
            resources.ApplyResources(txtTime, "txtTime");
            txtTime.Name = "txtTime";
            // 
            // txtCandidateName
            // 
            resources.ApplyResources(txtCandidateName, "txtCandidateName");
            txtCandidateName.Name = "txtCandidateName";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
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
            // btnAllTime
            // 
            resources.ApplyResources(btnAllTime, "btnAllTime");
            btnAllTime.Name = "btnAllTime";
            btnAllTime.UseVisualStyleBackColor = true;
            btnAllTime.Click += btnAllTime_Click;
            // 
            // lblTime
            // 
            resources.ApplyResources(lblTime, "lblTime");
            lblTime.Name = "lblTime";
            // 
            // lblAllTime
            // 
            resources.ApplyResources(lblAllTime, "lblAllTime");
            lblAllTime.Name = "lblAllTime";
            // 
            // Meetings
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 254, 252);
            Controls.Add(lblAllTime);
            Controls.Add(lblTime);
            Controls.Add(btnAllTime);
            Controls.Add(chkExcel);
            Controls.Add(chkPdf);
            Controls.Add(btnExport);
            Controls.Add(txtCandidateName);
            Controls.Add(label3);
            Controls.Add(txtTime);
            Controls.Add(txtNoMeeting);
            Controls.Add(label8);
            Controls.Add(cmbCandidateId);
            Controls.Add(lblQuestions);
            Controls.Add(label10);
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
            Controls.Add(lblQuestion);
            Controls.Add(txtMeetingId);
            Controls.Add(lblSettingsID);
            Controls.Add(DataTable);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Meetings";
            Load += Customers_Load;
            ((System.ComponentModel.ISupportInitialize)DataTable).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNoMeeting).EndInit();
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
        private Label lblQuestion;
        private TextBox txtMeetingId;
        private Label lblSettingsID;
        private CheckBox chkActive;
        private Label label2;
        private Label lblNameCreated;
        private Label lblDateCreated;
        private Label lblNameModified;
        private Label lblDateModified;
        private Button btnNew;
        private Button btnSave;
        private Label label10;
        private Label lblQuestions;
        private Label label8;
        private ComboBox cmbCandidateId;
        private NumericUpDown txtNoMeeting;
        private TextBox txtTime;
        private TextBox txtCandidateName;
        private Label label3;
        private CheckBox chkExcel;
        private CheckBox chkPdf;
        private Button btnExport;
        private Button btnAllTime;
        private Label lblTime;
        private Label lblAllTime;
    }
}
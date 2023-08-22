using System.Windows.Forms;
namespace uReclutmentWinForm.views
{
    partial class Questions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Questions));
            this.label1 = new System.Windows.Forms.Label();
            this.DataTable = new Zuby.ADGV.AdvancedDataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.txtCandidateId = new System.Windows.Forms.TextBox();
            this.lblSettingsID = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNameCreated = new System.Windows.Forms.Label();
            this.lblDateCreated = new System.Windows.Forms.Label();
            this.lblNameModified = new System.Windows.Forms.Label();
            this.lblDateModified = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbVacancy = new System.Windows.Forms.ComboBox();
            this.lblQuestions = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbEnum = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkRequired = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaxLength = new System.Windows.Forms.NumericUpDown();
            this.chkExcel = new System.Windows.Forms.CheckBox();
            this.chkPdf = new System.Windows.Forms.CheckBox();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxLength)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // DataTable
            // 
            this.DataTable.AllowUserToAddRows = false;
            this.DataTable.FilterAndSortEnabled = true;
            this.DataTable.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            resources.ApplyResources(this.DataTable, "DataTable");
            this.DataTable.MultiSelect = false;
            this.DataTable.Name = "DataTable";
            this.DataTable.ReadOnly = true;
            this.DataTable.RowTemplate.Height = 25;
            this.DataTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataTable.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.DataTable.SortStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.SortEventArgs>(this.DataTable_SortStringChanged);
            this.DataTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataTable_CellEndEdit);
            this.DataTable.SelectionChanged += new System.EventHandler(this.DataTable_SelectionChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtQuestion
            // 
            this.txtQuestion.AcceptsReturn = true;
            resources.ApplyResources(this.txtQuestion, "txtQuestion");
            this.txtQuestion.Name = "txtQuestion";
            // 
            // lblQuestion
            // 
            resources.ApplyResources(this.lblQuestion, "lblQuestion");
            this.lblQuestion.Name = "lblQuestion";
            // 
            // txtCandidateId
            // 
            resources.ApplyResources(this.txtCandidateId, "txtCandidateId");
            this.txtCandidateId.Name = "txtCandidateId";
            // 
            // lblSettingsID
            // 
            resources.ApplyResources(this.lblSettingsID, "lblSettingsID");
            this.lblSettingsID.Name = "lblSettingsID";
            // 
            // chkActive
            // 
            resources.ApplyResources(this.chkActive, "chkActive");
            this.chkActive.Name = "chkActive";
            this.chkActive.UseVisualStyleBackColor = true;
            this.chkActive.CheckedChanged += new System.EventHandler(this.chkActive_CheckedChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lblNameCreated
            // 
            resources.ApplyResources(this.lblNameCreated, "lblNameCreated");
            this.lblNameCreated.Name = "lblNameCreated";
            // 
            // lblDateCreated
            // 
            resources.ApplyResources(this.lblDateCreated, "lblDateCreated");
            this.lblDateCreated.Name = "lblDateCreated";
            // 
            // lblNameModified
            // 
            resources.ApplyResources(this.lblNameModified, "lblNameModified");
            this.lblNameModified.Name = "lblNameModified";
            // 
            // lblDateModified
            // 
            resources.ApplyResources(this.lblDateModified, "lblDateModified");
            this.lblDateModified.Name = "lblDateModified";
            // 
            // btnNew
            // 
            resources.ApplyResources(this.btnNew, "btnNew");
            this.btnNew.Name = "btnNew";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // cmbVacancy
            // 
            this.cmbVacancy.FormattingEnabled = true;
            resources.ApplyResources(this.cmbVacancy, "cmbVacancy");
            this.cmbVacancy.Name = "cmbVacancy";
            // 
            // lblQuestions
            // 
            resources.ApplyResources(this.lblQuestions, "lblQuestions");
            this.lblQuestions.Name = "lblQuestions";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // cmbEnum
            // 
            this.cmbEnum.FormattingEnabled = true;
            resources.ApplyResources(this.cmbEnum, "cmbEnum");
            this.cmbEnum.Name = "cmbEnum";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // chkRequired
            // 
            resources.ApplyResources(this.chkRequired, "chkRequired");
            this.chkRequired.Name = "chkRequired";
            this.chkRequired.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtMaxLength
            // 
            resources.ApplyResources(this.txtMaxLength, "txtMaxLength");
            this.txtMaxLength.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.txtMaxLength.Name = "txtMaxLength";
            // 
            // chkExcel
            // 
            resources.ApplyResources(this.chkExcel, "chkExcel");
            this.chkExcel.Name = "chkExcel";
            this.chkExcel.UseVisualStyleBackColor = true;
            // 
            // chkPdf
            // 
            resources.ApplyResources(this.chkPdf, "chkPdf");
            this.chkPdf.Name = "chkPdf";
            this.chkPdf.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            resources.ApplyResources(this.btnExport, "btnExport");
            this.btnExport.Name = "btnExport";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // Questions
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(254)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.chkExcel);
            this.Controls.Add(this.chkPdf);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.txtMaxLength);
            this.Controls.Add(this.chkRequired);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbEnum);
            this.Controls.Add(this.lblQuestions);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbVacancy);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lblDateModified);
            this.Controls.Add(this.lblNameModified);
            this.Controls.Add(this.lblDateCreated);
            this.Controls.Add(this.lblNameCreated);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.txtCandidateId);
            this.Controls.Add(this.lblSettingsID);
            this.Controls.Add(this.DataTable);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Questions";
            this.Load += new System.EventHandler(this.Customers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaxLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Zuby.ADGV.AdvancedDataGridView DataTable;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txtQuestion;
        private Label lblQuestion;
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
        private Label label10;
        private ComboBox cmbVacancy;
        private Label lblQuestions;
        private Label label8;
        private ComboBox cmbEnum;
        private Label label11;
        private CheckBox chkRequired;
        private Label label3;
        private NumericUpDown txtMaxLength;
        private CheckBox chkExcel;
        private CheckBox chkPdf;
        private Button btnExport;
    }
}
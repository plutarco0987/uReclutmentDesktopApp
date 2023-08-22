namespace uReclutmentConfigurations.views
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            label1 = new Label();
            DataTable = new Zuby.ADGV.AdvancedDataGridView();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txtValue = new TextBox();
            label3 = new Label();
            txtName = new TextBox();
            lblName = new Label();
            txtSettingsId = new TextBox();
            lblSettingsID = new Label();
            chkActive = new CheckBox();
            label2 = new Label();
            lblNameCreated = new Label();
            lblDateCreated = new Label();
            lblNameModified = new Label();
            lblDateModified = new Label();
            btnNew = new Button();
            btnSave = new Button();
            chkExcel = new CheckBox();
            chkPdf = new CheckBox();
            btnExport = new Button();
            ((System.ComponentModel.ISupportInitialize)DataTable).BeginInit();
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
            // txtValue
            // 
            txtValue.AcceptsTab = true;
            resources.ApplyResources(txtValue, "txtValue");
            txtValue.Name = "txtValue";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
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
            // txtSettingsId
            // 
            resources.ApplyResources(txtSettingsId, "txtSettingsId");
            txtSettingsId.Name = "txtSettingsId";
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
            // Settings
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 254, 252);
            Controls.Add(chkExcel);
            Controls.Add(chkPdf);
            Controls.Add(btnExport);
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
            Controls.Add(txtValue);
            Controls.Add(label3);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(txtSettingsId);
            Controls.Add(lblSettingsID);
            Controls.Add(DataTable);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Settings";
            ((System.ComponentModel.ISupportInitialize)DataTable).EndInit();
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
        private TextBox txtValue;
        private Label label3;
        private TextBox txtName;
        private Label lblName;
        private TextBox txtSettingsId;
        private Label lblSettingsID;
        private CheckBox chkActive;
        private Label label2;
        private Label lblNameCreated;
        private Label lblDateCreated;
        private Label lblNameModified;
        private Label lblDateModified;
        private Button btnNew;
        private Button btnSave;
        private CheckBox chkExcel;
        private CheckBox chkPdf;
        private Button btnExport;
    }
}
using System.Windows.Forms;
namespace uReclutmentWinForm.views
{
    partial class Stages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stages));
            this.label1 = new System.Windows.Forms.Label();
            this.DataTable = new Zuby.ADGV.AdvancedDataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtStagesId = new System.Windows.Forms.TextBox();
            this.lblSettingsID = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNameCreated = new System.Windows.Forms.Label();
            this.lblDateCreated = new System.Windows.Forms.Label();
            this.lblNameModified = new System.Windows.Forms.Label();
            this.lblDateModified = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOrder = new System.Windows.Forms.NumericUpDown();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.panelColor = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.chkPdf = new System.Windows.Forms.CheckBox();
            this.chkExcel = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrder)).BeginInit();
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
            // txtColor
            // 
            resources.ApplyResources(this.txtColor, "txtColor");
            this.txtColor.Name = "txtColor";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtName
            // 
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.Name = "txtName";
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // txtStagesId
            // 
            resources.ApplyResources(this.txtStagesId, "txtStagesId");
            this.txtStagesId.Name = "txtStagesId";
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
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // txtOrder
            // 
            resources.ApplyResources(this.txtOrder, "txtOrder");
            this.txtOrder.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelColor
            // 
            resources.ApplyResources(this.panelColor, "panelColor");
            this.panelColor.Name = "panelColor";
            // 
            // btnExport
            // 
            resources.ApplyResources(this.btnExport, "btnExport");
            this.btnExport.Name = "btnExport";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // chkPdf
            // 
            resources.ApplyResources(this.chkPdf, "chkPdf");
            this.chkPdf.Name = "chkPdf";
            this.chkPdf.UseVisualStyleBackColor = true;
            // 
            // chkExcel
            // 
            resources.ApplyResources(this.chkExcel, "chkExcel");
            this.chkExcel.Name = "chkExcel";
            this.chkExcel.UseVisualStyleBackColor = true;
            // 
            // Stages
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(254)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.chkExcel);
            this.Controls.Add(this.chkPdf);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.panelColor);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtOrder);
            this.Controls.Add(this.label8);
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
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtStagesId);
            this.Controls.Add(this.lblSettingsID);
            this.Controls.Add(this.DataTable);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Stages";
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrder)).EndInit();
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
        private TextBox txtColor;
        private Label label3;
        private TextBox txtName;
        private Label lblName;
        private TextBox txtStagesId;
        private Label lblSettingsID;
        private CheckBox chkActive;
        private Label label2;
        private Label lblNameCreated;
        private Label lblDateCreated;
        private Label lblNameModified;
        private Label lblDateModified;
        private Button btnNew;
        private Button btnSave;
        private Label label8;
        private NumericUpDown txtOrder;
        private ColorDialog colorDialog1;
        private Button button1;
        private Panel panelColor;
        private Button btnExport;
        private CheckBox chkPdf;
        private CheckBox chkExcel;
    }
}
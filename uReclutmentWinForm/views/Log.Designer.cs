using System.Windows.Forms;
namespace uReclutmentWinForm.views
{
    partial class Log
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Log));
            this.label1 = new System.Windows.Forms.Label();
            this.DataTable = new Zuby.ADGV.AdvancedDataGridView();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.chkExcel = new System.Windows.Forms.CheckBox();
            this.chkPdf = new System.Windows.Forms.CheckBox();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).BeginInit();
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
            // Log
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(254)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.chkExcel);
            this.Controls.Add(this.chkPdf);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.DataTable);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Log";
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Zuby.ADGV.AdvancedDataGridView DataTable;
        private ColorDialog colorDialog1;
        private CheckBox chkExcel;
        private CheckBox chkPdf;
        private Button btnExport;
    }
}
using System.Windows.Forms;
namespace uReclutmentWinForm.views
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
            this.label1 = new System.Windows.Forms.Label();
            this.DataTable = new Zuby.ADGV.AdvancedDataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
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
            this.Description = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbVacancy = new System.Windows.Forms.ComboBox();
            this.lblQuestions = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbStages = new System.Windows.Forms.ComboBox();
            this.txtAdd = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.chkExcel = new System.Windows.Forms.CheckBox();
            this.chkPdf = new System.Windows.Forms.CheckBox();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAge)).BeginInit();
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
            // Description
            // 
            resources.ApplyResources(this.Description, "Description");
            this.Description.Name = "Description";
            this.Description.Click += new System.EventHandler(this.label3_Click);
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
            // cmbStages
            // 
            this.cmbStages.FormattingEnabled = true;
            resources.ApplyResources(this.cmbStages, "cmbStages");
            this.cmbStages.Name = "cmbStages";
            // 
            // txtAdd
            // 
            this.txtAdd.AcceptsReturn = true;
            resources.ApplyResources(this.txtAdd, "txtAdd");
            this.txtAdd.Name = "txtAdd";
            // 
            // txtAge
            // 
            resources.ApplyResources(this.txtAge, "txtAge");
            this.txtAge.Name = "txtAge";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // txtCity
            // 
            resources.ApplyResources(this.txtCity, "txtCity");
            this.txtCity.Name = "txtCity";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // cmbCountry
            // 
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Items.AddRange(new object[] {
            resources.GetString("cmbCountry.Items"),
            resources.GetString("cmbCountry.Items1"),
            resources.GetString("cmbCountry.Items2"),
            resources.GetString("cmbCountry.Items3"),
            resources.GetString("cmbCountry.Items4"),
            resources.GetString("cmbCountry.Items5"),
            resources.GetString("cmbCountry.Items6"),
            resources.GetString("cmbCountry.Items7"),
            resources.GetString("cmbCountry.Items8"),
            resources.GetString("cmbCountry.Items9"),
            resources.GetString("cmbCountry.Items10"),
            resources.GetString("cmbCountry.Items11"),
            resources.GetString("cmbCountry.Items12"),
            resources.GetString("cmbCountry.Items13"),
            resources.GetString("cmbCountry.Items14"),
            resources.GetString("cmbCountry.Items15"),
            resources.GetString("cmbCountry.Items16"),
            resources.GetString("cmbCountry.Items17"),
            resources.GetString("cmbCountry.Items18"),
            resources.GetString("cmbCountry.Items19"),
            resources.GetString("cmbCountry.Items20"),
            resources.GetString("cmbCountry.Items21"),
            resources.GetString("cmbCountry.Items22"),
            resources.GetString("cmbCountry.Items23"),
            resources.GetString("cmbCountry.Items24"),
            resources.GetString("cmbCountry.Items25"),
            resources.GetString("cmbCountry.Items26"),
            resources.GetString("cmbCountry.Items27"),
            resources.GetString("cmbCountry.Items28"),
            resources.GetString("cmbCountry.Items29"),
            resources.GetString("cmbCountry.Items30"),
            resources.GetString("cmbCountry.Items31"),
            resources.GetString("cmbCountry.Items32"),
            resources.GetString("cmbCountry.Items33"),
            resources.GetString("cmbCountry.Items34"),
            resources.GetString("cmbCountry.Items35"),
            resources.GetString("cmbCountry.Items36"),
            resources.GetString("cmbCountry.Items37"),
            resources.GetString("cmbCountry.Items38"),
            resources.GetString("cmbCountry.Items39"),
            resources.GetString("cmbCountry.Items40"),
            resources.GetString("cmbCountry.Items41"),
            resources.GetString("cmbCountry.Items42"),
            resources.GetString("cmbCountry.Items43"),
            resources.GetString("cmbCountry.Items44"),
            resources.GetString("cmbCountry.Items45"),
            resources.GetString("cmbCountry.Items46"),
            resources.GetString("cmbCountry.Items47"),
            resources.GetString("cmbCountry.Items48"),
            resources.GetString("cmbCountry.Items49"),
            resources.GetString("cmbCountry.Items50"),
            resources.GetString("cmbCountry.Items51"),
            resources.GetString("cmbCountry.Items52"),
            resources.GetString("cmbCountry.Items53"),
            resources.GetString("cmbCountry.Items54"),
            resources.GetString("cmbCountry.Items55"),
            resources.GetString("cmbCountry.Items56"),
            resources.GetString("cmbCountry.Items57"),
            resources.GetString("cmbCountry.Items58"),
            resources.GetString("cmbCountry.Items59"),
            resources.GetString("cmbCountry.Items60"),
            resources.GetString("cmbCountry.Items61"),
            resources.GetString("cmbCountry.Items62"),
            resources.GetString("cmbCountry.Items63"),
            resources.GetString("cmbCountry.Items64"),
            resources.GetString("cmbCountry.Items65"),
            resources.GetString("cmbCountry.Items66"),
            resources.GetString("cmbCountry.Items67"),
            resources.GetString("cmbCountry.Items68"),
            resources.GetString("cmbCountry.Items69"),
            resources.GetString("cmbCountry.Items70"),
            resources.GetString("cmbCountry.Items71"),
            resources.GetString("cmbCountry.Items72"),
            resources.GetString("cmbCountry.Items73"),
            resources.GetString("cmbCountry.Items74"),
            resources.GetString("cmbCountry.Items75"),
            resources.GetString("cmbCountry.Items76"),
            resources.GetString("cmbCountry.Items77"),
            resources.GetString("cmbCountry.Items78"),
            resources.GetString("cmbCountry.Items79"),
            resources.GetString("cmbCountry.Items80"),
            resources.GetString("cmbCountry.Items81"),
            resources.GetString("cmbCountry.Items82"),
            resources.GetString("cmbCountry.Items83"),
            resources.GetString("cmbCountry.Items84"),
            resources.GetString("cmbCountry.Items85"),
            resources.GetString("cmbCountry.Items86"),
            resources.GetString("cmbCountry.Items87"),
            resources.GetString("cmbCountry.Items88"),
            resources.GetString("cmbCountry.Items89"),
            resources.GetString("cmbCountry.Items90"),
            resources.GetString("cmbCountry.Items91"),
            resources.GetString("cmbCountry.Items92"),
            resources.GetString("cmbCountry.Items93"),
            resources.GetString("cmbCountry.Items94"),
            resources.GetString("cmbCountry.Items95"),
            resources.GetString("cmbCountry.Items96"),
            resources.GetString("cmbCountry.Items97"),
            resources.GetString("cmbCountry.Items98"),
            resources.GetString("cmbCountry.Items99"),
            resources.GetString("cmbCountry.Items100"),
            resources.GetString("cmbCountry.Items101"),
            resources.GetString("cmbCountry.Items102"),
            resources.GetString("cmbCountry.Items103"),
            resources.GetString("cmbCountry.Items104"),
            resources.GetString("cmbCountry.Items105"),
            resources.GetString("cmbCountry.Items106"),
            resources.GetString("cmbCountry.Items107"),
            resources.GetString("cmbCountry.Items108"),
            resources.GetString("cmbCountry.Items109"),
            resources.GetString("cmbCountry.Items110"),
            resources.GetString("cmbCountry.Items111"),
            resources.GetString("cmbCountry.Items112"),
            resources.GetString("cmbCountry.Items113"),
            resources.GetString("cmbCountry.Items114"),
            resources.GetString("cmbCountry.Items115"),
            resources.GetString("cmbCountry.Items116"),
            resources.GetString("cmbCountry.Items117"),
            resources.GetString("cmbCountry.Items118"),
            resources.GetString("cmbCountry.Items119"),
            resources.GetString("cmbCountry.Items120"),
            resources.GetString("cmbCountry.Items121"),
            resources.GetString("cmbCountry.Items122"),
            resources.GetString("cmbCountry.Items123"),
            resources.GetString("cmbCountry.Items124"),
            resources.GetString("cmbCountry.Items125"),
            resources.GetString("cmbCountry.Items126"),
            resources.GetString("cmbCountry.Items127"),
            resources.GetString("cmbCountry.Items128"),
            resources.GetString("cmbCountry.Items129"),
            resources.GetString("cmbCountry.Items130"),
            resources.GetString("cmbCountry.Items131"),
            resources.GetString("cmbCountry.Items132"),
            resources.GetString("cmbCountry.Items133"),
            resources.GetString("cmbCountry.Items134"),
            resources.GetString("cmbCountry.Items135"),
            resources.GetString("cmbCountry.Items136"),
            resources.GetString("cmbCountry.Items137"),
            resources.GetString("cmbCountry.Items138"),
            resources.GetString("cmbCountry.Items139"),
            resources.GetString("cmbCountry.Items140"),
            resources.GetString("cmbCountry.Items141"),
            resources.GetString("cmbCountry.Items142"),
            resources.GetString("cmbCountry.Items143"),
            resources.GetString("cmbCountry.Items144"),
            resources.GetString("cmbCountry.Items145"),
            resources.GetString("cmbCountry.Items146"),
            resources.GetString("cmbCountry.Items147"),
            resources.GetString("cmbCountry.Items148"),
            resources.GetString("cmbCountry.Items149"),
            resources.GetString("cmbCountry.Items150"),
            resources.GetString("cmbCountry.Items151"),
            resources.GetString("cmbCountry.Items152"),
            resources.GetString("cmbCountry.Items153"),
            resources.GetString("cmbCountry.Items154"),
            resources.GetString("cmbCountry.Items155"),
            resources.GetString("cmbCountry.Items156"),
            resources.GetString("cmbCountry.Items157"),
            resources.GetString("cmbCountry.Items158"),
            resources.GetString("cmbCountry.Items159"),
            resources.GetString("cmbCountry.Items160"),
            resources.GetString("cmbCountry.Items161"),
            resources.GetString("cmbCountry.Items162"),
            resources.GetString("cmbCountry.Items163"),
            resources.GetString("cmbCountry.Items164"),
            resources.GetString("cmbCountry.Items165"),
            resources.GetString("cmbCountry.Items166"),
            resources.GetString("cmbCountry.Items167"),
            resources.GetString("cmbCountry.Items168"),
            resources.GetString("cmbCountry.Items169"),
            resources.GetString("cmbCountry.Items170"),
            resources.GetString("cmbCountry.Items171"),
            resources.GetString("cmbCountry.Items172"),
            resources.GetString("cmbCountry.Items173"),
            resources.GetString("cmbCountry.Items174"),
            resources.GetString("cmbCountry.Items175"),
            resources.GetString("cmbCountry.Items176"),
            resources.GetString("cmbCountry.Items177"),
            resources.GetString("cmbCountry.Items178"),
            resources.GetString("cmbCountry.Items179"),
            resources.GetString("cmbCountry.Items180"),
            resources.GetString("cmbCountry.Items181"),
            resources.GetString("cmbCountry.Items182"),
            resources.GetString("cmbCountry.Items183"),
            resources.GetString("cmbCountry.Items184"),
            resources.GetString("cmbCountry.Items185"),
            resources.GetString("cmbCountry.Items186"),
            resources.GetString("cmbCountry.Items187"),
            resources.GetString("cmbCountry.Items188"),
            resources.GetString("cmbCountry.Items189"),
            resources.GetString("cmbCountry.Items190"),
            resources.GetString("cmbCountry.Items191"),
            resources.GetString("cmbCountry.Items192"),
            resources.GetString("cmbCountry.Items193"),
            resources.GetString("cmbCountry.Items194")});
            resources.ApplyResources(this.cmbCountry, "cmbCountry");
            this.cmbCountry.Name = "cmbCountry";
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
            // Candidates
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(254)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.chkExcel);
            this.Controls.Add(this.chkPdf);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.cmbCountry);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtAdd);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbStages);
            this.Controls.Add(this.lblQuestions);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbVacancy);
            this.Controls.Add(this.Description);
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
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtCandidateId);
            this.Controls.Add(this.lblSettingsID);
            this.Controls.Add(this.DataTable);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Candidates";
            this.Load += new System.EventHandler(this.Customers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAge)).EndInit();
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
    }
}
namespace uReclutmentConfigurations.views
{
    partial class Execute
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Execute));
            label1 = new Label();
            openFileDialog1 = new OpenFileDialog();
            label2 = new Label();
            button1 = new Button();
            groupBox1 = new GroupBox();
            btnMigration = new Button();
            cmbMigration = new ComboBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            btnGenerateVacancys = new Button();
            txtVacancy = new TextBox();
            tabPage2 = new TabPage();
            cmbVacancys = new ComboBox();
            button2 = new Button();
            txtDetail = new TextBox();
            groupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnMigration);
            groupBox1.Controls.Add(cmbMigration);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label2);
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            // 
            // btnMigration
            // 
            resources.ApplyResources(btnMigration, "btnMigration");
            btnMigration.Name = "btnMigration";
            btnMigration.UseVisualStyleBackColor = true;
            btnMigration.Click += btnMigration_Click;
            // 
            // cmbMigration
            // 
            cmbMigration.FormattingEnabled = true;
            cmbMigration.Items.AddRange(new object[] { resources.GetString("cmbMigration.Items"), resources.GetString("cmbMigration.Items1"), resources.GetString("cmbMigration.Items2") });
            resources.ApplyResources(cmbMigration, "cmbMigration");
            cmbMigration.Name = "cmbMigration";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            resources.ApplyResources(tabControl1, "tabControl1");
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnGenerateVacancys);
            tabPage1.Controls.Add(txtVacancy);
            resources.ApplyResources(tabPage1, "tabPage1");
            tabPage1.Name = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnGenerateVacancys
            // 
            resources.ApplyResources(btnGenerateVacancys, "btnGenerateVacancys");
            btnGenerateVacancys.Name = "btnGenerateVacancys";
            btnGenerateVacancys.UseVisualStyleBackColor = true;
            btnGenerateVacancys.Click += btnGenerateVacancys_Click;
            // 
            // txtVacancy
            // 
            txtVacancy.AcceptsReturn = true;
            resources.ApplyResources(txtVacancy, "txtVacancy");
            txtVacancy.Name = "txtVacancy";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(cmbVacancys);
            tabPage2.Controls.Add(button2);
            tabPage2.Controls.Add(txtDetail);
            resources.ApplyResources(tabPage2, "tabPage2");
            tabPage2.Name = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // cmbVacancys
            // 
            cmbVacancys.FormattingEnabled = true;
            resources.ApplyResources(cmbVacancys, "cmbVacancys");
            cmbVacancys.Name = "cmbVacancys";
            // 
            // button2
            // 
            resources.ApplyResources(button2, "button2");
            button2.Name = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // txtDetail
            // 
            txtDetail.AcceptsReturn = true;
            resources.ApplyResources(txtDetail, "txtDetail");
            txtDetail.Name = "txtDetail";
            // 
            // Execute
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(252, 254, 252);
            Controls.Add(tabControl1);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Execute";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private OpenFileDialog openFileDialog1;
        private Label label2;
        private Button button1;
        private GroupBox groupBox1;
        private Button btnMigration;
        private ComboBox cmbMigration;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button btnGenerateVacancys;
        private TextBox txtVacancy;
        private ComboBox cmbVacancys;
        private Button button2;
        private TextBox txtDetail;
    }
}
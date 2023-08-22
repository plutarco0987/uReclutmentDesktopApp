namespace uReclutmentConfigurations.views
{
    partial class QuestionDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionDetails));
            this.label1 = new System.Windows.Forms.Label();
            this.DataTable = new Zuby.ADGV.AdvancedDataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.txtAnswerId = new System.Windows.Forms.TextBox();
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
            this.cmbCandidate = new System.Windows.Forms.ComboBox();
            this.lblQuestions = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbQuestionId = new System.Windows.Forms.ComboBox();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DataTableComments = new Zuby.ADGV.AdvancedDataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDateModifiedComment = new System.Windows.Forms.Label();
            this.lblNameModifiedComment = new System.Windows.Forms.Label();
            this.lblDateCreatedComment = new System.Windows.Forms.Label();
            this.lblNameCreateComment = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCommentId = new System.Windows.Forms.TextBox();
            this.CommentId = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.Coment = new System.Windows.Forms.Label();
            this.btnSaveComment = new System.Windows.Forms.Button();
            this.btnNewComment = new System.Windows.Forms.Button();
            this.chkActiveComment = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.chkExcel = new System.Windows.Forms.CheckBox();
            this.chkPdf = new System.Windows.Forms.CheckBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableComments)).BeginInit();
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
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtAnswer
            // 
            this.txtAnswer.AcceptsReturn = true;
            resources.ApplyResources(this.txtAnswer, "txtAnswer");
            this.txtAnswer.Name = "txtAnswer";
            // 
            // lblQuestion
            // 
            resources.ApplyResources(this.lblQuestion, "lblQuestion");
            this.lblQuestion.Name = "lblQuestion";
            // 
            // txtAnswerId
            // 
            resources.ApplyResources(this.txtAnswerId, "txtAnswerId");
            this.txtAnswerId.Name = "txtAnswerId";
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
            // cmbCandidate
            // 
            this.cmbCandidate.FormattingEnabled = true;
            resources.ApplyResources(this.cmbCandidate, "cmbCandidate");
            this.cmbCandidate.Name = "cmbCandidate";
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
            // cmbQuestionId
            // 
            this.cmbQuestionId.FormattingEnabled = true;
            resources.ApplyResources(this.cmbQuestionId, "cmbQuestionId");
            this.cmbQuestionId.Name = "cmbQuestionId";
            this.cmbQuestionId.SelectedIndexChanged += new System.EventHandler(this.cmbQuestionId_SelectedIndexChanged);
            // 
            // txtQuestion
            // 
            this.txtQuestion.AcceptsReturn = true;
            resources.ApplyResources(this.txtQuestion, "txtQuestion");
            this.txtQuestion.Name = "txtQuestion";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // DataTableComments
            // 
            this.DataTableComments.AllowUserToAddRows = false;
            this.DataTableComments.FilterAndSortEnabled = true;
            this.DataTableComments.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            resources.ApplyResources(this.DataTableComments, "DataTableComments");
            this.DataTableComments.MultiSelect = false;
            this.DataTableComments.Name = "DataTableComments";
            this.DataTableComments.ReadOnly = true;
            this.DataTableComments.RowTemplate.Height = 25;
            this.DataTableComments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataTableComments.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.DataTableComments.SelectionChanged += new System.EventHandler(this.DataTableComments_SelectionChanged);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // lblDateModifiedComment
            // 
            resources.ApplyResources(this.lblDateModifiedComment, "lblDateModifiedComment");
            this.lblDateModifiedComment.Name = "lblDateModifiedComment";
            // 
            // lblNameModifiedComment
            // 
            resources.ApplyResources(this.lblNameModifiedComment, "lblNameModifiedComment");
            this.lblNameModifiedComment.Name = "lblNameModifiedComment";
            // 
            // lblDateCreatedComment
            // 
            resources.ApplyResources(this.lblDateCreatedComment, "lblDateCreatedComment");
            this.lblDateCreatedComment.Name = "lblDateCreatedComment";
            // 
            // lblNameCreateComment
            // 
            resources.ApplyResources(this.lblNameCreateComment, "lblNameCreateComment");
            this.lblNameCreateComment.Name = "lblNameCreateComment";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
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
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // txtCommentId
            // 
            resources.ApplyResources(this.txtCommentId, "txtCommentId");
            this.txtCommentId.Name = "txtCommentId";
            // 
            // CommentId
            // 
            resources.ApplyResources(this.CommentId, "CommentId");
            this.CommentId.Name = "CommentId";
            // 
            // txtComment
            // 
            this.txtComment.AcceptsReturn = true;
            resources.ApplyResources(this.txtComment, "txtComment");
            this.txtComment.Name = "txtComment";
            // 
            // Coment
            // 
            resources.ApplyResources(this.Coment, "Coment");
            this.Coment.Name = "Coment";
            // 
            // btnSaveComment
            // 
            resources.ApplyResources(this.btnSaveComment, "btnSaveComment");
            this.btnSaveComment.Name = "btnSaveComment";
            this.btnSaveComment.UseVisualStyleBackColor = true;
            this.btnSaveComment.Click += new System.EventHandler(this.btnSaveComment_Click);
            // 
            // btnNewComment
            // 
            resources.ApplyResources(this.btnNewComment, "btnNewComment");
            this.btnNewComment.Name = "btnNewComment";
            this.btnNewComment.UseVisualStyleBackColor = true;
            this.btnNewComment.Click += new System.EventHandler(this.btnNewComment_Click);
            // 
            // chkActiveComment
            // 
            resources.ApplyResources(this.chkActiveComment, "chkActiveComment");
            this.chkActiveComment.Name = "chkActiveComment";
            this.chkActiveComment.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
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
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // QuestionDetails
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(254)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkExcel);
            this.Controls.Add(this.chkPdf);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnSaveComment);
            this.Controls.Add(this.btnNewComment);
            this.Controls.Add(this.chkActiveComment);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.Coment);
            this.Controls.Add(this.txtCommentId);
            this.Controls.Add(this.CommentId);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblDateModifiedComment);
            this.Controls.Add(this.lblNameModifiedComment);
            this.Controls.Add(this.lblDateCreatedComment);
            this.Controls.Add(this.lblNameCreateComment);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.DataTableComments);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbQuestionId);
            this.Controls.Add(this.lblQuestions);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbCandidate);
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
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.txtAnswerId);
            this.Controls.Add(this.lblSettingsID);
            this.Controls.Add(this.DataTable);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QuestionDetails";
            this.Load += new System.EventHandler(this.Customers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableComments)).EndInit();
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
        private TextBox txtAnswer;
        private Label lblQuestion;
        private TextBox txtAnswerId;
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
        private ComboBox cmbCandidate;
        private Label lblQuestions;
        private Label label8;
        private ComboBox cmbQuestionId;
        private TextBox txtQuestion;
        private Label label3;
        private Zuby.ADGV.AdvancedDataGridView DataTableComments;
        private Label label9;
        private Label lblDateModifiedComment;
        private Label lblNameModifiedComment;
        private Label lblDateCreatedComment;
        private Label lblNameCreateComment;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private TextBox txtCommentId;
        private Label CommentId;
        private TextBox txtComment;
        private Label Coment;
        private Button btnSaveComment;
        private Button btnNewComment;
        private CheckBox chkActiveComment;
        private Label label15;
        private CheckBox chkExcel;
        private CheckBox chkPdf;
        private Button btnExport;
        private Button button1;
        private Button button2;
    }
}
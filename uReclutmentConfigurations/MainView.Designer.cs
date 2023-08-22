namespace uReclutmentConfigurations
{
    partial class MainView
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.iconMinimice = new FontAwesome.Sharp.IconPictureBox();
            this.iconMaximice = new FontAwesome.Sharp.IconPictureBox();
            this.iconCLose = new FontAwesome.Sharp.IconPictureBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnMeeting = new FontAwesome.Sharp.IconButton();
            this.panelSubMenu = new System.Windows.Forms.Panel();
            this.btnUsers = new FontAwesome.Sharp.IconButton();
            this.btnVacancy = new FontAwesome.Sharp.IconButton();
            this.btnStages = new FontAwesome.Sharp.IconButton();
            this.btnRequirements = new FontAwesome.Sharp.IconButton();
            this.btnAnswers = new FontAwesome.Sharp.IconButton();
            this.btnQuestions = new FontAwesome.Sharp.IconButton();
            this.btnMeetings = new FontAwesome.Sharp.IconButton();
            this.btnLog = new FontAwesome.Sharp.IconButton();
            this.btnEnum = new FontAwesome.Sharp.IconButton();
            this.btnCustomers = new FontAwesome.Sharp.IconButton();
            this.btnFiles = new FontAwesome.Sharp.IconButton();
            this.btnCandidates = new FontAwesome.Sharp.IconButton();
            this.btnAdministration = new FontAwesome.Sharp.IconButton();
            this.btnSettings = new FontAwesome.Sharp.IconButton();
            this.panelContent = new System.Windows.Forms.Panel();
            this.lblLoading = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconMinimice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconMaximice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconCLose)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.panelSubMenu.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(48)))), ((int)(((byte)(200)))));
            this.panelTop.Controls.Add(this.iconMinimice);
            this.panelTop.Controls.Add(this.iconMaximice);
            this.panelTop.Controls.Add(this.iconCLose);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1115, 35);
            this.panelTop.TabIndex = 0;
            this.panelTop.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseDoubleClick);
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseDown);
            // 
            // iconMinimice
            // 
            this.iconMinimice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconMinimice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(48)))), ((int)(((byte)(200)))));
            this.iconMinimice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconMinimice.IconChar = FontAwesome.Sharp.IconChar.Subtract;
            this.iconMinimice.IconColor = System.Drawing.Color.White;
            this.iconMinimice.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMinimice.Location = new System.Drawing.Point(1027, 0);
            this.iconMinimice.Name = "iconMinimice";
            this.iconMinimice.Size = new System.Drawing.Size(32, 32);
            this.iconMinimice.TabIndex = 1;
            this.iconMinimice.TabStop = false;
            this.iconMinimice.Click += new System.EventHandler(this.iconMinimice_Click);
            // 
            // iconMaximice
            // 
            this.iconMaximice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconMaximice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(48)))), ((int)(((byte)(200)))));
            this.iconMaximice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconMaximice.IconChar = FontAwesome.Sharp.IconChar.Square;
            this.iconMaximice.IconColor = System.Drawing.Color.White;
            this.iconMaximice.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMaximice.Location = new System.Drawing.Point(1055, 0);
            this.iconMaximice.Name = "iconMaximice";
            this.iconMaximice.Size = new System.Drawing.Size(32, 32);
            this.iconMaximice.TabIndex = 1;
            this.iconMaximice.TabStop = false;
            this.iconMaximice.Click += new System.EventHandler(this.iconMaximice_Click);
            this.iconMaximice.MouseLeave += new System.EventHandler(this.iconMaximice_MouseLeave);
            this.iconMaximice.MouseHover += new System.EventHandler(this.iconMaximice_MouseHover);
            // 
            // iconCLose
            // 
            this.iconCLose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconCLose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(48)))), ((int)(((byte)(200)))));
            this.iconCLose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconCLose.ForeColor = System.Drawing.Color.Red;
            this.iconCLose.IconChar = FontAwesome.Sharp.IconChar.Multiply;
            this.iconCLose.IconColor = System.Drawing.Color.Red;
            this.iconCLose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCLose.Location = new System.Drawing.Point(1083, 0);
            this.iconCLose.Name = "iconCLose";
            this.iconCLose.Size = new System.Drawing.Size(32, 32);
            this.iconCLose.TabIndex = 0;
            this.iconCLose.TabStop = false;
            this.iconCLose.Click += new System.EventHandler(this.iconCLose_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.panelMenu.Controls.Add(this.btnMeeting);
            this.panelMenu.Controls.Add(this.panelSubMenu);
            this.panelMenu.Controls.Add(this.btnAdministration);
            this.panelMenu.Controls.Add(this.btnSettings);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 35);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(224, 665);
            this.panelMenu.TabIndex = 1;
            // 
            // btnMeeting
            // 
            this.btnMeeting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnMeeting.FlatAppearance.BorderSize = 0;
            this.btnMeeting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(48)))), ((int)(((byte)(200)))));
            this.btnMeeting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMeeting.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMeeting.ForeColor = System.Drawing.Color.White;
            this.btnMeeting.IconChar = FontAwesome.Sharp.IconChar.Play;
            this.btnMeeting.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(194)))), ((int)(((byte)(241)))));
            this.btnMeeting.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMeeting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMeeting.Location = new System.Drawing.Point(0, 46);
            this.btnMeeting.Name = "btnMeeting";
            this.btnMeeting.Size = new System.Drawing.Size(224, 40);
            this.btnMeeting.TabIndex = 3;
            this.btnMeeting.Text = "       Meeting";
            this.btnMeeting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMeeting.UseVisualStyleBackColor = false;
            this.btnMeeting.Click += new System.EventHandler(this.btnMeeting_Click);
            // 
            // panelSubMenu
            // 
            this.panelSubMenu.Controls.Add(this.btnUsers);
            this.panelSubMenu.Controls.Add(this.btnVacancy);
            this.panelSubMenu.Controls.Add(this.btnStages);
            this.panelSubMenu.Controls.Add(this.btnRequirements);
            this.panelSubMenu.Controls.Add(this.btnAnswers);
            this.panelSubMenu.Controls.Add(this.btnQuestions);
            this.panelSubMenu.Controls.Add(this.btnMeetings);
            this.panelSubMenu.Controls.Add(this.btnLog);
            this.panelSubMenu.Controls.Add(this.btnEnum);
            this.panelSubMenu.Controls.Add(this.btnCustomers);
            this.panelSubMenu.Controls.Add(this.btnFiles);
            this.panelSubMenu.Controls.Add(this.btnCandidates);
            this.panelSubMenu.Location = new System.Drawing.Point(46, 121);
            this.panelSubMenu.Name = "panelSubMenu";
            this.panelSubMenu.Size = new System.Drawing.Size(178, 544);
            this.panelSubMenu.TabIndex = 2;
            this.panelSubMenu.Visible = false;
            // 
            // btnUsers
            // 
            this.btnUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(48)))), ((int)(((byte)(200)))));
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUsers.ForeColor = System.Drawing.Color.White;
            this.btnUsers.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
            this.btnUsers.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(194)))), ((int)(((byte)(241)))));
            this.btnUsers.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.Location = new System.Drawing.Point(0, 501);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(180, 40);
            this.btnUsers.TabIndex = 14;
            this.btnUsers.Text = "        Users";
            this.btnUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // btnVacancy
            // 
            this.btnVacancy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnVacancy.FlatAppearance.BorderSize = 0;
            this.btnVacancy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(48)))), ((int)(((byte)(200)))));
            this.btnVacancy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVacancy.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnVacancy.ForeColor = System.Drawing.Color.White;
            this.btnVacancy.IconChar = FontAwesome.Sharp.IconChar.VoteYea;
            this.btnVacancy.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(194)))), ((int)(((byte)(241)))));
            this.btnVacancy.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVacancy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVacancy.Location = new System.Drawing.Point(0, 463);
            this.btnVacancy.Name = "btnVacancy";
            this.btnVacancy.Size = new System.Drawing.Size(180, 40);
            this.btnVacancy.TabIndex = 13;
            this.btnVacancy.Text = "        Vacancy";
            this.btnVacancy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVacancy.UseVisualStyleBackColor = false;
            this.btnVacancy.Click += new System.EventHandler(this.btnVacancy_Click);
            // 
            // btnStages
            // 
            this.btnStages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnStages.FlatAppearance.BorderSize = 0;
            this.btnStages.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(48)))), ((int)(((byte)(200)))));
            this.btnStages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStages.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStages.ForeColor = System.Drawing.Color.White;
            this.btnStages.IconChar = FontAwesome.Sharp.IconChar.FaceSmile;
            this.btnStages.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(194)))), ((int)(((byte)(241)))));
            this.btnStages.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStages.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStages.Location = new System.Drawing.Point(0, 417);
            this.btnStages.Name = "btnStages";
            this.btnStages.Size = new System.Drawing.Size(180, 40);
            this.btnStages.TabIndex = 12;
            this.btnStages.Text = "        Stages";
            this.btnStages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStages.UseVisualStyleBackColor = false;
            this.btnStages.Click += new System.EventHandler(this.btnStages_Click);
            // 
            // btnRequirements
            // 
            this.btnRequirements.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnRequirements.FlatAppearance.BorderSize = 0;
            this.btnRequirements.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(48)))), ((int)(((byte)(200)))));
            this.btnRequirements.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequirements.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRequirements.ForeColor = System.Drawing.Color.White;
            this.btnRequirements.IconChar = FontAwesome.Sharp.IconChar.Tasks;
            this.btnRequirements.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(194)))), ((int)(((byte)(241)))));
            this.btnRequirements.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRequirements.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRequirements.Location = new System.Drawing.Point(0, 371);
            this.btnRequirements.Name = "btnRequirements";
            this.btnRequirements.Size = new System.Drawing.Size(180, 40);
            this.btnRequirements.TabIndex = 11;
            this.btnRequirements.Text = "        Requirements";
            this.btnRequirements.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRequirements.UseVisualStyleBackColor = false;
            this.btnRequirements.Click += new System.EventHandler(this.btnRequirements_Click);
            // 
            // btnAnswers
            // 
            this.btnAnswers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnAnswers.FlatAppearance.BorderSize = 0;
            this.btnAnswers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(48)))), ((int)(((byte)(200)))));
            this.btnAnswers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnswers.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAnswers.ForeColor = System.Drawing.Color.White;
            this.btnAnswers.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnAnswers.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(194)))), ((int)(((byte)(241)))));
            this.btnAnswers.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAnswers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnswers.Location = new System.Drawing.Point(0, 325);
            this.btnAnswers.Name = "btnAnswers";
            this.btnAnswers.Size = new System.Drawing.Size(180, 40);
            this.btnAnswers.TabIndex = 10;
            this.btnAnswers.Text = "        Answers";
            this.btnAnswers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnswers.UseVisualStyleBackColor = false;
            this.btnAnswers.Click += new System.EventHandler(this.btnAnswers_Click);
            // 
            // btnQuestions
            // 
            this.btnQuestions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnQuestions.FlatAppearance.BorderSize = 0;
            this.btnQuestions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(48)))), ((int)(((byte)(200)))));
            this.btnQuestions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuestions.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnQuestions.ForeColor = System.Drawing.Color.White;
            this.btnQuestions.IconChar = FontAwesome.Sharp.IconChar.Question;
            this.btnQuestions.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(194)))), ((int)(((byte)(241)))));
            this.btnQuestions.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQuestions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuestions.Location = new System.Drawing.Point(0, 279);
            this.btnQuestions.Name = "btnQuestions";
            this.btnQuestions.Size = new System.Drawing.Size(180, 40);
            this.btnQuestions.TabIndex = 9;
            this.btnQuestions.Text = "        Questions";
            this.btnQuestions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuestions.UseVisualStyleBackColor = false;
            this.btnQuestions.Click += new System.EventHandler(this.btnQuestions_Click);
            // 
            // btnMeetings
            // 
            this.btnMeetings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnMeetings.FlatAppearance.BorderSize = 0;
            this.btnMeetings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(48)))), ((int)(((byte)(200)))));
            this.btnMeetings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMeetings.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMeetings.ForeColor = System.Drawing.Color.White;
            this.btnMeetings.IconChar = FontAwesome.Sharp.IconChar.Clapperboard;
            this.btnMeetings.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(194)))), ((int)(((byte)(241)))));
            this.btnMeetings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMeetings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMeetings.Location = new System.Drawing.Point(0, 233);
            this.btnMeetings.Name = "btnMeetings";
            this.btnMeetings.Size = new System.Drawing.Size(180, 40);
            this.btnMeetings.TabIndex = 8;
            this.btnMeetings.Text = "        Meetings";
            this.btnMeetings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMeetings.UseVisualStyleBackColor = false;
            this.btnMeetings.Click += new System.EventHandler(this.btnMeetings_Click);
            // 
            // btnLog
            // 
            this.btnLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnLog.FlatAppearance.BorderSize = 0;
            this.btnLog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(48)))), ((int)(((byte)(200)))));
            this.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLog.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLog.ForeColor = System.Drawing.Color.White;
            this.btnLog.IconChar = FontAwesome.Sharp.IconChar.ExclamationTriangle;
            this.btnLog.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(194)))), ((int)(((byte)(241)))));
            this.btnLog.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLog.Location = new System.Drawing.Point(0, 187);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(180, 40);
            this.btnLog.TabIndex = 7;
            this.btnLog.Text = "        Log";
            this.btnLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLog.UseVisualStyleBackColor = false;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnEnum
            // 
            this.btnEnum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnEnum.FlatAppearance.BorderSize = 0;
            this.btnEnum.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(48)))), ((int)(((byte)(200)))));
            this.btnEnum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnum.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEnum.ForeColor = System.Drawing.Color.White;
            this.btnEnum.IconChar = FontAwesome.Sharp.IconChar.List12;
            this.btnEnum.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(194)))), ((int)(((byte)(241)))));
            this.btnEnum.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEnum.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnum.Location = new System.Drawing.Point(0, 141);
            this.btnEnum.Name = "btnEnum";
            this.btnEnum.Size = new System.Drawing.Size(180, 40);
            this.btnEnum.TabIndex = 6;
            this.btnEnum.Text = "        EnumType";
            this.btnEnum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnum.UseVisualStyleBackColor = false;
            this.btnEnum.Click += new System.EventHandler(this.btnEnum_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnCustomers.FlatAppearance.BorderSize = 0;
            this.btnCustomers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(48)))), ((int)(((byte)(200)))));
            this.btnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomers.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCustomers.ForeColor = System.Drawing.Color.White;
            this.btnCustomers.IconChar = FontAwesome.Sharp.IconChar.MoneyCheckAlt;
            this.btnCustomers.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(194)))), ((int)(((byte)(241)))));
            this.btnCustomers.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCustomers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomers.Location = new System.Drawing.Point(0, 95);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(180, 40);
            this.btnCustomers.TabIndex = 5;
            this.btnCustomers.Text = "        Customers";
            this.btnCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomers.UseVisualStyleBackColor = false;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnFiles
            // 
            this.btnFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnFiles.FlatAppearance.BorderSize = 0;
            this.btnFiles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(48)))), ((int)(((byte)(200)))));
            this.btnFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiles.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFiles.ForeColor = System.Drawing.Color.White;
            this.btnFiles.IconChar = FontAwesome.Sharp.IconChar.File;
            this.btnFiles.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(194)))), ((int)(((byte)(241)))));
            this.btnFiles.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFiles.IconSize = 40;
            this.btnFiles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiles.Location = new System.Drawing.Point(0, 49);
            this.btnFiles.Name = "btnFiles";
            this.btnFiles.Size = new System.Drawing.Size(180, 40);
            this.btnFiles.TabIndex = 4;
            this.btnFiles.Text = "        Execute";
            this.btnFiles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiles.UseVisualStyleBackColor = false;
            this.btnFiles.Click += new System.EventHandler(this.btnFiles_Click);
            // 
            // btnCandidates
            // 
            this.btnCandidates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnCandidates.FlatAppearance.BorderSize = 0;
            this.btnCandidates.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(48)))), ((int)(((byte)(200)))));
            this.btnCandidates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCandidates.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCandidates.ForeColor = System.Drawing.Color.White;
            this.btnCandidates.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.btnCandidates.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(194)))), ((int)(((byte)(241)))));
            this.btnCandidates.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCandidates.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCandidates.Location = new System.Drawing.Point(0, 3);
            this.btnCandidates.Name = "btnCandidates";
            this.btnCandidates.Size = new System.Drawing.Size(180, 40);
            this.btnCandidates.TabIndex = 3;
            this.btnCandidates.Text = "        Candidates";
            this.btnCandidates.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCandidates.UseVisualStyleBackColor = false;
            this.btnCandidates.Click += new System.EventHandler(this.btnCandidates_Click);
            // 
            // btnAdministration
            // 
            this.btnAdministration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnAdministration.FlatAppearance.BorderSize = 0;
            this.btnAdministration.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(48)))), ((int)(((byte)(200)))));
            this.btnAdministration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministration.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAdministration.ForeColor = System.Drawing.Color.White;
            this.btnAdministration.IconChar = FontAwesome.Sharp.IconChar.CaretDown;
            this.btnAdministration.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(194)))), ((int)(((byte)(241)))));
            this.btnAdministration.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAdministration.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdministration.Location = new System.Drawing.Point(0, 84);
            this.btnAdministration.Name = "btnAdministration";
            this.btnAdministration.Size = new System.Drawing.Size(224, 40);
            this.btnAdministration.TabIndex = 1;
            this.btnAdministration.Text = "       Menu";
            this.btnAdministration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdministration.UseVisualStyleBackColor = false;
            this.btnAdministration.Click += new System.EventHandler(this.btnAdministration_Click);
            this.btnAdministration.MouseHover += new System.EventHandler(this.btnAdministration_MouseHover);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(48)))), ((int)(((byte)(200)))));
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.IconChar = FontAwesome.Sharp.IconChar.Gears;
            this.btnSettings.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(194)))), ((int)(((byte)(241)))));
            this.btnSettings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(0, 0);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(224, 40);
            this.btnSettings.TabIndex = 0;
            this.btnSettings.Text = "       Settings";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.AutoSize = true;
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(254)))), ((int)(((byte)(252)))));
            this.panelContent.Controls.Add(this.lblLoading);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(224, 35);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(891, 665);
            this.panelContent.TabIndex = 2;
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLoading.Location = new System.Drawing.Point(0, 0);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(104, 29);
            this.lblLoading.TabIndex = 0;
            this.lblLoading.Text = "Loading...";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 700);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainView";
            this.Text = "MainView";
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconMinimice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconMaximice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconCLose)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.panelSubMenu.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panelTop;
        private Panel panelMenu;
        private Panel panelContent;
        private FontAwesome.Sharp.IconPictureBox iconCLose;
        private FontAwesome.Sharp.IconPictureBox iconMinimice;
        private FontAwesome.Sharp.IconPictureBox iconMaximice;
        private FontAwesome.Sharp.IconButton btnSettings;
        private FontAwesome.Sharp.IconButton btnAdministration;
        private FontAwesome.Sharp.IconButton btnMeeting;
        private Panel panelSubMenu;
        private FontAwesome.Sharp.IconButton btnMeetings;
        private FontAwesome.Sharp.IconButton btnLog;
        private FontAwesome.Sharp.IconButton btnEnum;
        private FontAwesome.Sharp.IconButton btnCustomers;
        private FontAwesome.Sharp.IconButton btnFiles;
        private FontAwesome.Sharp.IconButton btnCandidates;
        private FontAwesome.Sharp.IconButton btnStages;
        private FontAwesome.Sharp.IconButton btnRequirements;
        private FontAwesome.Sharp.IconButton btnAnswers;
        private FontAwesome.Sharp.IconButton btnQuestions;
        private FontAwesome.Sharp.IconButton btnVacancy;
        private Label lblLoading;
        private FontAwesome.Sharp.IconButton btnUsers;
    }
}
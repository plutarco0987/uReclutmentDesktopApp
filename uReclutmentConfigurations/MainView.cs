using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using static System.Windows.Forms.DataFormats;
using uReclutmentConfigurations.views;
using FontAwesome.Sharp;
using Entities.DataContext;
using System.Windows.Media;

namespace uReclutmentConfigurations
{
    public partial class MainView : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr intPtr, int wMsg, int wParam, int lParam);

        public MainView()
        {
            Program.CurrentMenu = "MainView";
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            lblLoading.Visible = false;
        }

        #region methodsOfMainMenu

        private void ClearDialog()
        {
            this.panelContent.Controls.Clear();
        }

        private void iconCLose_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Application.Exit();
        }

        private void iconMaximice_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void iconMinimice_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconMaximice_MouseHover(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                iconMaximice.IconChar = FontAwesome.Sharp.IconChar.Expand;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                iconMaximice.IconChar = FontAwesome.Sharp.IconChar.Compress;
            }
        }

        private void iconMaximice_MouseLeave(object sender, EventArgs e)
        {
            iconMaximice.IconChar = FontAwesome.Sharp.IconChar.Square;
        }

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnAdministration_MouseHover(object sender, EventArgs e)
        {

        }
        private void btnAdministration_Click(object sender, EventArgs e)
        {
            if (btnAdministration.IconChar == FontAwesome.Sharp.IconChar.CaretDown)
            {
                //display submenu
                btnAdministration.IconChar = FontAwesome.Sharp.IconChar.CaretUp;
                panelSubMenu.Visible = true;
            }
            else
            {
                btnAdministration.IconChar = FontAwesome.Sharp.IconChar.CaretDown;
                panelSubMenu.Visible = false;
            }


        }
        private void ThreadSafe(Action callback, Form form)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.RunWorkerCompleted += (obj, e) =>
            {
                if (form.InvokeRequired)
                    form.Invoke(callback);
                else
                    callback();
            };
            worker.RunWorkerAsync();
        }



        private void panelTop_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
        #endregion

        #region btnFunctions

        private async void btnSettings_Click(object sender, EventArgs e)
        {
            ClearDialog();
            lblLoading.Visible = true;
            views.Settings settings = await ShowSettings();
            if (settings != null)
            {
                settings.Show();
                this.panelContent.Controls.Add(settings);
            }
            lblLoading.Visible = false;
        }

        private async void btnStages_Click(object sender, EventArgs e)
        {
            ClearDialog();
            lblLoading.Visible = true;
            views.Stages stages = await ShowStages();
            if (stages != null)
            {
                stages.Show();
                stages.SetColor();
                this.panelContent.Controls.Add(stages);
            }
            lblLoading.Visible = false;
        }


        private async void btnLog_Click(object sender, EventArgs e)
        {
            ClearDialog();
            lblLoading.Visible = true;
            views.Log log = await ShowLog();
            if (log != null)
            {
                log.Show();
                this.panelContent.Controls.Add(log);
            }
            lblLoading.Visible = false;
        }

        private async void iconButton1_Click(object sender, EventArgs e)
        {
            ClearDialog();
            lblLoading.Visible = true;
            views.User user = await ShowUser();
            if (user != null)
            {
                user.Show();
                this.panelContent.Controls.Add(user);
            }
            lblLoading.Visible = false;
        }


        private async void btnEnum_Click(object sender, EventArgs e)
        {
            ClearDialog();
            lblLoading.Visible = true;
            views.EnumType enumType = await ShowEnumType();
            if (enumType != null)
            {
                enumType.Show();
                this.panelContent.Controls.Add(enumType);
            }
            lblLoading.Visible = false;
        }

        private async void btnCustomers_Click(object sender, EventArgs e)
        {
            ClearDialog();
            lblLoading.Visible = true;
            views.Customers customers = await ShowCustomers();
            if (customers != null)
            {
                customers.Show();
                this.panelContent.Controls.Add(customers);
            }
            lblLoading.Visible = false;
        }

        private async void btnVacancy_Click(object sender, EventArgs e)
        {
            ClearDialog();
            lblLoading.Visible = true;
            views.Vacancy customers = await ShowVacancy();
            if (customers != null)
            {
                customers.Show();
                this.panelContent.Controls.Add(customers);
            }
            lblLoading.Visible = false;
        }

        private async void btnRequirements_Click(object sender, EventArgs e)
        {
            ClearDialog();
            lblLoading.Visible = true;
            views.Requirements requirements = await ShowRequirements();
            if (requirements != null)
            {
                requirements.Show();
                this.panelContent.Controls.Add(requirements);
            }
            lblLoading.Visible = false;
        }

        private async void btnCandidates_Click(object sender, EventArgs e)
        {
            ClearDialog();
            lblLoading.Visible = true;
            views.Candidates candidates = await ShowCandidates();
            if (candidates != null)
            {
                candidates.Show();
                this.panelContent.Controls.Add(candidates);
            }
            lblLoading.Visible = false;
        }

        private async void btnQuestions_Click(object sender, EventArgs e)
        {
            ClearDialog();
            lblLoading.Visible = true;
            views.Questions questions = await ShowQuestions();
            if (questions != null)
            {
                questions.Show();
                this.panelContent.Controls.Add(questions);
            }
            lblLoading.Visible = false;
        }

        private async void btnAnswers_Click(object sender, EventArgs e)
        {
            ClearDialog();
            lblLoading.Visible = true;
            views.QuestionDetails answers = await ShowQuestionDetails();
            if (answers != null)
            {
                answers.Show();
                this.panelContent.Controls.Add(answers);
            }
            lblLoading.Visible = false;
        }

        private async void btnMeetings_Click(object sender, EventArgs e)
        {
            ClearDialog();
            lblLoading.Visible = true;
            views.Meetings meetings = await ShowMeetings();
            if (meetings != null)
            {
                meetings.Show();
                this.panelContent.Controls.Add(meetings);
            }
            lblLoading.Visible = false;
        }

        private async void btnMeeting_Click(object sender, EventArgs e)
        {
            ClearDialog();
            lblLoading.Visible = true;
            Meeting meetings = await ShowMeeting();
            if (meetings != null)
            {
                meetings.Show();
                this.panelContent.Controls.Add(meetings);
            }
            lblLoading.Visible = false;
        }


        private async void btnFiles_Click(object sender, EventArgs e)
        {
            ClearDialog();
            lblLoading.Visible = true;
            Execute execute = await ShowExecute();
            if (execute != null)
            {
                execute.Show();
                this.panelContent.Controls.Add(execute);
            }
            lblLoading.Visible = false;
        }
        #endregion

        #region ShowsPages
        private async Task<views.Settings> ShowSettings()
        {
            views.Settings myForm = new views.Settings();
            await myForm.InitialTable();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            return myForm;
        }


        private async Task<views.Stages> ShowStages()
        {
            views.Stages myForm = new views.Stages();
            await myForm.InitialTable();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            return myForm;
        }

        private async Task<views.Log> ShowLog()
        {
            views.Log myForm = new views.Log();
            await myForm.InitialTable();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            return myForm;
        }

        private async Task<views.User> ShowUser()
        {
            views.User myForm = new views.User();
            await myForm.InitialTable();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            return myForm;
        }

        private async Task<views.EnumType> ShowEnumType()
        {
            views.EnumType myForm = new views.EnumType();
            await myForm.InitialTable();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            return myForm;
        }


        private async Task<views.Customers> ShowCustomers()
        {
            views.Customers myForm = new views.Customers();
            await myForm.InitialTable();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            return myForm;
        }

        private async Task<views.Vacancy> ShowVacancy()
        {
            views.Vacancy myForm = new views.Vacancy();
            await myForm.InitialVacancys();
            await myForm.InitialTable();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            return myForm;
        }

        private async Task<views.Requirements> ShowRequirements()
        {
            views.Requirements myForm = new views.Requirements();
            await myForm.InitialVacancys();
            await myForm.InitialTable();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            return myForm;
        }

        private async Task<views.Candidates> ShowCandidates()
        {
            views.Candidates myForm = new views.Candidates();
            await myForm.InitialStages();
            await myForm.InitialVacancys();
            await myForm.InitialTable();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            return myForm;
        }

        private async Task<views.Questions> ShowQuestions()
        {
            views.Questions myForm = new views.Questions();
            await myForm.InitialEnums();
            await myForm.InitialVacancys();
            await myForm.InitialTable();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            return myForm;
        }

        private async Task<views.QuestionDetails> ShowQuestionDetails()
        {
            views.QuestionDetails myForm = new views.QuestionDetails();
            await myForm.InitialQuestions();
            await myForm.InitialCandidates();
            await myForm.InitialComments();
            await myForm.InitialTable();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            return myForm;
        }

        private async Task<views.Meetings> ShowMeetings()
        {
            views.Meetings myForm = new views.Meetings();
            await myForm.InitialCandidates();
            await myForm.InitialTable();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            return myForm;
        }
        private async Task<Meeting> ShowMeeting()
        {
            Meeting myForm = new Meeting();
            await myForm.InitialCandidates();
            await myForm.InitialVacancys();
            await myForm.InitialStages();
            myForm.Initial();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            return myForm;
        }


        private async Task<Execute> ShowExecute()
        {
            Execute myForm = new Execute();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            await myForm.InitialVacancys();
            myForm.Initial();
            return myForm;
        }    

        #endregion


    }
}


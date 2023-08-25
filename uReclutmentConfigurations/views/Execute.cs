using Aspose.Cells;
using Entities;
using Entities.DataContext;
using Entities.Formats;
using Syncfusion.Compression.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using uReclutmentConfigurations.Control;
using Zuby.ADGV;

namespace uReclutmentConfigurations.views
{
    public partial class Execute : Form
    {
        private List<int> idsExist = new List<int>();
        private Dictionary<int, string> dictionaryVacancy = new Dictionary<int, string>();
        private Dictionary<int, Entities.DataContext.VacancyFormat> dictionaryVacancyAll = new Dictionary<int, Entities.DataContext.VacancyFormat>();
        public Execute()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Files",

                CheckFileExists = true,
                CheckPathExists = true,

                //DefaultExt = "txt",
                //Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label2.Text = openFileDialog1.FileName;
            }
        }

        private void btnMigration_Click(object sender, EventArgs e)
        {
            if (cmbMigration.Text != "")
            {
                switch (cmbMigration.Text)
                {
                    case "Candidates":
                        if (MigrationCandidates(label2.Text).Result)
                        {
                            MessageBox.Show("Candidates added");
                        }
                        else
                        {
                            MessageBox.Show("Format Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "Customers":
                        if (MigrationCustomers(label2.Text).Result)
                        {
                            MessageBox.Show("Customers added");
                        }
                        else
                        {
                            MessageBox.Show("Format Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "Vacancys":
                        if (MigrationVacancy(label2.Text).Result)
                        {
                            MessageBox.Show("Vacancys added");
                        }
                        else
                        {
                            MessageBox.Show("Format Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
            }
        }
        private async Task<bool> MigrationCandidates(string path)
        {
            if (File.Exists(path))
            {
                List<CandidatesFormat> candidates = new List<CandidatesFormat>();
                List<byte[]> files = new List<byte[]>();
                List<string> paths = new List<string>();
                Workbook wb = new Workbook(path);

                WorksheetCollection collection = wb.Worksheets;

                for (int worksheetIndex = 0; worksheetIndex < collection.Count; worksheetIndex++)
                {
                    Worksheet worksheet = collection[worksheetIndex];
                    int rows = worksheet.Cells.MaxDataRow + 1;
                    int cols = worksheet.Cells.MaxDataColumn + 1;
                    //we won't read the first row
                    for (int i = 0; i < rows; i++)
                    {
                        if (i == 0)
                            continue;

                        string pathCV = string.Empty;
                        CandidatesFormat format = new CandidatesFormat();
                        DateTime now = DateTime.Now;
                        format.DateCreated = now;
                        format.DateModified = now;
                        format.NameCreated = Program.LoginUser;
                        format.NameModified = Program.LoginUser;
                        for (int j = 0; j < cols; j++)
                        {
                            switch (j)
                            {
                                case 0:
                                    format.Name = worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "";
                                    break;
                                case 1:
                                    format.Notes = worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "";
                                    break;
                                case 2:
                                    format.Tags = worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "";
                                    break;
                                case 3:
                                    format.RecluterName = worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "";
                                    break;
                                case 4:
                                    pathCV = worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "";
                                    if (pathCV == "")
                                    {
                                        files.Add(null);
                                    }
                                    else
                                    {
                                        if (File.Exists(pathCV))
                                        {
                                            byte[] content = null;
                                            using (FileStream fs = new FileStream(pathCV, FileMode.Open, FileAccess.Read, FileShare.Read))
                                            {
                                                content = new byte[fs.Length];
                                                await fs.ReadAsync(content, 0, content.Length);
                                                files.Add(content);
                                            }
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }

                                    break;
                                case 5:
                                    format.Age = int.Parse(worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "0");
                                    break;
                                case 6:
                                    format.City = worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "";
                                    break;
                                case 7:
                                    format.Country = worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "";
                                    break;
                                case 8:
                                    format.VacancyId = int.Parse(worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "0");
                                    break;
                                case 9:
                                    format.StagesId = int.Parse(worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "0");
                                    break;
                                case 10:
                                    format.ContactSource = worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "";
                                    break;
                                case 11:
                                    format.RejectionEmcor = worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "";
                                    break;
                                case 12:
                                    format.RejectionCandidate = worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "";
                                    break;
                                case 13:
                                    format.Active = bool.Parse(worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "false");
                                    break;
                                case 14:
                                    format.Address = worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "";
                                    break;
                            }
                        }
                        candidates.Add(format);
                        paths.Add(pathCV);
                    }
                }
                string result = "";
                //sent post execute
                Entities.DataContext.MigrationCandidates migrationCandidates = new MigrationCandidates(candidates, files);

                string pathMigration = "";
                Program.Settings.TryGetValue("FilePathLocation", out pathMigration);
                migrationCandidates.Path = pathMigration;
                migrationCandidates.NameFile = paths;
                result = await ApiControl<Entities.DataContext.MigrationCandidates>.Post(Program.BaseUrl + "Execute/MigrationCandidates", migrationCandidates);
                if (result == "" || result == "false")
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task<bool> MigrationCustomers(string path)
        {
            if (File.Exists(path))
            {
                List<Entities.DataContext.Customers> customers = new List<Entities.DataContext.Customers>();

                Workbook wb = new Workbook(path);

                WorksheetCollection collection = wb.Worksheets;

                for (int worksheetIndex = 0; worksheetIndex < collection.Count; worksheetIndex++)
                {
                    Worksheet worksheet = collection[worksheetIndex];
                    int rows = worksheet.Cells.MaxDataRow + 1;
                    int cols = worksheet.Cells.MaxDataColumn + 1;
                    //we won't read the first row
                    for (int i = 0; i < rows; i++)
                    {
                        if (i == 0)
                            continue;


                        Entities.DataContext.Customers format = new Entities.DataContext.Customers();
                        DateTime now = DateTime.Now;
                        format.DateCreated = now;
                        format.DateModified = now;
                        format.NameCreated = Program.LoginUser;
                        format.NameModified = Program.LoginUser;
                        for (int j = 0; j < cols; j++)
                        {
                            switch (j)
                            {
                                case 0:
                                    format.Name = worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "";
                                    break;
                                case 1:
                                    format.Address = worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "";
                                    break;
                                case 2:
                                    format.City = worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "";
                                    break;
                                case 3:
                                    format.Country = worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "";
                                    break;

                                case 4:
                                    format.Active = bool.Parse(worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "false");
                                    break;

                            }
                        }
                        customers.Add(format);
                    }
                }
                string result = "";


                result = await ApiControl<List<Entities.DataContext.Customers>>.Post(Program.BaseUrl + "Execute/AddCustomers", customers);
                if (result == "" || result == "false")
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task<bool> MigrationVacancy(string path)
        {
            if (File.Exists(path))
            {
                List<Entities.DataContext.VacancyFormat> vacancys = new List<Entities.DataContext.VacancyFormat>();

                Workbook wb = new Workbook(path);

                WorksheetCollection collection = wb.Worksheets;

                for (int worksheetIndex = 0; worksheetIndex < collection.Count; worksheetIndex++)
                {
                    Worksheet worksheet = collection[worksheetIndex];
                    int rows = worksheet.Cells.MaxDataRow + 1;
                    int cols = worksheet.Cells.MaxDataColumn + 1;
                    //we won't read the first row
                    for (int i = 0; i < rows; i++)
                    {
                        if (i == 0)
                            continue;


                        Entities.DataContext.VacancyFormat format = new Entities.DataContext.VacancyFormat();
                        DateTime now = DateTime.Now;
                        format.DateCreated = now;
                        format.DateModified = now;
                        format.NameCreated = Program.LoginUser;
                        format.NameModified = Program.LoginUser;
                        format.Questions = new List<string>();
                        format.QuestionsString = "";
                        format.VacancyId = 0;
                        format.CustomerName = "No Aplica";
                        for (int j = 0; j < cols; j++)
                        {
                            switch (j)
                            {
                                case 0:
                                    format.Name = worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "";
                                    break;
                                case 1:
                                    format.Description = worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "";
                                    break;
                                case 2:
                                    format.NamePosition = worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "";
                                    break;
                                case 3:
                                    format.Responsabilitys = worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "";
                                    break;

                                case 4:
                                    format.Active = bool.Parse(worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "false");
                                    break;
                                case 5:
                                    format.CustomersId = int.Parse(worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "0");
                                    break;
                                case 6:
                                    format.ContractType = worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "";
                                    break;
                                case 7:
                                    format.Status = worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "";
                                    break;
                                case 8:
                                    format.Departament = worksheet.Cells[i, j].Value != null ? worksheet.Cells[i, j].Value.ToString() : "";
                                    break;

                            }
                        }
                        vacancys.Add(format);
                    }
                }
                string result = "";

                MigrationVacancy mv = new MigrationVacancy(vacancys);

                result = await ApiControl<MigrationVacancy>.Post(Program.BaseUrl + "Execute/MigrationVacancy", mv);

                if (result == "" || result == "false")
                {
                    return false;
                }

                return true;
            }
            else
            {
                return false;
            }
        }


        private List<int> GetListIds(int cantidad)
        {
            Random rnd = new Random();
            List<int> ids = new List<int>();
            for (int i = 0; i < cantidad; i++)
            {
                int x = rnd.Next();
                if (!idsExist.Contains(x))
                {
                    idsExist.Add(x);
                    ids.Add(x);
                }
                else
                {
                    x = rnd.Next();
                    if (!idsExist.Contains(x))
                    {
                        idsExist.Add(x);
                    }
                    else
                    {
                        x = rnd.Next();
                        if (!idsExist.Contains(x))
                        {
                            idsExist.Add(x);
                        }
                    }
                }
            }
            return ids;
        }

        private async Task<string> GenerateVacancysAsync()
        {
            string error = "";

            //point 2
            List<string> vacancys = new List<string>();
            string formatVacancys = "";
            Program.Settings.TryGetValue("VacancyFormat", out formatVacancys);
            if (formatVacancys == "" || formatVacancys == null)
                return "No setting VacancyFormat";
            List<Entities.DataContext.VacancyFormat> dataGet = await ApiControl<Entities.DataContext.VacancyFormat>.GetDictionary(Program.BaseUrl + "Vacancy/GetAllVacancy");
            if (dataGet != null)
            {
                if (dataGet.Count > 0)
                {
                    dataGet = dataGet.Where(x => x.Active).ToList();
                    if (dataGet.Count == 0)
                    {
                        return "NO Vacancys Active";
                    }
                }
                else
                {
                    return "NO Vacancys";
                }
            }
            else
            {
                return "NO Vacancys";
            }
            foreach (var item in dataGet)
            {
                List<int> idsVacancys = GetListIds(4);
                string value = string.Format(formatVacancys, idsVacancys[0], idsVacancys[1], idsVacancys[2], idsVacancys[3], item.Name);
                vacancys.Add(value);
            }

            //point 1 
            string titleVacancy = "";
            Program.Settings.TryGetValue("TitleVacancy", out titleVacancy);
            if (titleVacancy == "")
                return "No setting TitleVacancy";
            List<int> idsVacancysTitle = GetListIds(1);
            titleVacancy = string.Format(titleVacancy, idsVacancysTitle.First());


            //point 0
            string everythingvacancys = titleVacancy + String.Join("", vacancys);

            string general = "";
            Program.Settings.TryGetValue("GeneralFormatVacancys", out general);
            if (general == "")
                return "No setting GeneralFormatVacancys";

            List<int> idsGeneral = GetListIds(3);
            general = string.Format(general, idsGeneral[0], idsGeneral[1], idsGeneral[2], everythingvacancys);

            txtVacancy.Text = HttpUtility.HtmlDecode(general);

            return error;
        }

        public void Initial()
        {
            InitialComboBoxes(cmbVacancys, dictionaryVacancy);
        }
        private void InitialComboBoxes(ComboBox item, Dictionary<int, string> dictionary)
        {
            foreach (KeyValuePair<int, string> entry in dictionary)
            {
                ComboboxItem comboboxItem = new ComboboxItem();
                comboboxItem.Value = entry.Key;
                comboboxItem.Text = entry.Key + " - " + entry.Value;
                item.Items.Add(comboboxItem);
            }
        }

        public async Task<bool> InitialVacancys()
        {
            List<Entities.DataContext.VacancyFormat> dataGet = await ApiControl<Entities.DataContext.VacancyFormat>.GetDictionary(Program.BaseUrl + "Vacancy/GetAllVacancy");
            dataGet = dataGet.FindAll(x => x.Active);
            dictionaryVacancy = dataGet.ToDictionary(keySelector: x => x.VacancyId, elementSelector: x => x.Name);
            dictionaryVacancyAll = dataGet.ToDictionary(keySelector: x => x.VacancyId, elementSelector: x => x);
            return true;
        }

        private async Task<string> GenerateDetail(VacancyFormat vacancy, List<Entities.DataContext.Requirements> requirements, List<Entities.Formats.QuestionsFormat> questions, List<Entities.DataContext.EnumType> enums)
        {

            string error = "";

            string part1 = "", part2 = "", part3 = "", part4 = "";

            //part 1
            Program.Settings.TryGetValue("VacancyFormatPart1", out part1);
            part1 = String.Format(part1, vacancy.Name, vacancy.NamePosition);

            //part 2
            string TitleJobDescription = "", TitleBenefits = "", TitleRequirements = "", VacancyFormatPart2Benefits = "", VacancyFormatPart2Requirements = "";
            string listBenefits = "", listRequirements = "";

            Program.Settings.TryGetValue("VacancyFormatPart2", out part2);
            Program.Settings.TryGetValue("TitleJobDescription", out TitleJobDescription);
            Program.Settings.TryGetValue("TitleBenefits", out TitleBenefits);
            Program.Settings.TryGetValue("TitleRequirements", out TitleRequirements);
            Program.Settings.TryGetValue("VacancyFormatPart2Benefits", out VacancyFormatPart2Benefits);
            Program.Settings.TryGetValue("VacancyFormatPart2Requirements", out VacancyFormatPart2Requirements);

            if (part2 == "" || part2 == null || TitleJobDescription == "" || TitleJobDescription == null || TitleBenefits == "" || TitleBenefits == null || TitleRequirements == "" || TitleRequirements == null || VacancyFormatPart2Benefits == "" || VacancyFormatPart2Benefits == null || VacancyFormatPart2Requirements == "" || VacancyFormatPart2Requirements == null)
                return "Please check the settings";

            foreach (var item in requirements)
            {
                string name = item.Name;
                if (item.Required)
                    name = "*" + name;

                if (item.Benefits)
                    listBenefits += String.Format(VacancyFormatPart2Benefits, name);
                else
                    listRequirements += String.Format(VacancyFormatPart2Requirements, name);
            }
            part2 = part2.Replace("{0}", TitleJobDescription);
            part2 = part2.Replace("{1}", vacancy.Description);
            part2 = part2.Replace("{2}", TitleBenefits);
            part2 = part2.Replace("{3}", listBenefits);
            part2 = part2.Replace("{4}", TitleRequirements);
            part2 = part2.Replace("{5}", listRequirements);
            //we can't use string.format because one div have {
            //part2 = String.Format(part2, TitleJobDescription, vacancy.Description.ToString(), TitleBenefits, listBenefits, TitleRequirements, listRequirements);

            //part 3
            string title = "";
            Program.Settings.TryGetValue("VacancyFormatPart3", out part3);
            Program.Settings.TryGetValue("TittleActivities", out title);

            part3 = String.Format(part3, title, vacancy.Responsabilitys);

            //part 4
            string TitleApply = "", LabelUpload = "", LabelUploadFile = "", EmailSubject = "", MessageSucess = "", MessageError = "", VacancyFormatPart4Questions = "";
            Program.Settings.TryGetValue("VacancyFormatPart4", out part4);

            Program.Settings.TryGetValue("TitleApply", out TitleApply);
            Program.Settings.TryGetValue("LabelUpload", out LabelUpload);
            Program.Settings.TryGetValue("LabelUploadFile", out LabelUploadFile);
            Program.Settings.TryGetValue("EmailSubject", out EmailSubject);
            Program.Settings.TryGetValue("MessageSucess", out MessageSucess);
            Program.Settings.TryGetValue("MessageError", out MessageError);
            Program.Settings.TryGetValue("VacancyFormatPart4Questions", out VacancyFormatPart4Questions);

            if (TitleApply == "" || TitleApply == null || LabelUpload == "" || LabelUpload == null || LabelUploadFile == "" || LabelUploadFile == null || EmailSubject == "" || EmailSubject == null || MessageSucess == "" || MessageSucess == null || MessageError == "" || MessageError == null || VacancyFormatPart4Questions == "" || VacancyFormatPart4Questions == null)
                return "Please check the settings";

            string listQuestions = "";
            //questions of candidate
            int ii = 7;

            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].Active)
                {
                    List<int> ids = GetListIds(4);
                    string type = enums.Where(x => x.EnumTypeId == questions[i].EnumTypeId).First().Name;
                    listQuestions += string.Format(VacancyFormatPart4Questions, questions[i].Required ? "required" : "", ids[0], ids[1], ids[2], ids[3], type, questions[i].Question, "dmform-" + ii, "label-dmform-" + ii, questions[i].MaxLength, "");
                    ii++;
                }
            }
            //8 contacts            
            string contract = "", contractHTML = "";
            Program.Settings.TryGetValue("Contact", out contract);
            foreach (var item in contract.Split(","))
            {
                contractHTML += string.Format("<option value=\"{0}\">{0}</option>", item);
            }
            string Recruiter = "";
            string RecruiterHTML = "";
            Program.Settings.TryGetValue("Recruiter", out Recruiter);            
            foreach (var item in Recruiter.Split(","))
            {
                RecruiterHTML += string.Format("<option value=\"{0}\">{0}</option>", item);
            }


            part4 = String.Format(part4, TitleApply, LabelUpload, LabelUploadFile, listQuestions, EmailSubject, vacancy.Name, MessageSucess, MessageError, contractHTML, vacancy.VacancyId, RecruiterHTML);


            // stcript
            string Script = "", ScriptPath = "";
            Program.Settings.TryGetValue("Script", out Script);
            Program.Settings.TryGetValue("ScriptPath", out ScriptPath);
            Script = Script.Replace("{0}", ScriptPath);


            txtDetail.Text = HttpUtility.HtmlDecode(part1 + part2 + part3 + part4 + Script);

            return error;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (cmbVacancys.Text != "")
            {
                try
                {
                    string id = cmbVacancys.Text.Split("-").First();
                    VacancyFormat vacancy = new VacancyFormat();
                    dictionaryVacancyAll.TryGetValue(int.Parse(id), out vacancy);

                    List<Entities.DataContext.Requirements> requirements = await ApiControl<Entities.DataContext.Requirements>.GetDictionary(Program.BaseUrl + "Requirements/GetAllRequirementsByVacancy/" + vacancy.VacancyId);
                    List<Entities.Formats.QuestionsFormat> dataGetQuestions = await ApiControl<Entities.Formats.QuestionsFormat>.GetDictionary(Program.BaseUrl + "Questions/GetAllQuestionsByVacancy/" + vacancy.VacancyId);
                    dataGetQuestions = dataGetQuestions.OrderBy(x => x.QuestionsId).ToList();
                    List<Entities.DataContext.EnumType> dataGetEnum = await ApiControl<Entities.DataContext.EnumType>.GetDictionary(Program.BaseUrl + "EnumType/GetAllEnumType");

                    string value = await GenerateDetail(vacancy, requirements, dataGetQuestions, dataGetEnum);

                    if (value != "")
                        MessageBox.Show(value, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error!!! Please check everything settings", "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select one Vacancy", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }                      
        }

        private async void btnGenerateVacancys_Click(object sender, EventArgs e)
        {
            string result = await GenerateVacancysAsync();

            if (result != "")
                MessageBox.Show(result, "ERROR!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

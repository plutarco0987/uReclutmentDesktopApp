using Entities;
using System;
using System.Configuration;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using uReclutmentConfigurations.views;

namespace uReclutmentConfigurations
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //we require the settings of the database first
            Settings = new Dictionary<string, string>();
            BaseUrl = "https://localhost:8080/api/";           
            
            Application.Run(new LogIn());
        }

        public static Dictionary<string, string> Settings { get; set; }
        public static string BaseUrl { get; set; }
        public static string CurrentMenu { get; set; }
        public static string? LoginUser { get; set; }        
        private static Random random = new Random();
        public static string Encrypt(string textToEncrypt)
        {
            try
            {
                string ToReturn = "";
                string publickey = "12345678";
                string secretkey = "uReclutmentPassword";
                byte[] secretkeyByte = { };
                secretkeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    ToReturn = Convert.ToBase64String(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public static string Decrypt(string textToDecrypt)
        {
            try
            {                
                string ToReturn = "";
                string publickey = "12345678";
                string secretkey = "uReclutmentPassword";
                byte[] privatekeyByte = { };
                privatekeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = new byte[textToDecrypt.Replace(" ", "+").Length];
                inputbyteArray = Convert.FromBase64String(textToDecrypt.Replace(" ", "+"));
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    Encoding encoding = Encoding.UTF8;
                    ToReturn = encoding.GetString(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ae)
            {
                throw new Exception(ae.Message, ae.InnerException);
            }
        }
        public static string RandomString()
        {
            string value = "8", EmailChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            //Settings.TryGetValue("CountCharacterEmailReset", out value);
            //Settings.TryGetValue("EmailChars", out EmailChars);
            int length = int.Parse(value);

            string chars = EmailChars; 
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static void SendEmail(string Body, string emailTo)
        {
            string EmailFrom = "", EmailSubjectReset = "", EmailHost = "", SslEmail = "", EmailUseDefaultCredentials = "", PasswordEmail = "",port="";
            Settings.TryGetValue("EmailFrom", out EmailFrom);
            Settings.TryGetValue("EmailSubjectReset", out EmailSubjectReset);
            Settings.TryGetValue("EmailHost", out EmailHost);
            Settings.TryGetValue("SslEmail", out SslEmail);
            Settings.TryGetValue("EmailUseDefaultCredentials", out EmailUseDefaultCredentials);
            Settings.TryGetValue("PasswordEmail", out PasswordEmail);
            Settings.TryGetValue("Port", out port);
            MailMessage message = new MailMessage();
            message.From = new MailAddress(EmailFrom);
            message.To.Add(new MailAddress(emailTo));
            message.Subject = EmailSubjectReset;
            message.IsBodyHtml = true;
            message.Body = Body;

            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = bool.Parse(SslEmail);
                smtpClient.UseDefaultCredentials = bool.Parse(EmailUseDefaultCredentials);
                smtpClient.Credentials = new NetworkCredential(EmailFrom, PasswordEmail);
                smtpClient.Host = EmailHost;
                smtpClient.Port = int.Parse(port);
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtpClient.Host = "smtp.gmail.com";                               
                //smtpClient.EnableSsl = true;                
                //smtpClient.UseDefaultCredentials = false;
                //smtpClient.Credentials = new NetworkCredential("lucerormzruiz.13@gamil.com", "ogzn-jrbi-jiyc-wjfo");
                //smtpClient.Port = 587;                
                //smtpClient.Send(message);
            }                       
        }

        public static DataTable GetDataGridViewAsDataTable(DataGridView _DataGridView)
        {
            try
            {
                if (_DataGridView.ColumnCount == 0) return null;
                DataTable dtSource = new DataTable();
                //////create columns
                foreach (DataGridViewColumn col in _DataGridView.Columns)
                {
                    if (col.ValueType == null) dtSource.Columns.Add(col.Name, typeof(string));
                    else dtSource.Columns.Add(col.Name, col.ValueType);
                    dtSource.Columns[col.Name].Caption = col.HeaderText;
                }
                ///////insert row data
                foreach (DataGridViewRow row in _DataGridView.Rows)
                {
                    DataRow drNewRow = dtSource.NewRow();
                    foreach (DataColumn col in dtSource.Columns)
                    {
                        drNewRow[col.ColumnName] = row.Cells[col.ColumnName].Value;
                    }
                    dtSource.Rows.Add(drNewRow);
                }
                return dtSource;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Decorator
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="Error"></param>
        /// <returns></returns>
        public static bool ExportToPdf(DataTable dt,out string Error,DataTable dt2=null)
        {
            string ErrorLocation = "";
            Error = "";
            bool returnValue = false;
            try
            {
                ErrorLocation = "GetSetting";
                string strFilePath = "";
                if (Settings.TryGetValue("ExportPDFs", out strFilePath))
                {
                    ExportTable.Export.ExportToPdf(dt, strFilePath+"\\PDFExported_"+Guid.NewGuid().ToString()+".pdf",dt2);
                    returnValue = true;
                }
                else
                {
                    Error = "The setting is not in the database";
                }                
            }
            catch (Exception ex)
            {
                Error = ex.Message;                
            }                        
            return returnValue;
        }
        public static bool ExportToExcel(DataTable dt, out string Error, DataTable dt2=null)
        {
            string ErrorLocation = "";
            Error = "";
            bool returnValue = false;
            try
            {
                ErrorLocation = "GetSetting";
                string strFilePath = "";
                if (Settings.TryGetValue("ExportExcel", out strFilePath))
                {
                    if(ExportTable.Export.ExportToExcel(dt, strFilePath + "\\ExcelExported_" + Guid.NewGuid().ToString() + ".xlsx",out Error,dt2))                    
                        returnValue = true;                                                 
                }
                else
                {
                    Error = "The setting is not in the database";
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return returnValue;
        }
    }
}
using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;

using System.Threading.Tasks;

namespace uReclutmentWinForm.Control
{
    public enum enumClass
    {
        Candidates = 1,
        Comments = 2,
        Customers = 3,
        EnumType = 4,
        Execute = 5,
        Log = 7,
        Meetings = 8,
        Questions = 9,
        QuestionDetails = 10,
        Requirements = 11,
        Settings = 12,
        Satges = 13,
        Vacancy = 14
    }
    public class ApiControl<T> : ApiControlBase<T>
    {
        public ApiControl() { }

        public static async Task<DataTable> GetDataTable(string path)
        {
            try
            {
                string result = await Get(path);
                FormatData<T> information = new FormatData<T>();
                var serializer = new JsonSerializer();

                using (var sr = new StreamReader(result))
                using (var jsonTextReader = new JsonTextReader(sr))
                {
                    var jsObj = serializer.Deserialize<FormatData<T>>(jsonTextReader);
                }
                
                if (information.Data.ToList() == null)
                {
                    information.Data = new List<T>();
                }

                return ToDataTable(information.Data.ToList());
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public static async Task<List<T>> GetDictionary(string path)
        {
            string result = await Get(path);
            FormatData<T> information = new FormatData<T>();
            var serializer = new JsonSerializer();

            using (var sr = new StreamReader(result))
            using (var jsonTextReader = new JsonTextReader(sr))
            {
                var jsObj = serializer.Deserialize<FormatData<T>>(jsonTextReader);
            }            
            return information.Data.ToList();
        }
        public static async Task<bool> Add(string path, T obj)
        {
            try
            {


                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }        
        public static DataTable ToDataTable(List<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}

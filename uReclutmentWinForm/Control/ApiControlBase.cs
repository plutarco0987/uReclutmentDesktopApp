
using Entities;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace uReclutmentWinForm.Control
{
    public class ReturnData {
        public ReturnData()
        {

        }
        public DataTable DataTable { get; set; }
        public string Error { get; set; }
    }        
    public class ApiControlBase<T>
    {        

       

        public static async Task<string> Get(string path)
        {

            
            string json = "";
            try
            {                
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(path);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.GetAsync("").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        json= response.Content.ReadAsStringAsync().Result;                                                
                    }
                }                    
            }
            catch (Exception ex)
            {                
            }            

            return json;
        }
        
        public static async Task<string> Post(string path, T obj,bool isAsync=true,bool removeNulls=false)
        {
            string json = "";
            try
            {
                using (var client = new HttpClient())
                {
                    var ms = new MemoryStream();
                    var writer = new StreamWriter(ms);
                    var serializer = new JsonSerializer();
                    serializer.Serialize(writer, obj);
                    var myContent= System.Text.Encoding.UTF8.GetString(ms.ToArray(), 0, (int)ms.Length);

                    if (removeNulls)
                    {
                        myContent = myContent.Replace("null", "\"\"");
                    }
                    var bytecontent = new ByteArrayContent(Encoding.UTF8.GetBytes(myContent));
                    bytecontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");                                                           
                    var request = new HttpRequestMessage(HttpMethod.Post, path)
                    {
                        Content = bytecontent                    
                    };
                    if (isAsync)
                    {
                        //HttpResponseMessage response = await client.PostAsJsonAsync(path, obj);
                        var result = await client.SendAsync(request);
                        if (result.IsSuccessStatusCode)
                        {
                            json = result.Content.ReadAsStringAsync().Result;
                        }
                    }
                    else
                    {
                        var result = await client.SendAsync(request);
                        if (result.IsSuccessStatusCode)
                        {
                            json = result.Content.ReadAsStringAsync().Result;
                        }
                    }
                    
                }
            }
            catch (Exception ex)                
            {                
            }

            return json;
        }
        public static async Task<string> Put(string path, T obj, bool removeNulls = false)
        {
            string json = "";
            try
            {
                using (var client = new HttpClient())
                {
                    var ms = new MemoryStream();
                    var writer = new StreamWriter(ms);
                    var serializer = new JsonSerializer();
                    serializer.Serialize(writer, obj);
                    var myContent = System.Text.Encoding.UTF8.GetString(ms.ToArray(), 0, (int)ms.Length);
                    if (removeNulls)
                    {
                        myContent = myContent.Replace("null", "\"\"");
                    }
                    var bytecontent = new ByteArrayContent(Encoding.UTF8.GetBytes(myContent));
                    bytecontent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var request = new HttpRequestMessage(HttpMethod.Put, path)
                    {
                        Content = bytecontent
                    };                    
                    //HttpResponseMessage response = await client.PutAsJsonAsync(path, obj);
                    var result = await client.SendAsync(request);
                    if (result.IsSuccessStatusCode)
                    {
                        json = result.Content.ReadAsStringAsync().Result;
                    }                    
                }
            }
            catch (Exception ex)
            {
            }

            return json;
        }
    }
}
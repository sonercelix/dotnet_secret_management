using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_secret_management
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connString = ConfigurationManager.ConnectionStrings["PersonnelDB"].ToString();
            string apiKey =  ConfigurationManager.AppSettings["PersonelServiceApiKey"];
            string path = ConfigurationManager.AppSettings["path"];


            //2.yöntem
            string testApiKey = Environment.GetEnvironmentVariable("TEST_API_KEY");

            //3.yöntem.
            GetApiKeyFromJsonFile();

            Console.ReadKey();
        }

        private static void GetApiKeyFromJsonFile()
        {
            var secretsFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "secrets.json");
            var secretsJson = File.ReadAllText(secretsFilePath);
            var secrets = JObject.Parse(secretsJson);

            string apiKey = secrets["ApiKey"].ToString();
        }
    }
}

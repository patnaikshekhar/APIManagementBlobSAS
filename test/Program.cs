using System;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading.Tasks;
using System.Net.Http;
using System.Configuration;

namespace test
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task TestCallout(string filename)
        {
            string apiURL = ConfigurationManager.AppSettings["ApiURL"];
            string apiKey = ConfigurationManager.AppSettings["ApiKey"];
            
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);

            var response = await client.PostAsync($"{apiURL}/{filename}", null);
            string sasURL = await response.Content.ReadAsStringAsync();

            CloudBlockBlob blob = new CloudBlockBlob(new Uri(sasURL));
            await blob.UploadTextAsync("Sample Text");
        }

        static void Main(string[] args)
        {
            TestCallout("sampleFile.txt").Wait();
            Console.WriteLine("Upload successful");
        }
    }
}

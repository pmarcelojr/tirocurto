using System;
using RestSharp;

namespace CodeBehind.Invoke
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Invoke a REST API");
            InvocarPost();
            InvocarGet();
            InvocarPut();
        }

        public static void InvocarPost()
        {
            var client = new RestClient($"https://run.mocky.io/v3/8fafdd68-a090-496f-8c9a-3442cf30dae6");

            RestRequest request = new RestRequest("", Method.Post);
            request.AddJsonBody(new { Id = 5 });
            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine(response.Content);
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
            }
        }

        public static void InvocarGet()
        {
            string cep = "04414190";

            var client = new RestClient($"https://viacep.com.br/ws/{cep}/json/");
            RestRequest request = new RestRequest("", Method.Get);
            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine(response.Content);
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
            }
        }

        public static void InvocarPut()
        {
            var client = new RestClient($"https://run.mocky.io/v3/8fafdd68-a090-496f-8c9a-3442cf30dae6");

            RestRequest request = new RestRequest("", Method.Put);
            request.AddJsonBody(new { Id = 5 });
            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine(response.Content);
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
            }
        }
    }
}

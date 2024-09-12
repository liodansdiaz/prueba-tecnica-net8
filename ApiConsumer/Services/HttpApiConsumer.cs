using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiConsumer.Interfaces;

namespace ApiConsumer.Services
{
    public class HttpApiConsumer : IHttpApiConsumer
    {
        private readonly HttpClient _httpClient;

        public HttpApiConsumer(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task ConsumeAsync(string url)
        {

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();

                using var stream = await response.Content.ReadAsStreamAsync();
                using var streamReader = new System.IO.StreamReader(stream);
                string line;
                while ((line = await streamReader.ReadLineAsync()) != null)
                {
                    Console.WriteLine(line);
                }

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Ocurrió un error en la solicitud http: {e.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
            }
           
        }
    }
}

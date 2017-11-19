using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using PostBoy.Options;
using PostBoy.Options.Interface;
using CommandLine;

namespace PostBoy
{
    class Program
    {
        private static int Main(string[] args)
        {
            return Parser.Default
                .ParseArguments<HttpPostOptions, HttpGetOptions>(args)
                .MapResult(
                    (HttpPostOptions options) => Await(PostAsync(options)),
                    (HttpGetOptions options) => Await(GetAsync(options)),
                    errors => 1
                );
        }

        private static int Await(Task task)
        {
            task.Wait();
            return 0;
        }

        private static async Task GetAsync(HttpGetOptions options)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync(options.Endpoint);
        }

        private static async Task PostAsync(HttpPostOptions options)
        {
            using (Stream stream = GetStream(options))
            {
                HttpClient client = new HttpClient();
                HttpContent content = GetHttpContent(stream, options);
                HttpResponseMessage responseMessage = await client.PostAsync(options.Endpoint, content);
            }
        }

        private static Stream GetStream(IHttpMessageOptions options)
        {
            Stream stream;

            if (options.File != null) {
                stream = new FileStream(options.File, FileMode.Open);
            }
            else if (options.Message != null)
            {
                stream = new MemoryStream();
                StreamWriter writer = new StreamWriter(stream);
                writer.Write(options.Message);
                writer.Flush();
                stream.Position = 0;
            }
            else
            {
                stream = Console.OpenStandardInput();
            }

            return stream;
        }

        private static HttpContent GetHttpContent(Stream stream, IHttpContentOptions options)
        {
            HttpContent content;
            if (options.Stream)
            {
                if (options.BufferSize.HasValue)
                {
                    content = new StreamContent(stream, options.BufferSize.Value);
                }
                else
                {
                    content = new StreamContent(stream);
                }
            }
            else
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string s = reader.ReadToEnd();
                    content = new StringContent(s);
                }
            }

            content.Headers.ContentType = MediaTypeHeaderValue.Parse(options.MediaType);

            return content;
        }
    }
}

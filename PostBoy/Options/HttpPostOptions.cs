using CommandLine;
using CommandLine.Text;
using PostBoy.Options.Abstract;
using System.Collections.Generic;

namespace PostBoy.Options
{
    [Verb("post", HelpText = "Issue a POST request towards an endpoint.")]
    public class HttpPostOptions : HttpMessageContentOptions
    {
        [Usage(ApplicationAlias = "postboy")]
        public static IEnumerable<Example> Examples
        {
            get
            {
                yield return new Example("Send a message", new HttpPostOptions { Endpoint = "https://localhost:5000", Message = "Hello" });
                yield return new Example("Send a file", new HttpPostOptions { Endpoint = "https://localhost:5000", File = ".\file.txt" });
            }
        }
    }
}

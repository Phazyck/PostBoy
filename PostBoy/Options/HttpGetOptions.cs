using CommandLine;
using CommandLine.Text;
using PostBoy.Options.Abstract;
using System.Collections.Generic;

namespace PostBoy.Options
{
    [Verb("get", HelpText = "Issue a GET request towards an endpoint.")]
    public class HttpGetOptions : HttpOptions
    {
        [Usage(ApplicationAlias = "postboy")]
        public static IEnumerable<Example> Examples
        {
            get
            {
                yield return new Example("Normal scenario", new HttpGetOptions { Endpoint = "https://localhost:5000" });
            }
        }
    }
}

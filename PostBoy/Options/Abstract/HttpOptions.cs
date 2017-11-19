using CommandLine;

namespace PostBoy.Options.Abstract
{
    public abstract class HttpOptions : OptionsBase
    {
        [Option('e', "endpoint", Required = true, HelpText = "The recipient of the request.")]
        public string Endpoint { get; set; }

        [Option('t', "thumbprint", HelpText = "The thumbprint of the client certificate thumbprint to use.")]
        public string Thumbprint { get; set; }
    }
}

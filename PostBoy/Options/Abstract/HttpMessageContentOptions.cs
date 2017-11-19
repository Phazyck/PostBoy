using CommandLine;
using PostBoy.Options.Interface;

namespace PostBoy.Options.Abstract
{
    public abstract class HttpMessageContentOptions : HttpOptions, IHttpMessageOptions, IHttpContentOptions
    {
        [Option('m', "message", HelpText = "The message.", SetName = "source")]
        public string Message { get; set; }

        [Option('f', "file", HelpText = "A file to use as the message source.", SetName = "source")]
        public string File { get; set; }

        [Option('s', "stream", HelpText = "Stream this message.")]
        public bool Stream { get; set; }

        [Option('b', "bufferSize", HelpText = "The size of the streaming buffer.")]
        public int? BufferSize { get; set; }

        [Option("mediaType", Default = "text/plain; charset=utf-8", HelpText = "The Content-Type of the message.")]
        public string MediaType { get; set; }
    }
}

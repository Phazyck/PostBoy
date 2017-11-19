namespace PostBoy.Options.Interface
{
    public interface IHttpContentOptions
    {
        bool Stream { get; set; }

        int? BufferSize { get; set; }

        string MediaType { get; set; }
    }
}

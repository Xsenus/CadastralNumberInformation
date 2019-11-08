namespace CadastralNumberInformation.Core
{
    public interface IParserSettings
    {
        string BaseUrl { get; set; }
        string Page { get; set; }
        string CadastralNumber { get; set; }
    }
}

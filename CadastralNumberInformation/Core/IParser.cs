
using AngleSharp.Html.Dom;

namespace CadastralNumberInformation.Core
{
    public interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}

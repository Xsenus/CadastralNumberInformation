using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CadastralNumberInformation.Core
{
    public class HtmlLoader
    {
        readonly HttpClient client;
        readonly string url;

        public HtmlLoader(IParserSettings settings)
        {
            client = new HttpClient();
            url = $"{settings.BaseUrl}/{settings.Page}/";
        }

        public async Task<string> GetSourceByPage(string cadastralNumber)
        {
            var currentUrl = $"{url}{cadastralNumber}";
            var response = await client.GetAsync(currentUrl);
            string source = null;

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }
    }
}

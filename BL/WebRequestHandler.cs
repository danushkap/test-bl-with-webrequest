using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace BL
{
    public interface IWebRequestHandler
    {
        Task<string> GetStringAsync(string requestUri);
    }

    public class WebRequestHandler : IWebRequestHandler
    {
        public async Task<string> GetStringAsync(string requestUri)
        {
            using (var webClient = new HttpClient())
            using (var stream = await webClient.GetStreamAsync(requestUri))
            {
                stream.Position = 0;
                using (var streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }
}

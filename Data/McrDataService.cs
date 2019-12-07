using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace McrBrowser.Data
{
    public class McrDataService
    {
        public async Task<ImageTagData> GetTagListAsync(string imageName)
        {
            var jsonFeedUri = new Uri($@"https://mcr.microsoft.com/v2/{imageName}/tags/list", UriKind.Absolute);
            using var request = new HttpRequestMessage(HttpMethod.Get, jsonFeedUri);
            using var client = new HttpClient();
            using var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ImageTagData>(content);
        }
    }
}

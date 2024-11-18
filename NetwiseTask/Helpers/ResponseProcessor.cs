using System.Text.Json;

namespace NetwiseTask.Helpers
{
    public interface IResponseProcessor
    {
        public Task<string> Process(HttpResponseMessage response);
    }
    public class ResponseProcessor : IResponseProcessor
    {
        public async Task<string> Process(HttpResponseMessage response)
        {
            var formattedResponse = await response.Content.ReadAsStringAsync();

            return formattedResponse;
        }
    }
}

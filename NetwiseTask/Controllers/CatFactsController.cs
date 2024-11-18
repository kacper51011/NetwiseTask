using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetwiseTask.Helpers;
using System.IO;
using System.Runtime.CompilerServices;

namespace NetwiseTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatFactsController : ControllerBase
    {
        // mocno uproszczone architekturalnie
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFileWriter _writer;
        private readonly IFileReader _reader;
        private readonly IResponseProcessor _responseProcessor;
        public CatFactsController(IHttpClientFactory httpClientFactory, IFileWriter writer, IFileReader reader, IResponseProcessor responseProcessor)
        {
            
            _httpClientFactory = httpClientFactory;
            _writer = writer;
            _reader = reader;
            _responseProcessor = responseProcessor;
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewLineInTxt()
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync("https://catfact.ninja/fact");
            response.EnsureSuccessStatusCode();

            var formattedResponse = await _responseProcessor.Process(response);
            await _writer.WriteToLogFile(formattedResponse);

            return Created();
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetTxtFileLogs()
        {
            return await _reader.ReadLogs();
        }
    }
}

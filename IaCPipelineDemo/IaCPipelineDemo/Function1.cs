using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace IaCPipelineDemo
{
    public class Function1
    {
        private readonly string _secret;
        private readonly string _environment;

        public Function1(IConfiguration configuration)
        {
            _secret = configuration["Secret"];
            _environment = configuration["Environment"];
        }

        [FunctionName(nameof(Function1))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string responseMessage = $"The secret in {_environment} environment is {_secret}";

            return new OkObjectResult(responseMessage);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Rika_CategoryProvider
{
    public class CreateCategory
    {
        private readonly ILogger<CreateCategory> _logger;

        public CreateCategory(ILogger<CreateCategory> logger)
        {
            _logger = logger;
        }

        [Function("CreateCategory")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}

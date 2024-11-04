using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Rika_CategoryProvider
{
    public class DeleteCategory
    {
        private readonly ILogger<DeleteCategory> _logger;

        public DeleteCategory(ILogger<DeleteCategory> logger)
        {
            _logger = logger;
        }

        [Function("DeleteCategory")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult("Welcome to Azure Functions!");
        }
    }
}

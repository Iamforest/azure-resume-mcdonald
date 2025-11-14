<<<<<<< HEAD
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
=======
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Cosmos;
using System.Net.Http;
using System.Text;
using Microsoft.Azure.Functions.Worker;
>>>>>>> da07845d2153e470181aebef3406433959301585

namespace Company.Function
{
    public class GetResumeCounter
    {
<<<<<<< HEAD
        private readonly ILogger<GetResumeCounter> _logger;

        public GetResumeCounter(ILogger<GetResumeCounter> logger)
=======
        [Function("GetResumeCounter")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDBInput(databaseName: "AzureResume",
            containerName: "Counter",
            Connection = "AzureResumeConnectionString",
            Id = "1",
            PartitionKey = "1")] Counter counter,
            [CosmosDBInput(databaseName: "AzureResume",
            containerName: "Counter",
            Connection = "AzureResumeConnectionString")] out Counter updatedCounter,
            ILogger log)
>>>>>>> da07845d2153e470181aebef3406433959301585
        {
            _logger = logger;
        }

        [Function("GetResumeCounter")]
        [CosmosDBOutput(
            databaseName: "AzureResume",
            containerName: "Counter",
            Connection = "AzureResumeConnectionString")]
        public async Task<Counter> RunAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post")]
            HttpRequestData req,

            [CosmosDBInput(
                databaseName: "AzureResume",
                containerName: "Counter",
                Connection = "AzureResumeConnectionString",
                Id = "1",
                PartitionKey = "1")]
            Counter counter)
        {
            _logger.LogInformation("HTTP trigger executed.");

            // Update counter
            counter.Count += 1;

            // Prepare HTTP response
            var response = req.CreateResponse(HttpStatusCode.OK);
            var json = JsonConvert.SerializeObject(counter);
            await response.WriteStringAsync(json);

            // Instead of IAsyncCollector, just return the updated object
            return counter;
        }
    }

    public class Counter
    {
        [JsonProperty("id")]
        public string Id { get; set; } = "1";

        [JsonProperty("count")]
        public int Count { get; set; }
    }
}

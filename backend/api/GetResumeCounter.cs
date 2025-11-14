using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Company.Function
{
    public class GetResumeCounter
    {
        private readonly ILogger<GetResumeCounter> _logger;

        public GetResumeCounter(ILogger<GetResumeCounter> logger)
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

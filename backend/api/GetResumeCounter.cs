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

namespace Company.Function
{
    public static class GetResumeCounter
    {
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
        {
            // Here is where the counter gets updated ok?
            log.LogInformation("C# HTTP trigger function processed a request.");

            updatedCounter = counter;
            updatedCounter.Count += 1;

            var JsonToReturn = JsonConvert.SerializeObject(counter);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK){
                
                Content = new StringContent(JsonToReturn, Encoding.UTF8)
            };
        }
    }
}

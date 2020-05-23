using Cloudy.CMS.DocumentSupport;
using KubeClient;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cloudy.Cms.Addon.KubernetesCrd
{
    public class DocumentCreator : IDocumentCreator
    {
        KubeApiClient Client { get; }
        ILogger<DocumentCreator> Logger { get; }

        public DocumentCreator(ILogger<DocumentCreator> logger, IClientProvider clientProvider)
        {
            Logger = logger;
            Client = clientProvider.GetClient();
        }

        public async Task Create(string container, Document document)
        {
            var body = new
            {
                apiVersion = "cloudy-cms.net/v1",
                kind = $"cloudy{container}",
                metadata = new { name = document.Id },
                spec = document
            };

            if (Logger.IsEnabled(LogLevel.Information))
            {
                Logger.LogInformation($"Sending to Kubernetes:\n\n{JsonConvert.SerializeObject(body)}");
            }

            var response = await Client.Http.PostAsync($"apis/cloudy-cms.net/v1/namespaces/default/cloudy{container}", new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json")).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"{(int)response.StatusCode} {response.ReasonPhrase}: {await response.Content.ReadAsStringAsync().ConfigureAwait(false)}");
            }
        }
    }
}
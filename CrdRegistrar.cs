using Cloudy.CMS.ContentTypeSupport;
using Cloudy.CMS.InitializerSupport;
using KubeClient;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cloudy.Cms.Addon.KubernetesCrd
{
    public class CrdRegistrar : IInitializer
    {
        KubeApiClient Client { get; }
        IContentTypeProvider ContentTypeProvider { get; }
        ILogger<CrdRegistrar> Logger { get; }

        public CrdRegistrar(ILogger<CrdRegistrar> logger, IClientProvider clientProvider, IContentTypeProvider contentTypeProvider)
        {
            Logger = logger;
            Client = clientProvider.GetClient();
            ContentTypeProvider = contentTypeProvider;
        }

        public async Task InitializeAsync()
        {
            var containers = ContentTypeProvider.GetAll().Select(t => t.Container).Distinct();

            foreach (var container in containers)
            {
                var reference = $"cloudy{container}";
                var name = $"{reference}.cloudy-cms.net";
                var body = new
                {
                    apiVersion = "apiextensions.k8s.io/v1beta1",
                    metadata = new { name },
                    spec = new
                    {
                        group = "cloudy-cms.net",
                        names = new
                        {
                            kind = reference,
                            plural = reference,
                            singular = reference
                        },
                        scope = "Namespaced",
                        versions = new[] { new { name = "v1", served = true, storage = true } }
                    }
                };

                if((await Client.Http.GetAsync($"apis/apiextensions.k8s.io/v1beta1/customresourcedefinitions/{name}", HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false)).StatusCode == HttpStatusCode.OK)
                {
                    continue;
                }

                if (Logger.IsEnabled(LogLevel.Information))
                {
                    Logger.LogInformation($"Sending to Kubernetes:\n\n{JsonConvert.SerializeObject(body)}");
                }

                var response = await Client.Http.PostAsync("apis/apiextensions.k8s.io/v1beta1/customresourcedefinitions", new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json")).ConfigureAwait(false);
                
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"{(int)response.StatusCode} {response.ReasonPhrase}: {await response.Content.ReadAsStringAsync().ConfigureAwait(false)}");
                }
            }
        }
    }
}

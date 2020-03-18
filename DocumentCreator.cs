using Cloudy.CMS.DocumentSupport;
using KubeClient;
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

        public DocumentCreator(IClientProvider clientProvider)
        {
            Client = clientProvider.GetClient();
        }

        public async Task Create(string container, Document document)
        {
            var body = new
            {
                metadata = new
                {
                    label = "lorem ipsum",
                    name = "testcontent"
                },
                spec = new
                {
                    lorem = "ipsum"
                }
            };

            var result = await Client.CreateClusterCustomObjectAsync(JsonConvert.SerializeObject(body), "cloudy", "v1", "content").ConfigureAwait(false);

        }
    }
}
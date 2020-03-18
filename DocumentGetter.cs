using Cloudy.CMS.DocumentSupport;
using KubeClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cloudy.Cms.Addon.KubernetesCrd
{
    public class DocumentGetter : IDocumentGetter
    {
        KubeApiClient Client { get; }

        public DocumentGetter(IClientProvider clientProvider)
        {
            Client = clientProvider.GetClient();
        }

        public async Task<Document> GetAsync(string container, string id)
        {
            var result = (await Client.GetClusterCustomObjectAsync("cloudy", "v1", "content", id).ConfigureAwait(false)).ToString();

            return JsonConvert.DeserializeObject<Document>(result);
        }
    }
}
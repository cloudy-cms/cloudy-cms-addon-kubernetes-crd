using Cloudy.CMS.DocumentSupport;
using KubeClient;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cloudy.Cms.Addon.KubernetesCrd
{
    public class DocumentDeleter : IDocumentDeleter
    {
        KubeApiClient Client { get; }

        public DocumentDeleter(IClientProvider clientProvider)
        {
            Client = clientProvider.GetClient();
        }

        public async Task DeleteAsync(string container, string id)
        {
            //await Client.DeleteClusterCustomObjectAsync(new k8s.Models.V1DeleteOptions(), "cloudy", "v1", "content", "testcontent").ConfigureAwait(false);
        }
    }
}
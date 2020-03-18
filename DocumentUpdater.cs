using Cloudy.CMS.DocumentSupport;
using KubeClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cloudy.Cms.Addon.KubernetesCrd
{
    public class DocumentUpdater : IDocumentUpdater
    {
        KubeApiClient Client { get; }

        public DocumentUpdater(IClientProvider clientProvider)
        {
            Client = clientProvider.GetClient();
        }

        public async Task UpdateAsync(string container, string id, Document document)
        {
            //string _id;

            //{
            //    var response = await Client.GetAsync($"{EndpointProvider.Endpoint}/{container}?q=Id:{id}").ConfigureAwait(false);

            //    if (!response.IsSuccessStatusCode)
            //    {
            //        throw new Exception($"{response.StatusCode} {response.ReasonPhrase}: {await response.Content.ReadAsStringAsync().ConfigureAwait(false)}");
            //    }
                
            //    var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            //    var item = JsonConvert.DeserializeObject<IEnumerable<JObject>>(result).First();

            //    _id = item.Value<string>("_id");
            //}

            //{
            //    var response = await Client.PutAsync($"{EndpointProvider.Endpoint}/{_id}", new StringContent(JsonConvert.SerializeObject(document), Encoding.UTF8, "application/json")).ConfigureAwait(false);

            //    if (!response.IsSuccessStatusCode)
            //    {
            //        throw new Exception($"{response.StatusCode} {response.ReasonPhrase}: {await response.Content.ReadAsStringAsync().ConfigureAwait(false)}");
            //    }
            //}
        }
    }
}
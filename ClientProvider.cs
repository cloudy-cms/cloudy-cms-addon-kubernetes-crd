using KubeClient;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudy.Cms.Addon.KubernetesCrd
{
    public class ClientProvider : IClientProvider, IDisposable
    {
        KubeApiClient Client { get; }

        public ClientProvider(IClientCreator clientCreator)
        {
            Client = clientCreator.CreateClient();
        }

        public KubeApiClient GetClient()
        {
            return Client;
        }

        public void Dispose()
        {
            Client.Dispose();
        }
    }
}

using KubeClient;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudy.Cms.Addon.KubernetesCrd
{
    public class ClientCreator : IClientCreator
    {
        IWebHostEnvironment WebHostEnvironment { get; }

        public ClientCreator(IWebHostEnvironment env)
        {
            WebHostEnvironment = env;
        }

        public KubeApiClient CreateClient()
        {
            return KubeApiClient.Create(K8sConfig.Load().ToKubeClientOptions());
            //if (WebHostEnvironment.IsDevelopment())
            //{
            //    return KubeApiClient.Create(K8sConfig.Load().ToKubeClientOptions());
            //}
            //else
            //{
            //    // Load from in-cluster configuration:
            //    var config = KubernetesClientConfiguration.InClusterConfig();

            //    return new Kubernetes(config);
            //}
        }
    }
}

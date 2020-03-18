using Cloudy.CMS.InitializerSupport;
using KubeClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudy.Cms.Addon.KubernetesCrd
{
    public class CrdRegistrar : IInitializer
    {
        KubeApiClient Client { get; }

        public CrdRegistrar(IClientProvider clientProvider)
        {
            Client = clientProvider.GetClient();
        }

        public void Initialize()
        {
            var spec = new k8s.Models.V1CustomResourceDefinitionSpec("cloudy", new k8s.Models.V1CustomResourceDefinitionNames("Content", "content", null, null, null, "content"), "Namespaced", new List<k8s.Models.V1CustomResourceDefinitionVersion> { new k8s.Models.V1CustomResourceDefinitionVersion("v1", true, true) });
            var body = new k8s.Models.V1CustomResourceDefinition(spec);

            Client.CreateCustomResourceDefinition(body);
        }
    }
}

using Cloudy.Cms.Addon.KubernetesCrd;
using Cloudy.CMS;
using Cloudy.CMS.DocumentSupport;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Microsoft.AspNetCore.Builder
{
    public static class StartupExtensions
    {
        public static CloudyConfigurator WithKubernetesCrds(this CloudyConfigurator configurator)
        {
            configurator.Options.HasDocumentProvider = true;

            configurator.AddComponent<KubernetesCrdComponent>();

            return configurator;
        }
    }
}

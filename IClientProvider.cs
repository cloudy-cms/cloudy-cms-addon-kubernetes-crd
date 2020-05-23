using KubeClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudy.Cms.Addon.KubernetesCrd
{
    public interface IClientProvider
    {
        KubeApiClient GetClient();
    }
}

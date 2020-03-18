using KubeClient;

namespace Cloudy.Cms.Addon.KubernetesCrd
{
    public interface IClientCreator
    {
        KubeApiClient CreateClient();
    }
}
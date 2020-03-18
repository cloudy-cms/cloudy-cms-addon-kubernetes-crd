using Cloudy.CMS.DocumentSupport;
using System;

namespace Cloudy.Cms.Addon.KubernetesCrd
{
    public class DocumentFinder : IDocumentFinder
    {
        IServiceProvider ServiceProvider { get; }

        public DocumentFinder(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public IDocumentFinderQueryBuilder Find(string container)
        {
            var builder = (DocumentFinderQueryBuilder)ServiceProvider.GetService(typeof(IDocumentFinderQueryBuilder));

            builder.Container = container;

            return builder;
        }
    }
}
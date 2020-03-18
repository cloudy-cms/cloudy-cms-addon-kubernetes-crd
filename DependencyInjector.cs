using Cloudy.CMS.DependencyInjectionSupport;
using Cloudy.CMS.DocumentSupport;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudy.Cms.Addon.KubernetesCrd
{
    public class DependencyInjector : IDependencyInjector
    {
        public void InjectDependencies(IContainer container)
        {
            container.RegisterSingleton<IClientCreator, ClientCreator>();
            container.RegisterSingleton<IClientProvider, ClientProvider>();
            container.RegisterTransient<IDocumentPropertyFinder, DocumentPropertyFinder>();
            container.RegisterSingleton<IDocumentCreator, DocumentCreator>();
            container.RegisterSingleton<IDocumentDeleter, DocumentDeleter>();
            container.RegisterSingleton<IDocumentFinder, DocumentFinder>();
            container.RegisterSingleton<IDocumentGetter, DocumentGetter>();
            container.RegisterSingleton<IDocumentUpdater, DocumentUpdater>();
            container.RegisterTransient<IDocumentFinderQueryBuilder, DocumentFinderQueryBuilder>();
        }
    }
}

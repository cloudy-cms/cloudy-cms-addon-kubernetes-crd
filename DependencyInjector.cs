using Cloudy.CMS.DependencyInjectionSupport;
using Cloudy.CMS.DocumentSupport;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloudy.Cms.Addon.KubernetesCrd
{
    public class DependencyInjector : IDependencyInjector
    {
        public void InjectDependencies(IServiceCollection services)
        {
            services.AddSingleton<IClientCreator, ClientCreator>();
            services.AddSingleton<IClientProvider, ClientProvider>();
            services.AddTransient<IDocumentPropertyFinder, DocumentPropertyFinder>();
            services.AddSingleton<IDocumentCreator, DocumentCreator>();
            services.AddSingleton<IDocumentDeleter, DocumentDeleter>();
            services.AddSingleton<IDocumentFinder, DocumentFinder>();
            services.AddSingleton<IDocumentGetter, DocumentGetter>();
            services.AddSingleton<IDocumentUpdater, DocumentUpdater>();
            services.AddTransient<IDocumentFinderQueryBuilder, DocumentFinderQueryBuilder>();
        }
    }
}

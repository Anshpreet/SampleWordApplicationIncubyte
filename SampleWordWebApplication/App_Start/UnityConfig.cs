using SampleWord.Repositories;
using SampleWord.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace SampleWordWebApplication
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IWordRepository, WordRepository>();
            container.RegisterType<IWordService, WordService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
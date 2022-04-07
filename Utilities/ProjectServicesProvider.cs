using Microsoft.Extensions.DependencyInjection;
using TestsGenerator.Models.DataLayer;
using TestsGenerator.Models.Processing;
using TestsGenerator.ViewModels.Factory;

namespace TestsGenerator.Utilities
{
    public static class ProjectServicesProvider
    {
        public static ServiceProvider Provide()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IMainWindowViewModelFactory, MainWindowViewModelFactory>();
            services.AddSingleton<ITestRepository, TestRepository>();
            services.AddSingleton<IEntityRepository, EntityRepository>();
            services.AddSingleton<ITestCreator, TestCreator>();
            services.AddSingleton<ITestParser, TestParser>();

            return services.BuildServiceProvider();
        }
    }
}
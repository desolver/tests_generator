using System.Linq;
using TestsGenerator.Models.DataLayer;
using TestsGenerator.Models.Processing;

namespace TestsGenerator.ViewModels.Factory
{
    public class MainWindowViewModelFactory : IMainWindowViewModelFactory
    {
        private readonly ITestRepository testRepository;
        private readonly ITestCreator testCreator;

        public MainWindowViewModelFactory(ITestRepository testRepository, ITestCreator testCreator)
        {
            this.testRepository = testRepository;
            this.testCreator = testCreator;
        }

        public MainWindowViewModel Create()
        {
            var existingTests = testRepository.GetAll();

            return new MainWindowViewModel(existingTests.ToList(), testCreator);
        }
    }
}
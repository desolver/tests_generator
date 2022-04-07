using System.Collections.Generic;
using System.Collections.ObjectModel;
using TestsGenerator.Models;
using TestsGenerator.Models.Processing;

namespace TestsGenerator.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ITestCreator testCreator;

        public MainWindowViewModel() { }

        public MainWindowViewModel(List<Test> existingTests, ITestCreator testCreator) : this()
        {
            this.testCreator = testCreator;
            Tests = new ObservableCollection<Test>(existingTests);
            CreateTestViewModel.NewTestAdded += CreateTestFromView;
        }

        public ObservableCollection<Test> Tests { get; }

        public void CreateTestFromFile()
        {
            var createdTestResult = testCreator.TryCreateFromFile();

            if (createdTestResult.IsSuccess)
            {
                AddTest(createdTestResult.Value);
            }
            else
            {
                // ... error
            }
        }

        private void AddTest(Test newTest) => Tests.Add(newTest);

        private void CreateTestFromView(CreateTestViewModel newTest)
        {
            var createdTestResult = testCreator.TryCreateFromView(newTest);

            if (createdTestResult.IsSuccess)
            {
                AddTest(createdTestResult.Value);
            }
            else
            {
                // ... error
            }
        }
    }
}
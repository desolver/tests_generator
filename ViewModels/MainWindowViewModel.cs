using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TestsGenerator.Models;
using TestsGenerator.Models.DataLayer;
using TestsGenerator.Models.Processing;

namespace TestsGenerator.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ITestCreator testCreator;
        private readonly ITestRepository testRepository;

        public MainWindowViewModel() { }

        public MainWindowViewModel(List<Test> existingTests, ITestCreator testCreator, ITestRepository testRepository)
            : this()
        {
            this.testCreator = testCreator;
            this.testRepository = testRepository;
            Tests = new ObservableCollection<Test>(existingTests);
            CreateTestViewModel.NewTestAdded += CreateTestFromView;
        }

        public ObservableCollection<Test> Tests { get; }

        public void DeleteTest(Guid testId)
        {
            testRepository.Delete(testId);
            var testToDelete = Tests.First(test => test.Id == testId);
            Tests.Remove(testToDelete);
        }

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
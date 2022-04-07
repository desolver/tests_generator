using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using TestsGenerator.Models;
using TestsGenerator.Models.Processing;

namespace TestsGenerator.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly ITestCreator testCreator;

        public MainWindowViewModel() { }

        public MainWindowViewModel(List<Test> existingTests, ITestCreator testCreator) : this()
        {
            this.testCreator = testCreator;
            Tests = new ObservableCollection<Test>(existingTests);
        }

        public ObservableCollection<Test> Tests { get; }
        public void AddTest(Test newTest) => Tests.Add(newTest);

        public void ProcessFileOpen()
        {
            var createdTestResult = testCreator.TryCreateFromFile();

            if (createdTestResult.IsSuccess)
            {
                AddTest(createdTestResult.Value);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
using System.Collections.ObjectModel;
using TestsGenerator.ViewModels.Commands;

namespace TestsGenerator.ViewModels
{
    public class CreateTestViewModel : ViewModelBase
    {
        private string name;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private ObservableCollection<CreateQuestionViewModel> questions = new();
        public ObservableCollection<CreateQuestionViewModel> Questions
        {
            get => questions;
            set => SetProperty(ref questions, value);
        }

        public static RelayCommand CreateTestCommand
            => new(obj =>
                {
                    if (obj is CreateTestViewModel newTest)
                        NewTestAdded.Invoke(newTest);
                },
                _ => true);

        public delegate void TestCreateHandler(CreateTestViewModel newTest);
        public static event TestCreateHandler NewTestAdded;
    }
}
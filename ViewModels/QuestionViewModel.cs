using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TestsGenerator.ViewModels
{
    public class QuestionViewModel : ViewModelBase
    {
        public int Index { get; }
        public string Text { get; }
        public ObservableCollection<AnswerViewModel> Answers { get; }

        public QuestionViewModel(int index, string text, IEnumerable<AnswerViewModel> answers)
        {
            Index = index;
            Text = text;
            Answers = new ObservableCollection<AnswerViewModel>(answers);
        }
    }
}
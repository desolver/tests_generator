using System.Collections.Generic;

namespace TestsGenerator.ViewModels
{
    public class CreateQuestionViewModel : ViewModelBase
    {
        private string text;
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        private List<CreateAnswerViewModel> answers = new();
        public List<CreateAnswerViewModel> Answers
        {
            get => answers;
            set => SetProperty(ref answers, value);
        }

        public override string ToString() => $"{Text}";
    }
}
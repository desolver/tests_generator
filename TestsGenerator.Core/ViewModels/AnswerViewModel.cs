using TestsGenerator.Utilities;

namespace TestsGenerator.ViewModels
{
    public class AnswerViewModel : ViewModelBase
    {
        public int Index { get; }
        public bool IsCorrect { get; }
        public string Text { get; }

        private bool isUserChecked;
        public bool IsUserChecked
        {
            get => isUserChecked;
            set => SetProperty(ref isUserChecked, value);
        }

        private string viewColor;
        public string ViewColor
        {
            get => viewColor;
            set => SetProperty(ref viewColor, value);
        }

        private bool enabled;
        public bool Enabled
        {
            get => enabled;
            set => SetProperty(ref enabled, value);
        }

        public AnswerViewModel(int index, string text, bool isCorrect)
        {
            Index = index;
            Text = text;
            IsCorrect = isCorrect;
            ViewColor = ColorHelper.UNSELECTED_ANSWER_COLOR;
            Enabled = true;
        }
    }
}
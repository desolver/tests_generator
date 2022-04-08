namespace TestsGenerator.ViewModels
{
    public class CreateAnswerViewModel : ViewModelBase
    {
        private string text;
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        private bool isCorrect;
        public bool IsCorrect
        {
            get => isCorrect;
            set => SetProperty(ref isCorrect, value);
        }

        public override string ToString()
        {
            var isCorrectText = IsCorrect
                ? "Верный"
                : "Неверный";

            return $"{Text} - {isCorrectText}";
        }

        public CreateAnswerViewModel Copy()
            => new()
            {
                Text = Text,
                IsCorrect = IsCorrect
            };

        public void Clear()
        {
            Text = default;
            IsCorrect = default;
        }
    }
}
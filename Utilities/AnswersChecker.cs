using System.Collections.Generic;
using System.Linq;
using TestsGenerator.ViewModels;

namespace TestsGenerator.Utilities
{
    public static class AnswersChecker
    {
        public static IReadOnlyList<AnswerViewModel> GetIncorrectAnswers(IEnumerable<AnswerViewModel> answers)
            => answers
                .Where(a => !a.IsCorrect && a.IsUserChecked || a.IsCorrect && !a.IsUserChecked)
                .ToArray();
    }
}
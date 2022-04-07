using System.Collections.Generic;
using System.Linq;
using TestsGenerator.Models;
using TestsGenerator.ViewModels;

namespace TestsGenerator.Extensions
{
    public static class CreateQuestionViewModelExtensions
    {
        public static IReadOnlyList<Question> MapToQuestionModel(this IEnumerable<CreateQuestionViewModel> questions)
            => questions
                .Select((q, index) => new Question(index, q.Text, GetQuestionAnswers(q.Answers)))
                .ToArray();

        private static IReadOnlyList<Answer> GetQuestionAnswers(List<CreateAnswerViewModel> answers)
            => answers
                .Select(a => new Answer(a.Text, a.IsCorrect))
                .ToArray();
    }
}
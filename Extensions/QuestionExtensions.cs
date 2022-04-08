using System.Collections.Generic;
using System.Linq;
using TestsGenerator.Models;
using TestsGenerator.ViewModels;

namespace TestsGenerator.Extensions
{
    public static class QuestionExtensions
    {
        public static QuestionViewModel MapToQuestionViewModel(this Question question, int index)
            => new(index, question.Text, GetQuestionAnswers(question.Answers));

        private static IReadOnlyList<AnswerViewModel> GetQuestionAnswers(IEnumerable<Answer> answers)
            => answers
                .Select((a, index) => new AnswerViewModel(index, a.Text, a.IsCorrect))
                .ToArray();
    }
}
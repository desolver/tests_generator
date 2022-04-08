using System.Linq;
using TestsGenerator.Extensions;
using TestsGenerator.Models;

namespace TestsGenerator.Utilities
{
    public static class TestQuestionsRandomizer
    {
        public static Test Randomize(Test test)
        {
            var questions = test
                .Questions
                .ToArray()
                .Shuffle()
                .Select(q => new Question(
                    q.Id,
                    q.Text,
                    q
                        .Answers
                        .ToArray()
                        .Shuffle()
                        .ToArray()))
                .ToArray();

            return new Test(test.Id, test.Name, questions);
        }
    }
}
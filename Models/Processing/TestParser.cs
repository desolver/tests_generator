using System;
using System.Collections.Generic;
using System.Linq;
using FluentResults;

namespace TestsGenerator.Models.Processing
{
    public class TestParser : ITestParser
    {
        public Result<IReadOnlyList<Question>> TryParse(string fileContent)
        {
            var tests = fileContent.Split(new []{ "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            var questions = tests
                .Select((test, index) => ParseQuestion(index, test))
                .ToList();

            return Result.Ok<IReadOnlyList<Question>>(questions);
        }

        private static Question ParseQuestion(int id, string test)
        {
            const char correctAnswerPrefix = '+';
            const char wrongAnswerPrefix = '-';

            var answers = new List<Answer>();

            var lines = test
                .Split(new[] {'\n', '\r'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim());

            var text = "Вопрос без текста";

            foreach (var line in lines)
            {
                var isCorrectAnswer = line.StartsWith(correctAnswerPrefix);
                var isWrongAnswer = line.StartsWith(wrongAnswerPrefix);
                var lineIsQuestionText = !isCorrectAnswer && !isWrongAnswer;

                if (lineIsQuestionText)
                {
                    text = line;
                }
                else
                {
                    var answerText = line
                        .TrimStart(
                            isCorrectAnswer
                                ? correctAnswerPrefix
                                : wrongAnswerPrefix)
                        .TrimStart();

                    answers.Add(new Answer(answerText, isCorrectAnswer));
                }
            }

            return new Question(id, text, answers);
        }
    }
}
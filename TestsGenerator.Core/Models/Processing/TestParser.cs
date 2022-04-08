using System;
using System.Collections.Generic;
using System.Linq;
using FluentResults;
using TestsGenerator.Extensions;

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
                .Select(s => s.Trim())
                .Where(s => !s.IsNullOrEmpty())
                .ToArray();

            var text = lines
                .Where(line => !line.StartsWith(correctAnswerPrefix) && !line.StartsWith(wrongAnswerPrefix))
                .JoinStrings("\r\n");

            if (text.IsNullOrEmpty())
                text = "Вопрос без текста";

            foreach (var line in lines)
            {
                var isCorrectAnswer = line.StartsWith(correctAnswerPrefix);
                var isWrongAnswer = line.StartsWith(wrongAnswerPrefix);
                var lineIsQuestionText = !isCorrectAnswer && !isWrongAnswer;

                if (lineIsQuestionText)
                    continue;

                var answerText = line
                    .TrimStart(
                        isCorrectAnswer
                            ? correctAnswerPrefix
                            : wrongAnswerPrefix)
                    .TrimStart();

                answers.Add(new Answer(answerText, isCorrectAnswer));
            }

            return new Question(id, text, answers);
        }
    }
}
using System.Collections.Generic;

namespace TestsGenerator.Models
{
    public class Question
    {
        public string Text { get; }
        public IReadOnlyList<Answer> Answers { get; }
    }
}
using System.Collections.Generic;

namespace TestsGenerator.Models
{
    public class Question
    {
        public int Id { get; }
        public string Text { get; }
        public IReadOnlyList<Answer> Answers { get; }

        public Question(int id, string text, IReadOnlyList<Answer> answers)
        {
            Id = id;
            Text = text;
            Answers = answers;
        }
    }
}
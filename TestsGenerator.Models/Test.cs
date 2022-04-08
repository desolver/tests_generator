using System;
using System.Collections.Generic;

namespace TestsGenerator.Models
{
    public class Test
    {
        public Guid Id { get; }
        public string Name { get; }
        public IReadOnlyList<Question> Questions { get; }

        public Test(Guid id, string name, IReadOnlyList<Question> questions)
        {
            Questions = questions;
            Name = name;
            Id = id;
        }
    }
}
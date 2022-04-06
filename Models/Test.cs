using System;
using System.Collections.Generic;

namespace TestsGenerator.Models
{
    public class Test
    {
        public Guid Id { get; }
        public IReadOnlyList<Question> Questions { get; }

        public Test(Guid id, IReadOnlyList<Question> questions)
        {
            Questions = questions;
            Id = id;
        }
    }
}
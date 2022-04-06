using System;
using System.Collections.Generic;

namespace TestsGenerator.Models.DataLayer
{
    public interface ITestRepository
    {
        void Create(IReadOnlyList<Question> newTestQuestions);
        Test? FindById(Guid testId);
        IReadOnlyList<Test> GetAll();
    }
}
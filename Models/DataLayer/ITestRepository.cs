using System;
using System.Collections.Generic;

namespace TestsGenerator.Models.DataLayer
{
    public interface ITestRepository
    {
        Test Create(string name, IReadOnlyList<Question> newTestQuestions);
        Test? FindById(Guid testId);
        IReadOnlyList<Test> GetAll();
        void Delete(Guid testId);
    }
}
using System;
using System.Collections.Generic;
using TestsGenerator.Models;

namespace TestsGenerator.DataLayer
{
    public interface ITestRepository
    {
        Test Create(string name, IReadOnlyList<Question> newTestQuestions);
        Test? FindById(Guid testId);
        IReadOnlyList<Test> GetAll();
        void Delete(Guid testId);
    }
}
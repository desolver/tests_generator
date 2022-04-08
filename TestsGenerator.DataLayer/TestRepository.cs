using System;
using System.Collections.Generic;
using System.Linq;
using TestsGenerator.Models;

namespace TestsGenerator.DataLayer
{
    public class TestRepository : ITestRepository
    {
        private readonly IEntityRepository entityRepository;

        public TestRepository(IEntityRepository entityRepository)
        {
            this.entityRepository = entityRepository;
        }

        public Test Create(string name, IReadOnlyList<Question> newTestQuestions)
        {
            var newTest = new Test(Guid.NewGuid(), name, newTestQuestions);

            entityRepository.Insert(newTest.Id.ToString(), newTest);

            return newTest;
        }

        public Test? FindById(Guid testId)
            => entityRepository
                .GetAll<Test>()
                .FirstOrDefault(test => test.Id == testId);

        public IReadOnlyList<Test> GetAll() => entityRepository.GetAll<Test>();

        public void Delete(Guid testId) => entityRepository.Delete<Test>(testId.ToString());
    }
}
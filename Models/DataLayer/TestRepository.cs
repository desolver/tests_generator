using System;
using System.Collections.Generic;
using System.Linq;

namespace TestsGenerator.Models.DataLayer
{
    public class TestRepository : ITestRepository
    {
        private readonly IEntityRepository entityRepository;

        public TestRepository(IEntityRepository entityRepository)
        {
            this.entityRepository = entityRepository;
        }

        public void Create(IReadOnlyList<Question> newTestQuestions)
        {
            var newTest = new Test(Guid.NewGuid(), newTestQuestions);
            entityRepository.Insert(newTest.Id.ToString(), newTest);
        }

        public Test? FindById(Guid testId)
            => entityRepository
                .GetAll<Test>()
                .FirstOrDefault(test => test.Id == testId);

        public IReadOnlyList<Test> GetAll() => entityRepository.GetAll<Test>();
    }
}
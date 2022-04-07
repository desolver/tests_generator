using System.IO;
using FluentResults;
using TestsGenerator.Extensions;
using TestsGenerator.Models.DataLayer;
using TestsGenerator.Models.FileSystem;
using TestsGenerator.ViewModels;

namespace TestsGenerator.Models.Processing
{
    public class TestCreator : ITestCreator
    {
        private readonly ITestParser testParser;
        private readonly ITestRepository testRepository;

        public TestCreator(ITestParser testParser, ITestRepository testRepository)
        {
            this.testParser = testParser;
            this.testRepository = testRepository;
        }

        public Result<Test> TryCreateFromFile()
        {
            var filePath = FileChooser.Choose();
            if (filePath.IsNullOrEmpty())
                return Result.Fail(string.Empty);

            var fileContent = FileReader.ReadContent(filePath);
            if (fileContent.IsNullOrEmpty())
                return Result.Fail(string.Empty);

            var parseResult = testParser.TryParse(fileContent);
            if (parseResult.IsFailed)
                return parseResult.ToResult();

            var createdTest = testRepository.Create(Path.GetFileNameWithoutExtension(filePath), parseResult.Value);

            return Result.Ok(createdTest);
        }

        public Result<Test> TryCreateFromView(CreateTestViewModel createTestViewModel)
        {
            var createdTest = testRepository.Create(
                createTestViewModel.Name, createTestViewModel.Questions.MapToQuestionModel());

            return Result.Ok(createdTest);
        }
    }
}
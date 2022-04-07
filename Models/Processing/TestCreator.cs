using FluentResults;
using TestsGenerator.Extensions;
using TestsGenerator.Models.DataLayer;
using TestsGenerator.Models.FileSystem;

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
            var fileName = FileChooser.Choose();
            if (fileName.IsNullOrEmpty())
                return Result.Fail(string.Empty);

            var fileContent = FileReader.ReadContent(fileName);
            if (fileContent.IsNullOrEmpty())
                return Result.Fail(string.Empty);

            var parseResult = testParser.TryParse(fileContent);
            if (parseResult.IsFailed)
                return parseResult.ToResult();

            var createdTest = testRepository.Create(parseResult.Value);

            return Result.Ok(createdTest);
        }
    }
}
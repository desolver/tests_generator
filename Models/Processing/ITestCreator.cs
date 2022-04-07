using FluentResults;

namespace TestsGenerator.Models.Processing
{
    public interface ITestCreator
    {
        Result<Test> TryCreateFromFile();
    }
}
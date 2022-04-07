using FluentResults;
using TestsGenerator.ViewModels;

namespace TestsGenerator.Models.Processing
{
    public interface ITestCreator
    {
        Result<Test> TryCreateFromFile();
        Result<Test> TryCreateFromView(CreateTestViewModel createTestViewModel);
    }
}
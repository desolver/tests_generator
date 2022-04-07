using System.Collections.Generic;
using FluentResults;

namespace TestsGenerator.Models.Processing
{
    public interface ITestParser
    {
        Result<IReadOnlyList<Question>> TryParse(string fileContent);
    }
}
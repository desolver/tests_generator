using TestsGenerator.ViewModels;

namespace TestsGenerator.Extensions
{
    public static class PassingTestViewModelExtensions
    {
        public static PassingTestViewModel GoToNextQuestion(this PassingTestViewModel passingTestViewModel)
        {
            var nextQuestionIndex = passingTestViewModel.CurrentQuestionIndex + 1;
            var test = passingTestViewModel.Test;

            return new PassingTestViewModel(
                test,
                test.Questions[nextQuestionIndex].MapToQuestionViewModel(nextQuestionIndex));
        }
    }
}
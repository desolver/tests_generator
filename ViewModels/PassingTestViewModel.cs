using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using TestsGenerator.Models;
using TestsGenerator.ViewModels.Commands;

namespace TestsGenerator.ViewModels
{
    public class PassingTestViewModel : ViewModelBase
    {
        public Test Test { get; }

        private QuestionViewModel question;
        public QuestionViewModel Question
        {
            get => question;
            set => SetProperty(ref question, value);
        }

        public int QuestionsCount { get; }

        private int currentQuestionIndex;
        public int CurrentQuestionIndex
        {
            get => currentQuestionIndex;
            set => SetProperty(ref currentQuestionIndex, value);
        }

        private int progressPercent;
        public int ProgressPercent
        {
            get => progressPercent;
            set => SetProperty(ref progressPercent, value);
        }

        public PassingTestViewModel(Test test, QuestionViewModel question)
        {
            Test = test;
            Question = question;
            QuestionsCount = test.Questions.Count;
            CurrentQuestionIndex = question.Index;
            ProgressPercent = (int) (currentQuestionIndex / (float) (QuestionsCount - 1) * 100);
        }

        public static RelayCommand CheckAnswers => new(
            obj =>
            {
                if (obj is ItemCollection answers)
                    AnswersCheckButtonPressed?.Invoke(answers.Cast<AnswerViewModel>().ToArray());
            }, o => o is ItemCollection answers
                    && answers
                        .Cast<AnswerViewModel>()
                        .Any(c => c.IsUserChecked));

        public static RelayCommand GoToNextAnswer => new(
            obj =>
            {
                if (obj is PassingTestViewModel testViewModel)
                    NextAnswerButtonPressed?.Invoke(testViewModel);
            },
            obj => obj is PassingTestViewModel passingTestViewModel
                   && passingTestViewModel.currentQuestionIndex < passingTestViewModel.QuestionsCount - 1);

        public delegate void GoToNextAnswerHandler(PassingTestViewModel testViewModel);
        public static event GoToNextAnswerHandler NextAnswerButtonPressed;

        public delegate void CheckAnswersHandler(AnswerViewModel[] answers);
        public static event CheckAnswersHandler AnswersCheckButtonPressed;
    }
}
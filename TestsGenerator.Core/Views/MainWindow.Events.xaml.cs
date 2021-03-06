using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;
using TestsGenerator.Extensions;
using TestsGenerator.Models;
using TestsGenerator.Utilities;
using TestsGenerator.ViewModels;

namespace TestsGenerator.Views
{
    public partial class MainWindow
    {
        private void OnCollapseButtonPressed(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        private void OnExitButtonPressed(object sender, RoutedEventArgs e) => Environment.Exit(0);

        private void OnMouseLeftButtonDownOnOptionsPanel(object sender, MouseButtonEventArgs e) => DragMove();

        private void OnOpenFileButtonPressed(object sender, RoutedEventArgs routedEventArgs) => ViewModel.CreateTestFromFile();

        private void OnQuestionDialogClosed(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is not CreateQuestionViewModel newQuestion
                || newQuestion.Text.IsNullOrEmpty()
                || NewAnswersListBox.Items.Count == 0
                || NewQuestionsListBox.DataContext is not CreateTestViewModel newTest)
                return;

            newTest.Questions.Add(new CreateQuestionViewModel
            {
                Text = newQuestion.Text,
                Answers = NewAnswersListBox.Items.Cast<CreateAnswerViewModel>().ToList()
            });

            newQuestion.Text = default;
            NewAnswersListBox.Items.Clear();
        }

        private void OnAnswerDialogClosed(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is not CreateAnswerViewModel newAnswer || newAnswer.Text.IsNullOrEmpty())
                return;

            NewAnswersListBox.Items.Add(newAnswer.Copy());

            newAnswer.Clear();
        }

        private void OnTestSelected(object sender, RoutedEventArgs e)
        {
            if (e is not SelectionChangedEventArgs eventArgs
                || eventArgs.AddedItems.Count == 0
                || eventArgs.AddedItems[0] is not Test test
                || test.Questions.Count == 0)
                return;

            TestPopup.IsOpen = true;

            var randomizedTest = TestQuestionsRandomizer.Randomize(test);
            SetTestPopupDataContext(new PassingTestViewModel(
                randomizedTest, randomizedTest.Questions[0].MapToQuestionViewModel(0)));

            TestList.UnselectAll();
        }

        private void SetTestPopupDataContext(PassingTestViewModel passingTestViewModel)
            => TestPopup.DataContext = passingTestViewModel;

        private void OnCloseTestPopupButtonPressed(object sender, RoutedEventArgs e) => TestPopup.IsOpen = false;

        private void BindTestPopupEvents()
        {
            LocationChanged += (_, _) => 
            {
                var offset = TestPopup.HorizontalOffset;
                TestPopup.HorizontalOffset = offset + 1;
                TestPopup.HorizontalOffset = offset;
            };

            PassingTestViewModel.AnswersCheckButtonPressed += answers =>
            {
                var incorrectAnswers = AnswersChecker.GetIncorrectAnswers(answers);
                foreach (var answer in incorrectAnswers)
                    answer.ViewColor = ColorHelper.WRONG_ANSWER_COLOR;

                foreach (var answer in answers.Where(a => !incorrectAnswers.Contains(a) && a.IsCorrect))
                    answer.ViewColor = ColorHelper.CORRECT_ANSWER_COLOR;

                foreach (var answer in answers)
                    answer.Enabled = false;
            };

            PassingTestViewModel.NextAnswerButtonPressed += model => SetTestPopupDataContext(model.GoToNextQuestion());
        }

        private void BindInfoPopupEvents()
        {
            LocationChanged += (_, _) => 
            {
                var offset = InfoPopup.HorizontalOffset;
                InfoPopup.HorizontalOffset = offset + 1;
                InfoPopup.HorizontalOffset = offset;
            };
        }

        private void OnDeleteTestButtonPressed(object sender, RoutedEventArgs e)
        {
            if (sender is not Button { Tag: Guid testId })
                return;

            ViewModel.DeleteTest(testId);
        }

        private void OnInfoButtonPressed(object sender, RoutedEventArgs e) => InfoPopup.IsOpen = !InfoPopup.IsOpen;

        private void OnCloseInfoPopupButtonPressed(object sender, RoutedEventArgs e) => InfoPopup.IsOpen = false;
    }
}
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;
using TestsGenerator.Extensions;
using TestsGenerator.Utilities;
using TestsGenerator.ViewModels;
using TestsGenerator.ViewModels.Factory;

namespace TestsGenerator.Views
{
    public partial class MainWindow : Window
    {
        private MainWindowViewModel ViewModel { get; }
        
        public MainWindow()
        {
            InitializeComponent();

            ViewModel = ProjectServicesProvider
                .Provide()
                .GetService<IMainWindowViewModelFactory>()!
                .Create();

            DataContext = ViewModel;
        }

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
            
        }
    }
}
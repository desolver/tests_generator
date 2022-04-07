using System;
using System.Windows;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
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

        private void OnOpenFileButtonPressed(object sender, RoutedEventArgs routedEventArgs) => ViewModel.ProcessFileOpen();
    }
}
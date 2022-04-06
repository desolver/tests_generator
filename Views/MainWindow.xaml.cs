using System;
using System.Windows;

namespace TestsGenerator.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnCollapseButtonClick(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        private void OnExitButtonClick(object sender, RoutedEventArgs e) => Environment.Exit(0);
    }
}
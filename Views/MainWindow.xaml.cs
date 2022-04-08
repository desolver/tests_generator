using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using TestsGenerator.Models.Factory;
using TestsGenerator.Utilities;
using TestsGenerator.ViewModels;

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

            BindTestPopupEvents();
        }
    }
}
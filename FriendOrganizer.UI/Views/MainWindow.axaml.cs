using Avalonia.Controls;
using Avalonia.Interactivity;
using FriendOrganizer.UI.ViewModels;


namespace FriendOrganizer.UI.Views
{
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }
    }
}
using Avalonia.Controls;
using FriendOrganizer.UI.ViewModels;

namespace FriendOrganizer.UI.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            viewModel.Load();
        }
    }
}
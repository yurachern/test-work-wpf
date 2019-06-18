using System.Windows;
using TestWork.ViewModel;

namespace TestWork
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();           
            this.DataContext = new MainViewModel(this);
        }
    }
}

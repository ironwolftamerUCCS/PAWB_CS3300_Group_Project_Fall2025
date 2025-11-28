using PAWB.WPF.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PAWB.WPF.Views;

namespace PAWB.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<InfoItem> Items { get; set; }

        public MainWindow(object dataContext)
        {
            InitializeComponent();
            DataContext = dataContext;
            
        }

       /*
        private void DetailButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            InfoItem item = btn.DataContext as InfoItem;

            DetailWindow window = new DetailWindow(item);
            window.ShowDialog();
        }
        */
    }
}
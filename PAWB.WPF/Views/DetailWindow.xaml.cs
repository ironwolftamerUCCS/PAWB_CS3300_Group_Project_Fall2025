using PAWB.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PAWB.WPF.Views;

namespace PAWB.WPF.Views
{
    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="item"></param>
        public DetailWindow(InfoItem item)
        {
            InitializeComponent();
            DataContext = item;
            
        }
    }
}

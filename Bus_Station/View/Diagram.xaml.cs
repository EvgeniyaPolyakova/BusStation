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
using Bus_Station.ViewModel;
using LiveCharts;
using LiveCharts.Wpf;

namespace Bus_Station.View
{
    /// <summary>
    /// Логика взаимодействия для Diagram.xaml
    /// </summary>
    public partial class Diagram : Window
    {
        public Diagram()
        {
            InitializeComponent();
            //Chart.Children.Clear();

            //var usc = new UserControl();

            DataContext = new DiagramViewModel();
            //Chart.Children.Add(usc);
        }
    }
}

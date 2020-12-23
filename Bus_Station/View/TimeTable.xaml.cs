using Bus_Station.ViewModel;
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

namespace Bus_Station
{
    /// <summary>
    /// Логика взаимодействия для TimeTable.xaml
    /// </summary>
    public partial class TimeTable : Window
    {
        public TimeTable()
        {
            InitializeComponent();
            /*var tb = new TimeTableViewModel();
            DataContext = tb;
            var c = grid.DataContext;*/
            DataContext = new TimeTableViewModel();
        }
    }
}

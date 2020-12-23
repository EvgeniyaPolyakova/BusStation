using Bus_Station.Models;
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

namespace Bus_Station.View
{
    /// <summary>
    /// Логика взаимодействия для DetailRouteView.xaml
    /// </summary>
    public partial class DetailRouteView : Window
    {
        public delegate void CreateHandler(TimeTableModel timeTableModel);
        public event CreateHandler UpdateItemTimeTable;
        DetailRouteViewModel detail;

        public DetailRouteView(TimeTableModel route)
        {
            InitializeComponent();
            detail = new DetailRouteViewModel(route);
            DataContext = detail;
        }

        public void DefineEvent ()
        {
            detail.UpdateItemTimeTable += UpdateItemTimeTable;
        }
    }
}

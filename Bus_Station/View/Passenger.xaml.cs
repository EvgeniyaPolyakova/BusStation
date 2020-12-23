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

namespace Bus_Station
{
    /// <summary>
    /// Логика взаимодействия для Passenger.xaml
    /// </summary>
    public partial class Passenger : Window
    {
        public delegate void CreatePassanger(PassangerModel passanger);
        public event CreatePassanger AddPassanger;
        PassengerViewModel passengerViewModel;
        public Passenger()
        {
            InitializeComponent();
            passengerViewModel = new PassengerViewModel();
            DataContext = passengerViewModel;
        }

        public void DefineEvent()
        {
            passengerViewModel.AddPassanger += AddPassanger;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Arrange_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}

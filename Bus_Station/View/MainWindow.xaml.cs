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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bus_Station
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool User;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private RelayCommand cashierButton;
        public RelayCommand CashierButton
        {
            get
            {
                return cashierButton ??
                    (cashierButton = new RelayCommand(obj =>
                    {
                        PasswordWindow passwordWindow = new PasswordWindow();
                        passwordWindow.ShowDialog();
                    }));
            }
        }

        private void CashierButton_Click(object sender, RoutedEventArgs e)
        {
            /*PasswordWindow passwordWindow = new PasswordWindow();
            passwordWindow.ShowDialog();
            this.Close();
            /*Button clickedbutton = sender as Button;
            if (clickedbutton.Name == "CashierButton")
                User = true;
            else User = false;*/
        }

      

        private void LeaderButton_Click(object sender, RoutedEventArgs e)
        {
            /*PasswordWindow passwordWindow = new PasswordWindow();
            passwordWindow.ShowDialog();*/
            //Choice choice = new Choice();
            //choice.Show();
            //this.Close();
        }
    }
}

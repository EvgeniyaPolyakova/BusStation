﻿using System;
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
    /// Логика взаимодействия для PasswordWindow.xaml
    /// </summary>
    public partial class PasswordWindow : Window
    {
        public PasswordWindow()
        {
            InitializeComponent();
        }

        private void InputButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Авторизация пройдена!");
            MainWindow mainWindow = new MainWindow();

            //FindTicket findTicket = new FindTicket();
            //findTicket.Show();

            Report report = new Report();
            report.Show();

            this.Close();
        }


    }
}
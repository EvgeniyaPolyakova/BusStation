using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Bus_Station
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {

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

        private RelayCommand administratorButton;
        public RelayCommand AdministratorButton
        {
            get
            {
                return administratorButton ??
                    (administratorButton = new RelayCommand(obj =>
                    {
                        PasswordWindow passwordWindow = new PasswordWindow();
                        passwordWindow.ShowDialog();
                    }));
            }
        }
    }
}

using Bus_Station.Auth;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Bus_Station
{
    public class MainWindowViewModel : IRequireViewIdentification
    {
        public MainWindowViewModel()
        {
            _viewId = Guid.NewGuid();
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
                        WindowManager.CloseWindow(ViewID);
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
                        WindowManager.CloseWindow(ViewID);
                    }));
            }
        }

        private Guid _viewId;
        public Guid ViewID
        {
            get { return _viewId; }
        }
    }
}

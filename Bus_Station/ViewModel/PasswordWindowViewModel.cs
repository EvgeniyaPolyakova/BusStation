using Bus_Station.Auth;
using Bus_Station.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Station.ViewModel
{
    class PasswordWindowViewModel : IRequireViewIdentification, INotifyPropertyChanged
    {
        public string Login { get; set; }
        public string Password { get; set; }
        private string message;

        public PasswordWindowViewModel()
        {
            _viewId = Guid.NewGuid();
        }

        private Guid _viewId;
        public Guid ViewID
        {
            get { return _viewId; }
        }

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                this.message = value;
                OnPropertyChanged("Message");
            }
        }

        private RelayCommand auth;
        public RelayCommand Auth
        {
            get
            {
                return auth ??
                    (auth = new RelayCommand(obj =>
                    {
                        switch (Login)
                        {
                            case "cashier":
                                {
                                    new FindTicket().Show();
                                    WindowManager.CloseWindow(ViewID);
                                    break;
                                }
                            case "admin":
                                {
                                    new Choice().Show();
                                    WindowManager.CloseWindow(ViewID);
                                    break;
                                }
                            default:
                                {
                                    Message = "Введите логин и пароль";
                                }
                                break;
                        }
                    }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

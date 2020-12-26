using Bus_Station.Auth;
using Bus_Station.DAL;
using Bus_Station.Models;
using Bus_Station.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Bus_Station.ViewModel
{
    public class PassengerViewModel : INotifyPropertyChanged, IRequireViewIdentification, IDataErrorInfo
    {
        private string fio;
        private DateTime dateOfBirth;
        private int passportSeries;
        private int passportNumber;
        BusStationContext db;

        private string message;

        public event Passenger.CreatePassanger AddPassanger;

        public PassengerViewModel()
        {
            _viewId = Guid.NewGuid();
            db = new BusStationContext();
            Fio = "";

            DateOfBirth = new DateTime(1980, 1, 1);
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


        public string Fio
        {
            get
            {
                return this.fio;
            }
            set
            {
                this.fio = value;
                OnPropertyChanged("Fio");
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }
            set
            {
                this.dateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }

        public int PassportSeries
        {
            get
            {
                return this.passportSeries;
            }
            set
            {
                this.passportSeries = value;
                OnPropertyChanged("PassportSeries");
            }
        }

        public int PassportNumber
        {
            get
            {
                return this.passportNumber;
            }
            set
            {
                this.passportNumber = value;
                OnPropertyChanged("PassportNumber");
            }
        }

        private RelayCommand arrange;
        public RelayCommand Arrange
        {
            get
            {
                return arrange ??
                    (arrange = new RelayCommand(obj =>
                    {
                        try
                        {
                            var passanger = new PassangerModel()
                            {
                                FIO = Fio,
                                DateOfBirthday = dateOfBirth,
                                PassportSeries = passportSeries,
                                PassportNumber = passportNumber
                            };

                            AddPassanger(passanger);

                            Fio = "";
                            DateOfBirth = new DateTime(1980, 1, 1);
                            PassportNumber = default(int);
                            PassportSeries = default(int);

                            Message mes = new Message();
                            mes.Show();
                        }
                        catch (Exception e)
                        {
                            Message = "Введите данные";
                        }

                    },
                    (obj) => (Fio != "")));
            }
        }

       

        private RelayCommand closeWindow;
        public RelayCommand CloseWindow
        {
            get
            {
                return closeWindow ??
                    (closeWindow = new RelayCommand(obj =>
                    {
                        WindowManager.CloseWindow(ViewID);
                    }));
            }
        }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "PassportSeries":
                        try
                        {
                            Convert.ToInt32(PassportSeries);
                            if (PassportSeries <= 0)
                            {
                                error = "Недопустимое значение";
                            }
                        }

                        catch (Exception)
                        {
                            error = "Поле дожно содержать только цифры";
                        }
                        break;
                    case "PassportNumber":
                        try
                        {
                            Convert.ToInt32(PassportNumber);
                            if (PassportNumber <= 0)
                            {
                                error = "Недопустимое значение";
                            }
                        }

                        catch (Exception)
                        {
                            error = "Поле дожно содержать только цифры";
                        }
                        break;
                }
                return error;
            }
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

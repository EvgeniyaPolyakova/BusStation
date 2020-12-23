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
    public class PassengerViewModel : INotifyPropertyChanged, IRequireViewIdentification
    {
        private string fio;
        private DateTime dateOfBirth;
        private int passportSeries;
        private int passportNumber;
        BusStationContext db;

        public event Passenger.CreatePassanger AddPassanger;

        public PassengerViewModel()
        {
            _viewId = Guid.NewGuid();
            db = new BusStationContext();

            DateOfBirth = new DateTime(1980, 1, 1);
        }

        private Guid _viewId;
        public Guid ViewID
        {
            get { return _viewId; }
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

                    }));
            }
        }

       

        private RelayCommand back;
        public RelayCommand Back
        {
            get
            {
                return back ??
                    (back = new RelayCommand(obj =>
                    {

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

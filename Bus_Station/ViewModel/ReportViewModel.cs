using Bus_Station.DAL;
using Bus_Station.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Station.ViewModel
{
    public class ReportViewModel : INotifyPropertyChanged
    {

        private List<Point> startCities;
        private ObservableCollection<Point> endCities;
        private ObservableCollection<Point> endStations;
        private Point selectEndCity;
        private Point selectStartCity;

        BusStationContext db;

        public ReportViewModel()
        {
            db = new BusStationContext();
        }

        public List<Point> StartCities
        {
            get
            {
                return this.startCities;
            }
            set
            {
                this.startCities = value;
                OnPropertyChanged("StartCities");
            }
        }

        public ObservableCollection<Point> EndCities
        {
            get
            {
                return this.endCities;
            }
            set
            {
                this.endCities = value;
                OnPropertyChanged("EndCities");
            }
        }

        public Point SelectEndCity
        {
            get
            {
                return this.selectEndCity;
            }
            set
            {
                this.selectEndCity = value;
                OnPropertyChanged("SelectEndCity");
            }
        }

        public Point SelectStartCity
        {
            get
            {
                return this.selectStartCity;
            }
            set
            {
                this.selectStartCity = value;
                OnPropertyChanged("SelectStartCity");
                OnPropertyChanged("EndCities");
            }
        }

        public ObservableCollection<Point> EndStations
        {
            get
            {
                return this.endStations;
            }
            set
            {
                this.endStations = value;
                OnPropertyChanged("EndStations");
            }
        }
        
        private RelayCommand report;
        public RelayCommand Report
        {
            get
            {
                return report ??
                    (report = new RelayCommand(obj =>
                    {
                        //var opportunityFromRoute = db.Route.Where(i => i.Departure_place == SelectStartCity.Name && i.Arrival_place == SelectEndCity.Name).ToList();
                        //var opportunityFromRouteStation = db.Route_Station.Where(i => i.Route.Departure_place == SelectStartCity.Name && i.Station.Name == SelectEndCity.Name).ToList();

                        //foreach (var item in opportunityFromRoute)
                        //{
                        //    foreach (var possible in db.Route.Trip_Route.Where(i => i.IdRoute_FK == item.IdRoute).FirstOrDefault().Trip.Departure_time)
                        //    {
                        //            AvailableTrips.Add(new AvailableCity()
                        //            {
                        //                IdTrip = trip.IdTrip_FK,
                        //                Time = trip.Trip.Departure_time,
                        //                Cost = item.Cost.ToString()
                        //            });
                        //    }
                        //    //AvailableTrips.Add(new AvailableCity() {
                        //    //    Time = item.Trip_Route.Where(i => i.IdRoute_FK == item.IdRoute).FirstOrDefault().Trip.Departure_time,
                        //    //    Cost = item.Cost.ToString()
                        //    //});
                        //}

                        //foreach (var item in opportunityFromRouteStation)
                        //{
                        //    var listTrips = selectedDate == DateTime.Today ? item.Route.Trip_Route.Where(i => i.IdRoute_FK == item.Route.IdRoute && i.Trip.Departure_time >= DateTime.Now.TimeOfDay).ToList() : item.Route.Trip_Route.Where(i => i.IdRoute_FK == item.Route.IdRoute).ToList();
                        //    foreach (var trip in listTrips)
                        //    {
                        //        var countPassangers = db.Route.Where(i => i.IdRoute == selectStartCity.Id).FirstOrDefault()
                        //                        .Trip_Route.Join(db.Trip, tr => tr.IdTrip_FK, t => t.IdTrip, (tr, t) => new { tr = tr, t = t })
                        //                        .Join(db.Ticket, t => t.t.IdTrip, tic => tic.IdTrip_FK, (t, tic) => new { t = t, tic = tic })
                        //                        .Where(i => i.tic.Departure_date.Date == DepartureDate.Date && i.t.t.IdTrip == trip.IdTrip_FK)
                        //                        .Count();

                        //        var countPlacesAtTheBus = db.Trip.Where(j => j.IdTrip == trip.IdTrip_FK).FirstOrDefault().Bus.Seats;

                        //        if (countPlacesAtTheBus - countPassangers >= PassengerNumber)
                        //        {
                        //            AvailableTrips.Add(new AvailableCity()
                        //            {
                        //                IdTrip = trip.IdTrip_FK,
                        //                Time = trip.Trip.Departure_time,
                        //                Cost = item.Cost.Cost1.ToString()
                        //            });
                        //        }
                        //    }
                        //    //AvailableTrips.Add(new AvailableCity()
                        //    //{
                        //    //    Time = item.Route.Trip_Route.Where(i => i.IdRoute_FK == item.Route.IdRoute).FirstOrDefault().Trip.Departure_time,
                        //    //    Cost = item.Cost.Cost1.ToString()
                        //    //});
                        //    var sort = AvailableTrips.OrderBy(i => i.Time).ToList();
                        //    AvailableTrips.Clear();
                        //    foreach (var trip in sort)
                        //    {
                        //        AvailableTrips.Add(new AvailableCity()
                        //        {
                        //            IdTrip = trip.IdTrip,
                        //            Time = trip.Time,
                        //            Cost = trip.Cost
                        //        });
                        //    }

                        //    SelectedTrip = AvailableTrips.Count > 0 ? AvailableTrips[0] : null;
                        //}
                    }));
            }
        }

        private RelayCommand diagram;
        public RelayCommand Diagram
        {
            get
            {
                return diagram ??
                    (diagram = new RelayCommand(obj =>
                    {
                        var diagramView = new Diagram();
                        diagramView.Show();
                    }));
            }
        }

        private RelayCommand print;
        public RelayCommand Print
        {
            get
            {
                return print ??
                    (print = new RelayCommand(obj =>
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

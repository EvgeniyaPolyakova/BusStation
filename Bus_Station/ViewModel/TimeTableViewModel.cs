using Bus_Station.DAL;
using Bus_Station.Models;
using Bus_Station.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using static Bus_Station.ViewModel.DetailRouteViewModel;

namespace Bus_Station.ViewModel
{
    public class TimeTableViewModel : INotifyPropertyChanged
    {
        //private ObservableCollection<Trips> trips;
        private ObservableCollection<TimeTableModel> trips;
        private List<Point> startCities;
        private ObservableCollection<Point> endCities;
        private ObservableCollection<Point> endStations;
        private Point selectEndCity;
        private Point selectStartCity;
        private ObservableCollection<Stop> stops;
        private ObservableCollection<TimeSpan> times;
        private List<string> cities;
        //private string selectEndCity;
        //private string selectStartCity;
        private Decimal cost;
        //private string travelTime;
        private string costStop;
        private string nameStop;
        //private string timeTravelStop;
        private DateTime time;
        BusStationContext db;

        public TimeTableViewModel()
        {
            //var db = new BusStationContext();
            //Route route = new Route();

            startCities = new List<Point>();
            endCities = new ObservableCollection<Point>();
            endStations = new ObservableCollection<Point>();
            trips = new ObservableCollection<TimeTableModel>();
            db = new BusStationContext();
            foreach (var route in db.Route.ToList().Select(i => new TimeTableModel(i)).ToList())
            {
                trips.Add(route);
            }

            var allCities = db.Route.ToList();
            foreach (var city in allCities)
            {
                startCities.Add(new Point()
                {
                    Id = city.IdRoute,
                    Name = city.Departure_place,
                    isCity = true
                });

                endCities.Add(new Point()
                {
                    Id = city.IdRoute,
                    Name = city.Arrival_place,
                    isCity = true,
                    DepPlace = city.Departure_place
                });
            }

            var allStation = db.Route_Station.ToList();

            foreach (var start in startCities)
            {
                foreach (var station in allStation)
                {
                    if (start.Name == station.Route.Departure_place)
                    {
                        endCities.Add(new Point()
                        {
                            Id = station.IdRoute_FK,
                            Name = station.Station.Name,
                            isCity = false,
                            DepPlace = station.Route.Departure_place
                        });
                    }
                }

            }

            startCities = startCities.Distinct(new CityComparer()).ToList();
            SelectStartCity = startCities[0];
            SelectEndCity = EndCities[0];

            /*cities = new List<string>()
                {
                    "Шуя", "Иваново", "Москва"
                };*/
            stops = new ObservableCollection<Stop>();
            times = new ObservableCollection<TimeSpan>();
        }

        public List<Point> StartCities
        {
            get
            {
                return this.startCities;
            }
        }

        public ObservableCollection<Point> EndCities
        {
            get
            {
                ObservableCollection<Point> endCities = new ObservableCollection<Point>();
                var cities = this.endCities.Where(i => i.Name != SelectStartCity.Name).ToList().Distinct(new CityComparer()).ToList();
                foreach (var item in cities)
                {
                    endCities.Add(item);
                }
                return endCities;
            }
        }

        public ObservableCollection<TimeTableModel> ListTrips
        {
            get
            {
                return this.trips;
            }
            set
            {
                this.trips = value;
                OnPropertyChanged("Trips");
            }
        }

        public ObservableCollection<Stop> Stops
        {
            get
            {
                return this.stops;
            }
        }


        public ObservableCollection<TimeSpan> Times
        {
            get
            {
                return this.times;
            }
        }

        public List<string> Cities
        {
            get
            {
                return this.cities;
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

        public Decimal Cost
        {
            get
            {
                return this.cost;
            }
            set
            {
                this.cost = value;
                OnPropertyChanged("Cost");
            }
        }

        /* public string TravelTime
         {
             get
             {
                 return this.travelTime;
             }
             set
             {
                 this.travelTime = value;
             }
         }*/

        public string NameStop
        {
            get
            {
                return this.nameStop;
            }
            set
            {
                this.nameStop = value;
                OnPropertyChanged("NameStop");
            }
        }

        public string CostStop
        {
            get
            {
                return this.costStop;
            }
            set
            {
                this.costStop = value;
                OnPropertyChanged("CostStop");
            }
        }


        public DateTime Time
        {
            get
            {
                return this.time;
            }
            set
            {
                this.time = value;
                OnPropertyChanged("Time");
            }
        }


        public class Trips
        {
            public string DepartureName { get; set; }
            public string ArrivalName { get; set; }
            public int Cost { get; set; }
            public List<TimeSpan> Times { get; set; }
            public TimeSpan Time { get; set; }
            public List<Stop> Stops { get; set; }
            public List<string> cities { get; set; }
        }

        public class Timecl
        {
            public string Time { get; set; }
        }

        private RelayCommand details;
        public RelayCommand Details
        {
            get
            {
                return details ??
                    (details = new RelayCommand(obj =>
                    {
                        var route = (TimeTableModel)obj;
                        var details = new DetailRouteView(route);
                        details.UpdateItemTimeTable += UpdateTable;
                        details.DefineEvent();
                        details.Show();

                        //вызвать окно для детального просмотра, а там уже есть возможность переключиться в режим редактирования
                        //textbox, list из остановок
                        //переключение на режим редактирования с возможность сброса изменений и с кнопкой сохранения
                    }));
            }
        }

        void UpdateTable(TimeTableModel timeTableModel)
        {
            var curTrip = ListTrips.Where(i => i.idRoute == timeTableModel.idRoute).FirstOrDefault();
            var idx = ListTrips.IndexOf(curTrip);
            ListTrips.Remove(curTrip);
            ListTrips.Insert(idx, timeTableModel);
        }

        private RelayCommand delete;
        public RelayCommand Delete
        {
            get
            {
                return delete ??
                    (delete = new RelayCommand(obj =>
                    {
                        TimeTableModel trip = obj as TimeTableModel;
                        if (trip != null)
                        {
                            trips.Remove(trip);
                        }
                    }));
            }
        }

        private RelayCommand createStop;
        public RelayCommand CreateStop
        {
            get
            {
                return createStop ??
                    (createStop = new RelayCommand(obj =>
                    {
                        var stop = new Stop()
                        {
                            Name = this.nameStop,
                            Cost = Convert.ToInt32(this.costStop),
                            //TravelTime = this.TimeTravelStop
                        };
                        this.stops.Add(stop);

                        //this.TimeTravelStop = "";
                        this.NameStop = "";
                        this.CostStop = "";
                    }));
            }
        }

        private RelayCommand createTime;
        public RelayCommand CreateTime
        {
            get
            {
                return createTime ??
                    (createTime = new RelayCommand(obj =>
                    {
                        this.times.Add(new TimeSpan(this.time.Hour, this.time.Minute, this.time.Second));

                        this.Time = default(DateTime);
                    }));
            }
        }

        private RelayCommand createRoute;
        public RelayCommand CreateRoute
        {
            get
            {
                return createRoute ??
                    (createRoute = new RelayCommand(obj =>
                    {
                        try
                        {

                            var times = new List<TimeSpan>();
                            foreach (var item in this.times)
                            {
                                times.Add(item);
                            }


                            var stops = new List<DetailRouteViewModel.Stop>();
                            stops.AddRange(this.stops.Select(i => new DetailRouteViewModel.Stop()
                            {
                                Name = i.Name,
                                Cost = i.Cost
                            }));

                            var route = new TimeTableModel()
                            {
                                DeparturePlace = Convert.ToString(selectStartCity),
                                ArrivalPlace = Convert.ToString(selectEndCity),
                                Cost = Convert.ToInt32(this.cost),
                                DepartureTime = times,
                                StopList = stops,
                            };

                            //ListTrips.Add(route);

                            stops.Clear();

                            foreach (var stopStation in route.StopList)
                            {
                                var isNotExistStation = db.Station.Where(i => i.Name == stopStation.Name).FirstOrDefault();

                                if (isNotExistStation == null)
                                {
                                    int maxIdSt = db.Station.OrderByDescending(i => i.IdStation).FirstOrDefault().IdStation;
                                    db.Station.Add(new Station()
                                    {
                                        IdStation = maxIdSt + 1,
                                        Name = stopStation.Name,
                                    });

                                    stops.Add(new Stop()
                                    {
                                        Id = maxIdSt + 1,
                                        Name = stopStation.Name,
                                        Cost = stopStation.Cost
                                    });
                                } else
                                {
                                    stops.Add(new Stop()
                                    {
                                        Id = isNotExistStation.IdStation,
                                        Name = isNotExistStation.Name,
                                        Cost = stopStation.Cost
                                    });
                                }


                                if (db.Cost.Where(i => i.Cost1 == stopStation.Cost).FirstOrDefault() == null)
                                {
                                    int maxIdCost = db.Cost.OrderByDescending(i => i.IdCost).FirstOrDefault().IdCost;
                                    db.Cost.Add(new Cost()
                                    {
                                        IdCost = maxIdCost + 1,
                                        Cost1 = stopStation.Cost,
                                    });
                                }
                            }

                            int maxIdRoute = db.Route.OrderByDescending(i => i.IdRoute).FirstOrDefault().IdRoute;
                            db.Route.Add(new Route()
                            {
                                IdRoute = maxIdRoute + 1,
                                Departure_place = route.DeparturePlace,
                                Arrival_place = route.ArrivalPlace,
                                Cost = route.Cost,
                            });
                            db.SaveChanges();

                            var idRoute = db.Route.OrderByDescending(i => i.IdRoute).FirstOrDefault().IdRoute;

                            var costs = db.Cost.ToList();
                            var idMaxRouteStation = db.Route_Station.OrderByDescending(i => i.IdRS).FirstOrDefault().IdRS;
                            foreach (var station in route.StopList)
                            {
                                db.Route_Station.Add(new Route_Station()
                                {
                                    IdRS = ++idMaxRouteStation,
                                    IdRoute_FK = idRoute,
                                    IdStation_Fk = db.Station.Where(i => i.Name == station.Name).FirstOrDefault().IdStation,
                                    IdCost_FK = db.Cost.Where(i => i.Cost1 == station.Cost).FirstOrDefault().IdCost
                                });
                            }

                            var idMaxTrip = db.Trip.OrderByDescending(i => i.IdTrip).FirstOrDefault().IdTrip;
                            foreach (var time in route.DepartureTime)
                            {
                                db.Trip.Add(new Trip()
                                {
                                    IdTrip = ++idMaxTrip,
                                    Departure_time = time,
                                    IdBus_FK = 9
                                });
                            }

                            var listIdTime = db.Trip_Route.OrderByDescending(i => i.IdTR).Take(route.DepartureTime.Count).Select(i => i.IdTR).ToList();
                            var idMaxTripRoute = db.Trip_Route.OrderByDescending(i => i.IdTR).FirstOrDefault().IdTR;
                            foreach (var idTime in listIdTime)
                            {
                                db.Trip_Route.Add(new Trip_Route()
                                {
                                    IdTR = ++idMaxTripRoute,
                                    IdRoute_FK = idRoute,
                                    IdTrip_FK = idTime
                                });
                            }

                            db.SaveChanges();


                            var newRoute = db.Route.Where(i => i.IdRoute == maxIdRoute).ToList().Select(i => new TimeTableModel(i)).ToList().FirstOrDefault();
                            ListTrips.Add(newRoute);


                            this.Cost = default(Decimal);
                            SelectStartCity = startCities[0];
                            SelectEndCity = EndCities[0];
                            Stops.Clear();
                            Times.Clear();

                        }
                        catch (Exception e)
                        {
                            var err = e.Message;
                            throw;
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

        class CityComparer : IEqualityComparer<Point>
        {
            // Products are equal if their names and product numbers are equal.
            public bool Equals(Point x, Point y)
            {

                //Check whether the compared objects reference the same data.
                if (Object.ReferenceEquals(x, y)) return true;

                //Check whether any of the compared objects is null.
                if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                    return false;

                //Check whether the products' properties are equal.
                return x.Name == y.Name;
            }

            // If Equals() returns true for a pair of objects
            // then GetHashCode() must return the same value for these objects.

            public int GetHashCode(Point city)
            {
                //Check whether the object is null
                if (Object.ReferenceEquals(city, null)) return 0;

                //Get hash code for the Name field if it is not null.
                int hashProductName = city.Name == null ? 0 : city.Name.GetHashCode();

                //Calculate the hash code for the product.
                return hashProductName;
            }
        }
    }
}

using Bus_Station.Auth;
using Bus_Station.DAL;
using Bus_Station.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Station.ViewModel
{
    public class DetailRouteViewModel : INotifyPropertyChanged, IRequireViewIdentification
    {
        int idRoute;

        private string nameDeparturePlace;
        private string nameArrivalPlace;
        private Decimal costRoute;
        private TimeSpan departureTimesRoute;
        private string name;
        private Decimal cost;
        private bool isEdit;
        ObservableCollection<TimeSpan> timesList;
        ObservableCollection<Stop> stopsList;
        //private ObservableCollection<Stop> stopsList;
        TimeSpan selectedTime;
        DateTime timeForCreate;
        private string nameStop;
        private Decimal costStop;
        BusStationContext db;

        public event View.DetailRouteView.CreateHandler UpdateItemTimeTable;

        public DetailRouteViewModel(TimeTableModel route)
        {
            _viewId = Guid.NewGuid();
            db = new BusStationContext();

            idRoute = route.idRoute;
            isEdit = false;
            NameDeparturePlace = route.DeparturePlace;
            NameArrivalPlace = route.ArrivalPlace;
            CostRoute = Convert.ToDecimal(route.Cost);

            timesList = new ObservableCollection<TimeSpan>();

            foreach (var item in route.DepartureTime.OrderBy(i => i))
            {
                timesList.Add(item);
            }

            selectedTime = timesList[0] == null ? default(TimeSpan) : timesList[0];

            stopsList = new ObservableCollection<Stop>();
            foreach (var item in route.StopList)
            {
                stopsList.Add(new Stop() {
                    Id = item.Id,
                    Name = item.Name,
                    Cost = item.Cost
                });
            }

        }

        public class Stop
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Decimal Cost { get; set; }
        }

        public bool IsEdit
        {
            get
            {
                return isEdit;
            }
            set
            {
                this.isEdit = value;
                OnPropertyChanged("IsEdit");
            }
        }

        private RelayCommand toggleEdit;
        public RelayCommand ToggleEdit
        {
            get
            {
                return toggleEdit ??
                    (toggleEdit = new RelayCommand(obj =>
                    {
                        IsEdit = !IsEdit;
                    }));
            }
        }

        private RelayCommand clear;
        public RelayCommand Clear
        {
            get
            {
                return clear ??
                    (clear = new RelayCommand(obj =>
                    {
                        this.NameDeparturePlace = "";
                        this.NameArrivalPlace = "";
                        this.CostRoute = default(Decimal);
                    }));
            }
        }
        
       /* private RelayCommand toggleEditDepartureTime;
        public RelayCommand ToggleEditDepartureTime
        {
            get
            {
                return toggleEditDepartureTime ??
                    (toggleEditDepartureTime = new RelayCommand(obj =>
                    {
                        IsEdit = !IsEdit;
                    }));
            }
        }*/

        public ObservableCollection<Stop> StopsList
        {
            get
            {
                return this.stopsList;
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
                        try
                        {
                            var stop = new Stop()
                            {
                                Name = this.nameStop,
                                Cost = Convert.ToDecimal(this.costStop),
                            };
                            this.stopsList.Add(stop);

                            this.NameStop = "";
                            this.CostStop = default(decimal);
                        }
                        catch
                        {
                           
                        }
                    },
                    (obj) => (NameStop != "" && Convert.ToDecimal(CostStop) > 0 && Convert.ToDecimal(CostStop) < CostRoute)));
            }
        }


        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                OnPropertyChanged("Name");
            }
        }

        public TimeSpan SelectedTime
        {
            get
            {
                return this.selectedTime;
            }
            set
            {
                this.selectedTime = value;
                OnPropertyChanged("SelectedTime");
            }
        }

        public DateTime TimeForCreate
        {
            get
            {
                return this.timeForCreate;
            }
            set
            {
                this.timeForCreate = value;
                OnPropertyChanged("TimeForCreate");
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

        public class Timecl
        {
            public string Time { get; set; }
        }

                   
        
        public string NameDeparturePlace
        {
            get
            {
                return this.nameDeparturePlace;
            }
            set
            {
                this.nameDeparturePlace = value;
                OnPropertyChanged("NameDeparturePlace");
            }
        }

        public string NameArrivalPlace
        {
            get
            {
                return this.nameArrivalPlace;
            }
            set
            {
                this.nameArrivalPlace = value;
                OnPropertyChanged("NameArrivalPlace");
            }
        }

        public Decimal CostRoute
        {
            get
            {
                return this.costRoute;
            }
            set
            {
                this.costRoute = value;
                OnPropertyChanged("CostRoute");
            }
        }

        public TimeSpan DepartureTimesRoute
        {
            get
            {
                return this.departureTimesRoute;
            }
            set
            {
                this.departureTimesRoute = value;
                OnPropertyChanged("DepartureTimesRoute");
            }
        }

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

        public Decimal CostStop
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

        public ObservableCollection<TimeSpan> TimesList
        {
            get
            {
                return this.timesList;
            }
            set
            {
                this.timesList = value;
                OnPropertyChanged("TimesList");
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
                        this.timesList.Add(new TimeSpan(this.timeForCreate.Hour, this.timeForCreate.Minute, this.timeForCreate.Second));
                        
                        this.TimeForCreate = default(DateTime);
                    }));
            }
        }

        private RelayCommand deleteTime;
        public RelayCommand DeleteTime
        {
            get
            {
                return deleteTime ??
                    (deleteTime = new RelayCommand(obj =>
                    {
                        this.timesList.Remove(selectedTime);
                        SelectedTime = timesList.Count == 0 ? default(TimeSpan) : timesList[0];
                    }));
            }
        }

        private RelayCommand deleteStop;
        public RelayCommand DeleteStop
        {
            get
            {
                return deleteStop ??
                    (deleteStop = new RelayCommand(obj =>
                    {
                        Stop stop = obj as Stop;
                        if (stop != null)
                        {
                            stopsList.Remove(stop);
                        }
                    }));
            }
        }

        private RelayCommand saveChange;
        public RelayCommand SaveChange
        {
            get
            {
                return saveChange ??
                    (saveChange = new RelayCommand(obj =>
                    {

                        var route = db.Route.Where(i => i.IdRoute == idRoute).FirstOrDefault();
                        route.Departure_place = NameDeparturePlace;
                        route.Arrival_place = NameArrivalPlace;
                        route.Cost = CostRoute;

                        db.Entry(route).State = EntityState.Modified;

                        var times = db.Trip_Route.Where(i => i.IdRoute_FK == idRoute).ToList();

                        List<int> doActive = new List<int>();
                        List<int> doInActive = new List<int>();

                        List<TimeSpan> timeForUpdate = new List<TimeSpan>(TimesList);
                        foreach (var timeFromDb in db.Trip_Route.Where(i => i.IdRoute_FK == idRoute).ToList())
                        {
                            var exist = timeForUpdate.Where(i => timeFromDb.Trip.Departure_time == i).FirstOrDefault();
                            if (exist != default(TimeSpan))
                            {
                                timeFromDb.isActive = 1;
                                timeForUpdate.Remove(timeForUpdate.Where(i => i == exist).FirstOrDefault());
                            }
                            else
                            {
                                timeFromDb.isActive = 0;
                            }
                            db.Entry(timeFromDb).State = EntityState.Modified;
                        }

                        int maxIdTrip = db.Trip.OrderByDescending(i => i.IdTrip).FirstOrDefault().IdTrip + 1;
                        int maxIdTripRoute = db.Trip_Route.OrderByDescending(i => i.IdTR).FirstOrDefault().IdTR + 1;

                        var allTimes = db.Trip.ToList();
                        foreach (var time in timeForUpdate)
                        {
                            var curTime = allTimes.Where(i => i.Departure_time == time).FirstOrDefault();

                            var trigger = false;
                            if (curTime == null)
                            {
                                db.Trip.Add(new Trip()
                                {
                                    IdTrip = maxIdTrip,
                                    Departure_time = time,
                                    IdBus_FK = 9
                                });
                                trigger = true;
                            }

                            db.Trip_Route.Add(new Trip_Route()
                            {
                                IdTR = trigger == true ? maxIdTripRoute++ : curTime.IdTrip,
                                IdRoute_FK =idRoute,
                                IdTrip_FK = maxIdTrip++
                            });
                        }

                        db.SaveChanges();


                        var timesForUpdate = new List<TimeSpan>();
                        foreach (var item in TimesList)
                        {
                            timesForUpdate.Add(item);
                        }
                        
                        List<int> doActiveStops = new List<int>();
                        List<int> doInActiveStops = new List<int>();

                        List<Stop> stopsForUpdate = new List<Stop>(StopsList);
                        foreach (var stopFromDb in db.Route_Station.Where(i => i.IdRoute_FK == idRoute).ToList())
                        {
                            var exist = stopsForUpdate.Where(i => stopFromDb.Station.Name == i.Name).FirstOrDefault();
                            if (exist != default(Stop))
                            {
                                stopFromDb.isActive = 1;
                                stopsForUpdate.Remove(stopsForUpdate.Where(i => i == exist).FirstOrDefault());
                            }
                            else
                            {
                                stopFromDb.isActive = 0;
                            }
                            db.Entry(stopFromDb).State = EntityState.Modified;
                        }

                        int maxIdStop = db.Station.OrderByDescending(i => i.IdStation).FirstOrDefault().IdStation + 1;
                        int maxIdStationRoute = db.Route_Station.OrderByDescending(i => i.IdRS).FirstOrDefault().IdRS + 1;

                        var allStops = db.Station.ToList();
                        foreach (var stop in stopsForUpdate)
                        {
                            var curStop = allStops.Where(i => i.Name == stop.Name).FirstOrDefault();

                            var trigger = false;
                            if (curStop == null)
                            {
                                db.Station.Add(new Station()
                                {
                                    IdStation = maxIdStop,
                                    Name = stop.Name,
                                });
                                trigger = true;
                            }

                            var idCost = db.Cost.Where(i => i.Cost1 == stop.Cost).FirstOrDefault() == null ? default(int) : db.Cost.Where(i => i.Cost1 == stop.Cost).FirstOrDefault().IdCost;
                            int maxIdCost = 0;
                            if (idCost == default(int))
                            {
                                maxIdCost = db.Cost.OrderByDescending(i => i.IdCost).FirstOrDefault().IdCost + 1;
                                db.Cost.Add(new DAL.Cost() {
                                    Cost1 = stop.Cost,
                                    IdCost = maxIdCost
                                });
                            }

                            db.Route_Station.Add(new Route_Station()
                            {
                                IdRS = trigger == true ? maxIdStationRoute++ : curStop.IdStation,
                                IdRoute_FK = idRoute,
                                IdStation_Fk = maxIdStop++,
                                IdCost_FK = idCost != default(int) ? idCost : maxIdCost
                            });
                        }

                        db.SaveChanges();


                        var stopsForUpdateInTable = new List<Stop>();
                        foreach (var item in StopsList)
                        {
                            stopsForUpdateInTable.Add(item);
                        }

                        UpdateItemTimeTable(new TimeTableModel()
                        {
                            idRoute = idRoute,
                            DeparturePlace = NameDeparturePlace,
                            ArrivalPlace = NameArrivalPlace,
                            Cost = CostRoute,
                            DepartureTime = timesForUpdate,
                            StopList = stopsForUpdateInTable
                        });
                    },
                    (obj) => (NameDeparturePlace != "" && NameArrivalPlace != "" && CostRoute != 0 && timesList.Count != 0)));
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

        private Guid _viewId;
        public Guid ViewID
        {
            get { return _viewId; }
        }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "CostRoute":
                        try
                        {
                            if (CostRoute <= 0)
                            {
                                error = "Стоимость должна быть положительная";
                            }
                        }

                        catch (Exception)
                        {
                            error = "Стоимость должна быть числом";
                        }
                        break;
                    case "CostStop":
                        try
                        {
                            if (Convert.ToDecimal(CostStop) >= CostRoute)
                            {
                                error = "Стоимость должна быть меньше стоимости маршрута";
                            }

                            if (Convert.ToDecimal(CostStop) <= 0)
                            {
                                error = "Стоимость должна быть положительная";
                            }
                        }

                        catch (Exception)
                        {
                            error = "Стоимость должна быть числом";
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

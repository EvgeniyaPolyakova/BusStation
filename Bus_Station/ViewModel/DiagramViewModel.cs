using Bus_Station.Auth;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Station.ViewModel
{
    public class DiagramViewModel : INotifyPropertyChanged, IRequireViewIdentification
    {

        public SeriesCollection Proceeds { get; set; }
        //public Func<string, string> yFornatter { get; set; }
        public string[] LabelsX { get; set; }
        int[] numMonths = new int[3];
        DAL.BusStationContext db;
        string[] months = new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        DateTime dateStart;
        DateTime dateEnd;

        public ColorsCollection ColorCollection { get; set; }

        int monthStart;
        int monthEnd;
        private Dictionary<string, List<float>> report;
        int startMonth = DateTime.Today.Month - 3;

        public DiagramViewModel()
        {
            dateStart = DateTime.Today;
            dateEnd= DateTime.Today;

            _viewId = Guid.NewGuid();
            db = new DAL.BusStationContext();
            
            ColorCollection = new ColorsCollection();


            var Random = new Random();
            for (int i = 0; i < db.Route.ToList().Count; i++)
            {
                var color = System.Windows.Media.Color.FromRgb(Convert.ToByte(Random.Next(255)), Convert.ToByte(Random.Next(255)), Convert.ToByte(Random.Next(255)));
                ColorCollection.Add(color);
            }

            LabelsX = new string[3];


            int count = 0;
            for (int i = startMonth; count < 3; i++)
            {
                if (i==12)
                {
                    i = 0;
                }
                LabelsX[count] = months[i];
                numMonths[count] = i;
                count++;
            }

            monthStart = numMonths[0];
            monthEnd = numMonths[2];
            CreateCharts();
        }

        void CreateCharts()
        {
            if (Proceeds == null)
            {
                Proceeds = new SeriesCollection();
            }
            Proceeds.Clear();


            foreach (var route in db.Route.ToList())
            {
                var rev1 = db.Route
                    .Join(db.Trip_Route, r => r.IdRoute, tr => tr.IdRoute_FK, (r, tr) => new { r = r, tr = tr })
                    .Join(db.Trip, tr => tr.tr.IdTrip_FK, t => t.IdTrip, (tr, t) => new { tr = tr, t = t })
                    .Join(db.Ticket, t => t.t.IdTrip, tic => tic.IdTrip_FK, (t, tic) => new { t = t, tic = tic })
                    .Where(i => i.tic.Departure_date >= DateStart
                        && i.tic.Departure_date <= DateEnd
                        && i.t.tr.r.IdRoute == route.IdRoute)
                    .Sum(i => i.t.tr.r.Cost);

                var rev2 = db.Route
                    .Join(db.Trip_Route, r => r.IdRoute, tr => tr.IdRoute_FK, (r, tr) => new { r = r, tr = tr })
                    .Join(db.Route_Station, r => r.r.IdRoute, s => s.IdRoute_FK, (r, s) => new { r = r, s = s })
                    .Join(db.Trip, r => r.r.tr.IdTrip_FK, t => t.IdTrip, (tr, t) => new { tr = tr, t = t })
                    .Join(db.Ticket, t => t.t.IdTrip, tic => tic.IdTrip_FK, (t, tic) => new { t = t, tic = tic })
                    .Where(i => i.tic.Departure_date >= DateStart
                        && i.tic.Departure_date <= DateEnd
                        && i.t.tr.r.r.IdRoute == route.IdRoute)
                    .Sum(i => db.Cost.Where(c => c.IdCost == i.t.tr.s.IdCost_FK).FirstOrDefault().Cost1);

                List<double> values = new List<double>();
                var result = rev1 + rev2;
                values.Add(Convert.ToDouble(result));
                Proceeds.Add(new PieSeries
                {
                    Title = route.Departure_place + " " + route.Arrival_place,
                    Values = new ChartValues<double>(values)
                });

            }
        }

        public DateTime DateStart
        {
            get
            {
                return dateStart;
            }
            set
            {
                dateStart = value;
                //OnPropertyChanged("DateStart");
                CreateCharts();
            }
        }

        public DateTime DateEnd
        {
            get
            {
                return dateEnd;
            }
            set
            {
                dateEnd = value;
                //OnPropertyChanged("DateEnd");
                CreateCharts();
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

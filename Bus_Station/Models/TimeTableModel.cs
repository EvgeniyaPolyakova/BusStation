using Bus_Station.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bus_Station.DAL;
using static Bus_Station.ViewModel.DetailRouteViewModel;

namespace Bus_Station.Models
{
    public class TimeTableModel
    {
        public int idRoute { get; set; }
        public string DeparturePlace { get; set; }
        public string ArrivalPlace { get; set; }
        public Decimal Cost { get; set; }
        public List<TimeSpan> DepartureTime { get; set; }
        public List<Stop> StopList { get; set; }

        public TimeTableModel() { }
        public TimeTableModel(Route route)
        {
            idRoute = route.IdRoute;
            DeparturePlace = route.Departure_place;
            ArrivalPlace = route.Arrival_place;
            Cost = Convert.ToDecimal(route.Cost);
            DepartureTime = route.Trip_Route.Where(i => i.IdRoute_FK == route.IdRoute && i.isActive == 1).Select(j => j.Trip.Departure_time).ToList();
            StopList = route.Route_Station.Select(i => new Stop()
            {
                Id = Convert.ToInt32(i.IdCost_FK),
                Name = i.Station.Name,
                Cost = Convert.ToDecimal(i.Cost.Cost1),
            }).ToList();
        }
    }
}



        /*public static List<ListStation> GetListStations()
        {
            var db = new BusStationContext();
            var stop = db.Route_Station
                .Join(db.Route, r => r.IdRoute_FK, t => t.IdRoute, (r, t) => new { IdRoute_FK = t.IdRoute, })
                .Join(db.Station, r => r.IdRoute_FK, s => s.IdStation, (r, s) => new { IdStation_FK = s.IdStation, })
                //.Where(r => r.IdRoute_FK )
                //.Select (i => new ListStation() { StationName = i.Name })
                .ToList();
            //return stop;
            
        }*/

using Bus_Station.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bus_Station.View;
using static Bus_Station.ViewModel.FindTicketViewModel;

namespace Bus_Station.Models
{
    public class FindTicketModel
    {
        public string StartCities { get; set; }
        public string EndCities { get; set; }
        public List<string> EndStations { get; set; }

        public FindTicketModel() { }
        public FindTicketModel(Route route)
        {
            StartCities = route.Departure_place;

            EndCities = route.Arrival_place;
            EndStations = route.Route_Station.Where(i => i.IdRoute_FK == route.IdRoute).Select(j => j.Station.Name).ToList();
        }
            
    }
}

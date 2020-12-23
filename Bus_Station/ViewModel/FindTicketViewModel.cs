using Bus_Station.Auth;
using Bus_Station.DAL;
using Bus_Station.Models;
using Bus_Station.View;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;

namespace Bus_Station.ViewModel
{
    public class Point
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DepPlace { get; set; }
        public bool isCity { get; set; }
    }

    public class AvailableCity
    {
        public int IdTrip { get; set; }
        public string Cost { get; set; }
        public TimeSpan Time { get; set; }
    }
    public class FindTicketViewModel : INotifyPropertyChanged, IRequireViewIdentification
    {
        ObservableCollection<AvailableCity> availableTrips;
        private List<Point> startCities;
        private ObservableCollection<Point> endCities;
        private ObservableCollection<Point> endStations;
        private Point selectEndCity;
        private Point selectStartCity;
        private DateTime departureDate;
        private int passengerNumber;

        private List<PassangerModel> passangers;
        private AvailableCity selectedTrip;

        private int countCurrentPassangerAtBus = 0;
        BusStationContext db;

        Passenger passangerView;
        public int countFillingQuestionnaire = 0;
        public FindTicketViewModel()
        {
            availableTrips = new ObservableCollection<AvailableCity>();
            _viewId = Guid.NewGuid();
            startCities = new List<Point>();
            endCities = new ObservableCollection<Point>();
            endStations = new ObservableCollection<Point>();

            passangers = new List<PassangerModel>();
            db = new BusStationContext();
            var allCities = db.Route.ToList();
            int ind = 0;
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


            //foreach (var cities in db.Route.ToList().Select(i => new FindTicketModel(i)).ToList())
            //{
            //    startCities.Add(cities);
            //}

            //.Join(db.Route_Station, r => r.IdRoute, rs => rs.IdRS, (r, rs) => new { route = r, routeStation = rs })
            //.Join(db.Station, rs => rs.routeStation.IdStation_Fk, s => s.IdStation, (rs, s) => new { rs = rs, stations = s })
            //.GroupBy(s => s.stations.Name)

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
            DepartureDate = DateTime.Today;
            //foreach (var cities in db.Route.ToList().Select(i => new FindTicketModel(i)).GroupBy(x => x.EndCities).Select(j => j.First()).ToList())
            //{
            //    endStations.Add(cities);
            //}

            //foreach (var cities in db.Route.ToList().Select(i => new FindTicketModel(i)).GroupBy(x => x.EndCities).Select(j => j.First()).ToList())
            //{
            //    endCities.Add(cities);
            //}

            //foreach (var item in endStations)
            //{
            //    endCities.Add(item);
            //}
        }

        /* public class FindTrips
         {
             public string DepartureName { get; set; }
             public string ArrivalName { get; set; }
             public List<string> cities { get; set; }
         }*/

        private Guid _viewId;
        public Guid ViewID
        {
            get { return _viewId; }
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
                var cities = this.endCities.Where(i => i.DepPlace == SelectStartCity.Name).ToList().Distinct(new CityComparer()).ToList();
                foreach (var item in cities)
                {
                    endCities.Add(item);
                }
                return endCities;
            }
        }

        public ObservableCollection<AvailableCity> AvailableTrips
        {
            get
            {
                return availableTrips;
            }
            set
            {
                availableTrips = value;
                OnPropertyChanged("AvailableTrips");
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

        public DateTime DepartureDate
        {
            get
            {
                return this.departureDate;
            }
            set
            {
                this.departureDate = value;
                OnPropertyChanged("DepartureDate");
            }
        }

        public int PassengerNumber
        {
            get
            {
                return this.passengerNumber;
            }
            set
            {
                this.passengerNumber = value;
                OnPropertyChanged("PassengerNumber");
            }
        }

        public AvailableCity SelectedTrip
        {
            get
            {
                return selectedTrip;
            }
            set
            {
                selectedTrip = value;
                OnPropertyChanged("SelectedTrip");
            }
        }

        private RelayCommand findTrip;
        public RelayCommand FindTrip
        {
            get
            {
                return findTrip ??
                    (findTrip = new RelayCommand(obj =>
                    {
                        AvailableTrips.Clear();

                        var selectedDate = new DateTime(DepartureDate.Year, DepartureDate.Month, DepartureDate.Day);
                        if (selectedDate < DateTime.Today)
                        {
                            return;
                        }


                        var opportunityFromRoute = db.Route.Where(i => i.Departure_place == SelectStartCity.Name && i.Arrival_place == SelectEndCity.Name).ToList();
                        var opportunityFromRouteStation = db.Route_Station.Where(i => i.Route.Departure_place == SelectStartCity.Name && i.Station.Name == SelectEndCity.Name).ToList();

                        foreach (var item in opportunityFromRoute)
                        {
                            var listTrips = selectedDate == DateTime.Today ? item.Trip_Route.Where(i => i.IdRoute_FK == item.IdRoute && i.Trip.Departure_time >= DateTime.Now.TimeOfDay).ToList() : item.Trip_Route.Where(i => i.IdRoute_FK == item.IdRoute).ToList();
                            foreach (var trip in listTrips)
                            {
                                var countPassangers = db.Route.Where(i => i.Departure_place == selectStartCity.Name && i.Arrival_place == selectEndCity.Name).FirstOrDefault()
                                                .Trip_Route.Join(db.Trip, tr => tr.IdTrip_FK, t => t.IdTrip, (tr, t) => new { tr = tr, t = t })
                                                .Join(db.Ticket, t => t.t.IdTrip, tic => tic.IdTrip_FK, (t, tic) => new { t = t, tic = tic })
                                                .Where(i => i.tic.Departure_date.Date == DepartureDate.Date && i.t.t.IdTrip == trip.IdTrip_FK)
                                                .Count();

                                var countPlacesAtTheBus = db.Trip.Where(j => j.IdTrip == trip.IdTrip_FK).FirstOrDefault().Bus.Seats;

                                if (countPlacesAtTheBus - countPassangers >= PassengerNumber)
                                {
                                    AvailableTrips.Add(new AvailableCity()
                                    {
                                        IdTrip = trip.IdTrip_FK,
                                        Time = trip.Trip.Departure_time,
                                        Cost = item.Cost.ToString()
                                    });
                                }
                            }
                            //AvailableTrips.Add(new AvailableCity() {
                            //    Time = item.Trip_Route.Where(i => i.IdRoute_FK == item.IdRoute).FirstOrDefault().Trip.Departure_time,
                            //    Cost = item.Cost.ToString()
                            //});
                        }

                        foreach (var item in opportunityFromRouteStation)
                        {
                            var listTrips = selectedDate == DateTime.Today ? item.Route.Trip_Route.Where(i => i.IdRoute_FK == item.Route.IdRoute && i.Trip.Departure_time >= DateTime.Now.TimeOfDay).ToList() : item.Route.Trip_Route.Where(i => i.IdRoute_FK == item.Route.IdRoute).ToList();
                            foreach (var trip in listTrips)
                            {
                                var countPassangers = db.Route.Where(i => i.Departure_place == selectStartCity.Name && i.Arrival_place == selectEndCity.Name).FirstOrDefault()
                                                .Trip_Route.Join(db.Trip, tr => tr.IdTrip_FK, t => t.IdTrip, (tr, t) => new { tr = tr, t = t })
                                                .Join(db.Ticket, t => t.t.IdTrip, tic => tic.IdTrip_FK, (t, tic) => new { t = t, tic = tic })
                                                .Where(i => i.tic.Departure_date.Date == DepartureDate.Date && i.t.t.IdTrip == trip.IdTrip_FK)
                                                .Count();

                                var countPlacesAtTheBus = db.Trip.Where(j => j.IdTrip == trip.IdTrip_FK).FirstOrDefault().Bus.Seats;

                                if (countPlacesAtTheBus - countPassangers >= PassengerNumber)
                                {
                                    AvailableTrips.Add(new AvailableCity()
                                    {
                                        IdTrip = trip.IdTrip_FK,
                                        Time = trip.Trip.Departure_time,
                                        Cost = item.Cost.Cost1.ToString()
                                    });
                                }
                            }
                            //AvailableTrips.Add(new AvailableCity()
                            //{
                            //    Time = item.Route.Trip_Route.Where(i => i.IdRoute_FK == item.Route.IdRoute).FirstOrDefault().Trip.Departure_time,
                            //    Cost = item.Cost.Cost1.ToString()
                            //});
                            var sort = AvailableTrips.OrderBy(i => i.Time).ToList();
                            AvailableTrips.Clear();
                            foreach (var trip in sort)
                            {
                                AvailableTrips.Add(new AvailableCity()
                                {
                                    IdTrip = trip.IdTrip,
                                    Time = trip.Time,
                                    Cost = trip.Cost
                                });
                            }

                            SelectedTrip = AvailableTrips.Count > 0 ? AvailableTrips[0] : null;
                        }
                    }));
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

                        var countPassangers = db.Route.Where(i => i.Departure_place == selectStartCity.Name && i.Arrival_place == selectEndCity.Name).FirstOrDefault()
                                            .Trip_Route.Join(db.Trip, tr => tr.IdTrip_FK, t => t.IdTrip, (tr, t) => new { tr = tr, t = t })
                                            .Join(db.Ticket, t => t.t.IdTrip, tic => tic.IdTrip_FK, (t, tic) => new { t = t, tic = tic })
                                            .Where(i => i.tic.Departure_date.Date == DepartureDate.Date && i.t.t.IdTrip == selectedTrip.IdTrip)
                                            .ToList()
                                            .Count();

                        countCurrentPassangerAtBus = countPassangers;
                        var countPlacesAtTheBus = db.Trip.Where(j => j.IdTrip == selectedTrip.IdTrip).FirstOrDefault().Bus.Seats;

                        if (countPlacesAtTheBus - countCurrentPassangerAtBus < PassengerNumber) return;

                        {
                            passangerView = new Passenger();
                            passangerView.AddPassanger += CreatedNewPassanger;
                            passangerView.DefineEvent();
                            passangerView.Show();
                        }
                    }));
            }
        }

        void CreatedNewPassanger(PassangerModel passanger)
        {
            countFillingQuestionnaire++;
            passangers.Add(passanger);
            CreateTickets(passanger);
            if (countFillingQuestionnaire == passengerNumber)
            {
                passangerView.Close();

                //SaveTicketInPdf();
            }
        }

        void CreateTickets(PassangerModel passanger)
        {
            int maxIdTicker = db.Ticket.OrderByDescending(i => i.IdTicket).FirstOrDefault().IdTicket + 1;
            //foreach (var passanger in passangers)
            //{
            db.Ticket.Add(new DAL.Ticket()
            {
                IdTicket = maxIdTicker++,
                Departure_date = DepartureDate,
                IdTrip_FK = selectedTrip.IdTrip,
                Passanger_FIO = passanger.FIO,
                Seat = ++countCurrentPassangerAtBus,
                Passanger_passport = passanger.PassportSeries.ToString() + " " + passanger.PassportNumber.ToString()
            });
            SaveTicketInPdf(passanger);
            //}

            db.SaveChanges();

        }

        void SaveTicketInPdf(PassangerModel passanger)
        {

            iTextSharp.text.Document doc = new iTextSharp.text.Document();

            PdfWriter.GetInstance(doc, new FileStream("C:\\Users\\user\\Desktop\\Билеты\\Ticket_" + selectedTrip.IdTrip + "_" + Convert.ToString(DepartureDate.Day) + "." + Convert.ToString(DepartureDate.Month) + "." + Convert.ToString(DepartureDate.Year) + "_" + countCurrentPassangerAtBus++ + ".pdf", FileMode.Create));
            countCurrentPassangerAtBus--;

            doc.Open();

            BaseFont baseFont = BaseFont.CreateFont("C:\\Users\\user\\Desktop\\ИГЭУ\\3 курс\\Конструирование ПО\\АВТОВОКЗАЛ\\Bus_Station\\Bus_Station\\bin\\Debug\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

            PdfPTable table = new PdfPTable(2);

            PdfPCell cell = new PdfPCell(new Phrase("БИЛЕТ НА АВТОБУС", font));
            cell.Colspan = 2;
            cell.HorizontalAlignment = 1;
            cell.Border = 0;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(" ", font));
            cell.Colspan = 2;
            cell.Border = 0;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(new Phrase("Пункт отправления", font)));
            cell.Border = 0;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(new Phrase(SelectStartCity.Name, font)));
            cell.Border = 0;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(new Phrase("Пункт прибытия", font)));
            cell.Border = 0;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(new Phrase(SelectEndCity.Name, font)));
            cell.Border = 0;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(new Phrase("Время отправления", font)));
            cell.Border = 0;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(new Phrase(Convert.ToString(DepartureDate.Day) + "." + Convert.ToString(DepartureDate.Month) + "." + Convert.ToString(DepartureDate.Year) + " " + Convert.ToString(SelectedTrip.Time), font)));
            cell.Border = 0;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(new Phrase("Стоимость", font)));
            cell.Border = 0;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(new Phrase(SelectedTrip.Cost + " руб.", font)));
            cell.Border = 0;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(new Phrase("Пассажир", font)));
            cell.Border = 0;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(new Phrase(passanger.FIO, font)));
            cell.Border = 0;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(new Phrase("Паспорт", font)));
            cell.Border = 0;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(new Phrase(passanger.PassportSeries + " " + passanger.PassportNumber, font)));
            cell.Border = 0;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(new Phrase("Место", font)));
            cell.Border = 0;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(new Phrase(Convert.ToString(countCurrentPassangerAtBus++), font)));
            countCurrentPassangerAtBus--;
            cell.Border = 0;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(" ", font));
            cell.Colspan = 2;
            cell.Border = 0;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("СЧАСТЛИВОГО ПУТИ!", font));
            cell.Colspan = 2;
            cell.HorizontalAlignment = 1;
            cell.Border = 0;
            table.AddCell(cell);

            doc.Add(table);
            doc.Close();
        }

        private RelayCommand changeSelectedTrip;
        public RelayCommand ChangeSelectedTrip
        {
            get
            {
                return changeSelectedTrip ??
                    (changeSelectedTrip = new RelayCommand(obj =>
                    {
                        this.SelectedTrip = (AvailableCity)obj;
                    }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
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

        private RelayCommand changeUser;
        public RelayCommand ChangeUser
        {
            get
            {
                return changeUser ??
                    (changeUser = new RelayCommand(obj =>
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.ShowDialog();
                        WindowManager.CloseWindow(ViewID);
                    }));
            }
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
                return x.Name.Trim() == y.Name.Trim();
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

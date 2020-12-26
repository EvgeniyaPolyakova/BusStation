namespace Bus_Station.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BusStationContext : DbContext
    {
        public BusStationContext()
            : base("name=BusStationContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Bus> Bus { get; set; }
        public virtual DbSet<Cost> Cost { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<Route_Station> Route_Station { get; set; }
        public virtual DbSet<Station> Station { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<Trip> Trip { get; set; }
        public virtual DbSet<Trip_Route> Trip_Route { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bus>()
                .Property(e => e.Bus_Number)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bus>()
                .HasMany(e => e.Trip)
                .WithRequired(e => e.Bus)
                .HasForeignKey(e => e.IdBus_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cost>()
                .Property(e => e.Cost1)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Cost>()
                .HasMany(e => e.Route_Station)
                .WithOptional(e => e.Cost)
                .HasForeignKey(e => e.IdCost_FK);

            modelBuilder.Entity<Route>()
                .Property(e => e.Cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Route>()
                .HasMany(e => e.Route_Station)
                .WithRequired(e => e.Route)
                .HasForeignKey(e => e.IdRoute_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Route>()
                .HasMany(e => e.Trip_Route)
                .WithRequired(e => e.Route)
                .HasForeignKey(e => e.IdRoute_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Station>()
                .HasMany(e => e.Route_Station)
                .WithRequired(e => e.Station)
                .HasForeignKey(e => e.IdStation_Fk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trip>()
                .HasMany(e => e.Ticket)
                .WithRequired(e => e.Trip)
                .HasForeignKey(e => e.IdTrip_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trip>()
                .HasMany(e => e.Trip_Route)
                .WithRequired(e => e.Trip)
                .HasForeignKey(e => e.IdTrip_FK)
                .WillCascadeOnDelete(false);
        }
    }
}

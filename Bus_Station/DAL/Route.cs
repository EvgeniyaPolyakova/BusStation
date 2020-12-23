namespace Bus_Station.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Route")]
    public partial class Route
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Route()
        {
            Route_Station = new HashSet<Route_Station>();
            Trip_Route = new HashSet<Trip_Route>();
        }

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdRoute { get; set; }

        [Required]
        [StringLength(50)]
        public string Departure_place { get; set; }

        [Required]
        [StringLength(50)]
        public string Arrival_place { get; set; }

        [Column(TypeName = "money")]
        public decimal? Cost { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Route_Station> Route_Station { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trip_Route> Trip_Route { get; set; }
    }
}

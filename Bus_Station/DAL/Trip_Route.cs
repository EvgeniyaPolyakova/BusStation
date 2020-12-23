namespace Bus_Station.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Trip_Route
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdTR { get; set; }

        public int IdTrip_FK { get; set; }

        public int IdRoute_FK { get; set; }
        public byte? isActive { get; set; }

        public virtual Route Route { get; set; }

        public virtual Trip Trip { get; set; }
    }
}

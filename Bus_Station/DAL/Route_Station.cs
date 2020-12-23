namespace Bus_Station.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Route_Station
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdRS { get; set; }

        public int IdRoute_FK { get; set; }

        public int IdStation_Fk { get; set; }

        public int? IdCost_FK { get; set; }
        public byte isActive { get; set; }

        public virtual Cost Cost { get; set; }

        public virtual Route Route { get; set; }

        public virtual Station Station { get; set; }
    }
}

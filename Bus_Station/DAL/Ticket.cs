namespace Bus_Station.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ticket")]
    public partial class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdTicket { get; set; }

        [Column(TypeName = "date")]
        public DateTime Departure_date { get; set; }

        public int? Seat { get; set; }

        [StringLength(70)]
        public string Passanger_FIO { get; set; }

        [StringLength(20)]
        public string Passanger_passport { get; set; }

        public int IdTrip_FK { get; set; }

        public virtual Trip Trip { get; set; }
    }
}

using Org.BouncyCastle.Asn1.Mozilla;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace okruhy_pujcovnaMVCAPP.Entities
{
    [Table("reservation")]
    public class reservation
    {
        [Key]
        [Column("ReservationId")]
        public int ReservationId { get; set; }
        [Column("UserId")]
        public int UserId { get; set; }
        public user User { get; set; }

        [Column("CircuitCarId")]
        public int CircuitCarId { get; set; }
        public circuitcar Circuitcar { get; set; }

        [Column("FromDate")]
        public DateTime FromDate { get; set; }
        [Column("ToDate")]
        public DateTime ToDate { get; set; }
        [Column("TotalPrice")]
        public decimal totalprice { get; set; }
    }
}

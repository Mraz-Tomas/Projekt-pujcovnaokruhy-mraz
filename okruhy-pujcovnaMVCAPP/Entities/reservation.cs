using Org.BouncyCastle.Asn1.Mozilla;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace okruhy_pujcovnaMVCAPP.Entities
{
    [Table("reservation")]
    public class reservation
    {
        [Key]
        [Column("reservation_id")]
        public int reservation_id { get; set; }
        [Column("user_id")]
        public int user_id { get; set; }
        public user user { get; set; }

        [Column("circuit_car_id")]
        public int circuit_car_id { get; set; }
        public circuitcar Circuitcar { get; set; }

        [Column("from_date")]
        public DateTime from_date { get; set; }
        [Column("to_date")]
        public DateTime to_date { get; set; }
        [Column("total_price")]
        public decimal total_price { get; set; }
    }
}

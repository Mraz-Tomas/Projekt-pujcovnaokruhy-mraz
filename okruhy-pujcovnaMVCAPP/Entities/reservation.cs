using Org.BouncyCastle.Asn1.Mozilla;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace okruhy_pujcovnaMVCAPP.Entities
{
    [Table("reservations")]
    public class reservation
    {
        [Key]
        public int reservation_id { get; set; }

        public int user_id { get; set; }

        public int car_id { get; set; }

        public int circuit_id { get; set; }

        public DateTime start_date { get; set; }

        public DateTime end_date { get; set; }
    }
}

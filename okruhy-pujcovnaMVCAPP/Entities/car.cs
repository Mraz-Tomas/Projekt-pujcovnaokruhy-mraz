using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace okruhy_pujcovnaMVCAPP.Entities
{
    [Table("cars")]
    public class car
    {
        [Key]
        [Column("car_id")]
        public int car_id { get; set; }
        [Column("brand")]
        public string brand { get; set; }
        [Column("model")]
        public string model { get; set; }
        [Column("power_hp")]
        public int power_hp { get; set; }
        [Column("price_per_day")]
        public decimal price_per_day { get; set; }

        public ICollection<circuitcar> circuitcar { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace okruhy_pujcovnaMVCAPP.Entities
{
    [Table("car")]
    public class car
    {
        [Key]
        [Column("CarId")]
        public int Carid { get; set; }
        [Column("Brand")]
        public string Brand { get; set; }
        [Column("Model")]
        public string Model { get; set; }
        [Column("PowerHp")]
        public int PowerHp { get; set; }
        [Column("PricePerDay")]
        public decimal priceperday { get; set; }

        public ICollection<circuitcar> CircuitCars { get; set; }
    }
}

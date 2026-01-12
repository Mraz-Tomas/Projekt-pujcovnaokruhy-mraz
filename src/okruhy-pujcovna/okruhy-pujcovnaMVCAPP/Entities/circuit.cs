using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace okruhy_pujcovnaMVCAPP.Entities
{
    [Table("circuit")]
    public class circuit
    {
        [Key]
        [Column("CircuitId")]
        public int CircuitId { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Country")]
        public string country { get; set; }
        [Column("LengthKm")]
        public decimal lenghtkm { get; set; }
        [Column("ImageUrl")]
        public string imageurl { get; set; }

        public ICollection<circuitcar> circuitcars { get; set; }
    }
}

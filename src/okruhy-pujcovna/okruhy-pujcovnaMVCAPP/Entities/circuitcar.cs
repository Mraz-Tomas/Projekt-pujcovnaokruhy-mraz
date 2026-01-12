using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace okruhy_pujcovnaMVCAPP.Entities
{
    [Table("circuitcar")]
    public class circuitcar
    {
        [Key]
        [Column("CircuitCarId")]
        public int CircuitCarId { get; set; }
        [Column("CircuitId")]
        public int CircuitId { get; set; }
        public circuit circuit { get; set; }
        public car Car { get; set; }
        [Column("CarId")]
        public int CarId { get; set; }
        [Column("IsAvailable")]
        public bool IsAvailable { get; set; }
    }
}

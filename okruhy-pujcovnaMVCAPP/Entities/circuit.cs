using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace okruhy_pujcovnaMVCAPP.Entities
{
    [Table("circuits")]
    public class circuit
    {
        [Key]
        [Column("circuit_id")]
        public int CircuitId { get; set; }
        [Column("name")]
        public string? Name { get; set; }
        [Column("country")]
        public string? country { get; set; }
        [Column("length_km")]
        public decimal? lenghtkm { get; set; }

        public ICollection<circuitcar> circuitcar { get; set; }
    }
}

using Microsoft.AspNetCore.Components.Server.Circuits;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace okruhy_pujcovnaMVCAPP.Entities
{
    [Table("circuit_cars")]
    public class circuitcar
    {
        [Key]
        [Column("circuit_car_id")]
        public int circuit_car_id { get; set; }
        [Column("circuit_id")]
        public int circuit_id { get; set; }
        [Column("car_id")]
        public int car_id { get; set; }
        [Column("is_available")]
        public bool is_available { get; set; }

        [ForeignKey(nameof(circuit_id))]
        public circuit circuit { get; set; }
        [ForeignKey(nameof(car_id))]
        public car Car { get; set; }
    }
}

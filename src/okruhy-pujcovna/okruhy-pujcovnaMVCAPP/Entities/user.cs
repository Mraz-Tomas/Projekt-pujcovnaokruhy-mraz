using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace okruhy_pujcovnaMVCAPP.Entities
{
    [Table("user")]
    public class user
    {
        [Key]
        [Column("UserId")]
        public int UserId { get; set; }
        [Column("FirstName")]
        public string FirstName { get; set; }
        [Column("LastName")]
        public string LastName { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("Password")]
        public string password { get; set; }

        public ICollection<reservation> Reservations { get; set; }
    }
}

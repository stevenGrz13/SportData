using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Models
{
    [Table("specificiteevenement")]
    public class SpecificiteEvenement
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("idevenement")]
        [DisplayName("evenement")]
        public int IdEvenement { get; set; }

        [Column("idsport")]
        [DisplayName("sport")]
        public int IdSport { get; set; }

        [Column("datedebut")]
        public DateTime DateDebut { get; set; }

        [Column("datefin")]
        public DateTime DateFin { get; set; }

        [Column("nombreplace")]
        public int NombrePlace { get; set; }

        [ForeignKey("IdEvenement")]
        public virtual Evenement? Evenement { get; set; }

        [ForeignKey("IdSport")]
        public virtual Sport? Sport { get; set; }
    }
}

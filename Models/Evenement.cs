using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Models
{
    [Table("evenement")]
    public class Evenement
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("libelle")]
        public string Libelle { get; set; }

        [Column("idorganisation")]
        [DisplayName("organisation")]
        public int IdOrganisation { get; set; }

        [Column("datedebut")]
        public DateTime DateDebut { get; set; }

        [Column("datefin")]
        public DateTime DateFin { get; set; }

        [ForeignKey("IdOrganisation")]
        public virtual Organisation? Organisation { get; set; }
    }
}

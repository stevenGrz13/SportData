using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Models
{
    [Table("administrateur")]
    public class Administrateur
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("adressecourriel")]
        public string AdresseCourriel { get; set; }

        [Column("motdepasse")]
        public string MotDePasse { get; set; }

        [Column("identifiant")]
        public string Identifiant { get; set; }

        [Column("idorganisation")]
        [DisplayName("organisation")]
        public int IdOrganisation { get; set; }

        [ForeignKey("IdOrganisation")]
        public virtual Organisation? Organisation { get; set; }
    }
}

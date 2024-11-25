using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Models
{

    [Table("employe")]
    public class Employe
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nom")]
        public string Nom { get; set; }

        [Column("prenom")]
        public string Prenom { get; set; }

        [Column("adressecourriel")]
        public string AdresseCourriel { get; set;}

        [Column("motdepasse")]
        public string? MotDePasse { get; set;}

        [Column("validation")]
        [DefaultValue(false)]
        public bool Validation { get; set; }

        [Column("idorganisation")]
        [DisplayName("organisation")]
        public int IdOrganisation { get; set; }

        [ForeignKey("IdOrganisation")]
        public virtual Organisation? Organisation { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Models
{
    [Table("utilisateur")]
    public class Utilisateur
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nom")]
        public string Nom { get; set; }

        [Column("prenom")]
        public string Prenom { get; set; }

        [Column("adressecourriel")]
        public string AdresseCourriel { get; set; }

        [Column("motdepasse")]
        public string MotDePasse { get; set; }

        [Column("adresse")]
        public string Adresse { get; set; }

        [Column("telephone")]
        public string Telephone { get; set; }

        [Column("telephonepro")]
        public string? TelephonePro { get; set;}
    }
}

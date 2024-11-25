using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Models
{
    [Table("coach")]
    public class Coach
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("idsport")]
        [DisplayName("sport")]
        public int IdSport { get; set; }

        [Column("nom")]
        public string Nom { get; set; }

        [ForeignKey("IdSport")]
        public virtual Sport? Sport { get; set; }
    }
}

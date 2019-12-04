using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaporStore.Data.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }

        [RegularExpression(@"^([0-9]{4}) ([0-9]{4}) ([0-9]{4}) ([0-9]{4})$")]
        [Required]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"^([0-9]{3})$")]
        public string Cvc { get; set; }

        [Required]
        public CardType Type { get; set; }

        [ForeignKey(nameof(User))]
        [Required]
        public int UserId { get; set; }

        [Required]
        public User User { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
    }
}
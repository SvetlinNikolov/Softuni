using System.ComponentModel.DataAnnotations;

namespace WebApp
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }



    }
}
using System.ComponentModel.DataAnnotations;

namespace travel_asp.net_api.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TotalPrice { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$")]
        public string Email { get; set; }
        [Required]
        public IEnumerable<UserExcursion> UserExcursions {get;set;}
    }
}

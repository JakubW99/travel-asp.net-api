using System.ComponentModel.DataAnnotations;

namespace travel_asp.net_api.Models
{
    public class Travel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Value {get;set;}
        [Required]
        public string Destination { get; set; }
        public string Description { get; set; }
    }
}

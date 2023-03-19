using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace travel_asp.net_api.Models
{
   
    public class UserExcursion
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string Detail { get; set; }
    }
}

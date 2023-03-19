using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace travel_asp.net_api.Models
{

    public class Excursion
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name{ get; set; }
        [Required]
        public int AdultPrice {get;set;}
        [Required]
        public int ChildPrice { get; set;}
        [Required]
        public string Description { get; set; }
      
    }
    
}

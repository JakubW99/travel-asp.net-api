using System.ComponentModel.DataAnnotations;

namespace travel_asp.net_api.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public Excursion Excursion { get; set; }
        public string ImagePath { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace travel_asp.net_api.ViewModels
{
    public class ImageViewModel
    {

        public IEnumerable<IFormFile> Image { get; set; }

    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.IO;
using travel_asp.net_api.Models;
using travel_asp.net_api.ViewModels;

namespace travel_asp.net_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcursionImagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public static IWebHostEnvironment _environment;
        public ExcursionImagesController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        [Authorize(Roles = "Admin")]
        [EnableCors("MyPolicy")]
        [Route("{id}")]
        [HttpPost]
        public async Task<IActionResult> PostExcursionImage([FromForm] ImageViewModel model, [FromRoute] int id)
        {
            if (model == null)
            {
                return Content("Invalid");
            }
            var image = new Image();
            var excursion = await _context.Excursions.FindAsync(id);

            foreach (var item in model.Image)
            {

                if (item.FileName == null || item.FileName.Length == 0)
                {
                    return Content("File not selected");
                }
                var path = Path.Combine(_environment.WebRootPath, "Images/", item.FileName);
           
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await item.CopyToAsync(stream);
                    stream.Close();
                }
                image.Excursion = excursion;
                image.ImagePath = "/Images/" + item.FileName;


                _context.Add(image);
                await _context.SaveChangesAsync();
            }

            return Ok(model);
        }
        [Authorize(Roles = "Admin")]
        [EnableCors("MyPolicy")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteExcursionImage([FromRoute] int id)
        {
            if (_context.Images == null)
            {
                return NotFound();
            }
            var image = await _context.Images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }
            var env = _environment.WebRootPath;
            var path = Path.Combine(env.Remove(env.Length - 1), image.ImagePath);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using travel_asp.net_api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace travel_asp.net_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelController : ControllerBase
    {

        public List<Travel> Travels = new List<Travel>();
       
        
        // GET: api/<TravelController>
        [HttpGet]
        public async Task<IEnumerable<Travel>> Get()
        {
            return Travels;
        }

        // GET api/<TravelController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Travel>> Get(int id)
        {
            var travel = Travels.Where(x => x.Id == id).FirstOrDefault();
            return travel== null ? NotFound() : travel;
        }

        // POST api/<TravelController>
        [HttpPost]
        public void Post([FromBody] Travel travel)
        {
            Travels.Append(travel);

        }

        // PUT api/<TravelController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Travel travel)
        {
            if(ModelState.IsValid)
            {
                var _travel = Travels.Where(x => x.Id == travel.Id).FirstOrDefault();
                if(_travel!=null ) 
                {
                   _travel.Id = travel.Id;
                  _travel.Value = travel.Value;
                  _travel.Destination = travel.Destination;
                    _travel.Description = travel.Description;
                }
            }
        }

        // DELETE api/<TravelController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var travel = Travels.Where(x=>x.Id == id).FirstOrDefault();
            if (travel != null)
            {
                Travels.RemoveAt(id);
                return Ok();
            }
            else
               return  NoContent();
        }
    }
}

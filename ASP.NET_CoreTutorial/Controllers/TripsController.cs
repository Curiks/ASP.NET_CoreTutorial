using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_CoreTutorial.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_CoreTutorial.Controllers
{
    [Route("api/[controller]")]
    public class TripsController : ControllerBase
    {
        TripContext tripContext;
        public TripsController(TripContext _context)
        {
            tripContext = _context;
            tripContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        // GET api/Trips
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var trips = await tripContext.Trips
                .AsNoTracking()
                .ToListAsync();

            return Ok(trips);
        }

        // GET api/Trips/5
        [HttpGet("{id}")]
        public Models.Trip Get(int id)
        {
            return tripContext.Trips.Find(id);
        }

        // POST api/Trips
        [HttpPost]
        public IActionResult Post([FromBody] Models.Trip value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tripContext.Trips.Add(value);
            tripContext.SaveChanges();

            return Ok();
        }

        // PUT api/Trips/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Models.Trip value)
        {
            if (!tripContext.Trips.Any(t => t.Id == id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tripContext.Trips.Update(value);
            await tripContext.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/Trips/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var myTrip = tripContext.Trips.Find(id);

            if (myTrip == null)
            {
                return NotFound();
            }

            tripContext.Trips.Remove(myTrip);
            tripContext.SaveChanges();

            return NoContent();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_CoreTutorial.Controllers
{
    [Route("api/[controller]")]
    public class TripsController : ControllerBase
    {
        private Models.Repository repository;
        public TripsController(Models.Repository _repository)
        {
            repository = _repository;
        }

        // GET api/Trips
        [HttpGet]
        public IEnumerable<Models.Trip> Get()
        {
            return repository.Get();
        }

        // GET api/Trips/5
        [HttpGet("{id}")]
        public Models.Trip Get(int id)
        {
            return repository.Get(id);
        }

        // POST api/Trips
        [HttpPost]
        public void Post([FromBody] Models.Trip value)
        {
            repository.Add(value);
        }

        // PUT api/Trips/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Models.Trip value)
        {
            repository.Update(value);
        }

        // DELETE api/Trips/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Remove(id);
        }
    }
}

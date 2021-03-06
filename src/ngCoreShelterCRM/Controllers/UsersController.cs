﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ngCoreShelterCRM.Models.Repositories;
using Newtonsoft.Json;
using System.Diagnostics;
using ngCoreShelterCRM.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ngCoreShelterCRM.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private FBPetRepository _repo = new FBPetRepository();

        // GET api/pets
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var pets = _repo.Pets().Result;
            yield return JsonConvert.SerializeObject(pets);
        }

        // GET api/pets/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            var pet = _repo.GetPet(id).Result;
            return JsonConvert.SerializeObject(pet);
        }

        // POST api/pets
        [HttpPost]
        public void Post([FromBody] Pet request)
        {
            var result = _repo.AddPet(request);
        }

        // PUT api/pets/5
        [HttpPut("{id}")]
        public bool Put(string id, [FromBody] Pet request)
        {
            var result = _repo.UpdatePet(id, request).Result;
            return result;
        }

        // DELETE api/pets/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _repo.DeletePet(id);
        }
    }
}

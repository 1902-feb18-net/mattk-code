﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CharacterRestService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharacterRestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private static readonly List<Character> _data = new List<Character>()
        {
            new Character { Id = 1, Name = "Nick" },
            new Character { Id = 2, Name = "Fred" },
        };

        // GET: api/Character
        [HttpGet]
        //[Produces("application/xml")]
        public IEnumerable<Character> Get()
        {
            return _data;
            // whenever an action method returns something that's not an IActionResult
            // ... it's automatically wrapped in 200 OK response.
        }


        // GET: api/Character/1
        [HttpGet("{id}", Name = "GetById")]
        [Authorize]
        //[Produces("application/xml")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Character> GetById(int id)
        {
            // using fancy pattern matching syntax
            if (_data.FirstOrDefault(x => x.Id == id) is var character)
            {
                return character;
            }

            return NotFound();
        }

        // return types should generally either be IActionResult or some subtype of that.
        // or ActionResult<type-of-data-in-body>

        // POST: api/Character
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(typeof(Character), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody, Bind("Name")] Character character)
        {
            // there was some "overposting" vulnerability here... i do not want client to be able
            // to set the ID. either i can make sure to ignore that value if he sends it
            // or i can explicitly not bind it.

            var newId = _data.Max(x => x.Id) + 1;
            character.Id = newId;
            _data.Add(character);

            return CreatedAtAction(nameof(GetById), new { id = newId }, character);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, [FromBody, Bind("Name")] Character character)
        {
            // implementation choice, whether PUT on nonexistent resource is
            // successful or error.
            if (_data.FirstOrDefault(x => x.Id == id) is var existing)
            {
                existing.Name = character.Name;
                return NoContent(); // 204
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            if (_data.FirstOrDefault(x => x.Id == id) is var existing)
            {
                _data.Remove(existing);
                return NoContent(); // 204
            }
            return NotFound();
        }
    }
}

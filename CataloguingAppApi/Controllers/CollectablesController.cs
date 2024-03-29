﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CataloguingAppApi.Data;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace CataloguingAppApi.Controllers
{
    public class CollectablesController : ODataController
    {
        private readonly appContext _context;

        public CollectablesController(appContext context)
        {
            _context = context;
        }

        // GET: api/Collectables
        [EnableQuery]
        public ActionResult<IQueryable<Model.Collectable>> Get()
        {
            return Ok(_context.Collectables.AsQueryable().Select(f => new Model.Collectable
                {
                    Id = f.Hierarchynodeid,
                    Title = f.Title,
                    Description = f.Description,
                    Pricepaid = f.Pricepaid,
                    Currentworth = f.Currentworth,
                    Size = f.Size,
                    Images = f.Images.Select(i => new Model.Image() {
                        Id = i.Id,
                        Collectableid = i.Collectableid,
                        Filename = i.Filename,
                        Data = i.Data
                    }).ToArray()
                })
            );
        }

        // GET: api/Collectables/5
        [EnableQuery]
        public async Task<ActionResult<Model.Collectable>> GetCollectable(int key)
        {
            var collectable = await _context.Collectables.FindAsync(key);

            if (collectable == null)
            {
                return NotFound();
            }

            return Ok(new Model.Collectable
                {
                    Id = collectable.Hierarchynodeid,
                    Title = collectable.Title,
                    Description = collectable.Description,
                    Pricepaid = collectable.Pricepaid,
                    Currentworth = collectable.Currentworth,
                    Size = collectable.Size,
                    Images = collectable.Images.Select(i => new Model.Image() {
                        Id = i.Id,
                        Collectableid = i.Collectableid,
                        Filename = i.Filename,
                        Data = i.Data
                    }).ToArray()
                });
        }

        // PUT: api/Collectables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollectable(int id, Collectable collectable)
        {
            if (id != collectable.Hierarchynodeid)
            {
                return BadRequest();
            }

            _context.Entry(collectable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollectableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Collectables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Collectable>> PostCollectable(Collectable collectable)
        {
            _context.Collectables.Add(collectable);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCollectable), new { id = collectable.Hierarchynodeid }, collectable);
        }

        // DELETE: api/Collectables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollectable(int id)
        {
            var collectable = await _context.Collectables.FindAsync(id);
            if (collectable == null)
            {
                return NotFound();
            }

            _context.Collectables.Remove(collectable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CollectableExists(int id)
        {
            return _context.Collectables.Any(e => e.Hierarchynodeid == id);
        }
    }
}

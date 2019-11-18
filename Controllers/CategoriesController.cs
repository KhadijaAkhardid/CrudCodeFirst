using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudCodeFirst.Models;
using CrudCodeFirst.Repository;

namespace CrudCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly Irepository<Category> _category;

        public CategoriesController(Irepository<Category> category)
        {
            _category = category;
        }

        // GET: api/Categories
        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            return _category.GetAll();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            Category cat = _category.GetById(id);
            return Ok(cat);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public IActionResult PutCategory([FromRoute] int id, [FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.Id)
            {
                return BadRequest();
            }

            _category.Update(category);
            _category.save();

            try
            {
                _category.Update(category);
                _category.save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Categories
        [HttpPost]
        public IActionResult PostCategory([FromBody] Category category)
        {
            if (ModelState.IsValid)
           {
                //return BadRequest(ModelState);
                _category.Add(category);
                _category.save();
            }

           // _context.Categories.Add(category);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory([FromRoute] int id)
        {
            _category.Delete(id);
            _category.save();
            return Ok(_category.GetAll());
        }

        private bool CategoryExists(int id)
        {
            return _category.GetById(id) == null ? false : true;
        }
    }
}
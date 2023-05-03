using WebApplication1.Database; // import EF
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace WebApplication1.Controllers
{
    //https://localhost:7148/api/menufacturers
    [Route("api/[controller]")]
    [ApiController]
    public class menufacturersController : ControllerBase
    {
        //Variable
        private readonly DataDbContext _dbcontext;

        //constructor Method
        public menufacturersController(DataDbContext DbContext) 
        
        {
            _dbcontext = DbContext;
        }


        //get post put delete


        // Async Await =>
        [HttpGet]
        public async Task<ActionResult<List<menufacturers>>> getMenufacturers() 
        {
            var menufacturers = await _dbcontext.menufacturers.ToListAsync();

            if (menufacturers.Count == 0) 
            {

                return NotFound();          
            }

            return Ok(menufacturers);



        }




        [HttpGet("id")]
        public async Task<ActionResult<List<menufacturers>>> getMenufacturers(int id)
        {
            var menufacturer = await _dbcontext.menufacturers.FindAsync(id);

            if (menufacturer == null)
            {

                return NotFound();
            }

            return Ok(menufacturer);


        }


        [HttpPost]
        public async Task<ActionResult<List<menufacturers>>> postMenufacturers(menufacturers menufacturer)
        {
            try
            {


               _dbcontext.menufacturers.Add(menufacturer);
                await _dbcontext.SaveChangesAsync();


            }
            catch (DbUpdateException) {

                return BadRequest();
            
            }
            return Ok(menufacturer);

        }

        [HttpPut]
        public async Task<ActionResult<List<menufacturers>>> putMenufacturers(int id, menufacturers newMenufacturer) {



            var menufacturer = await _dbcontext.menufacturers.FindAsync(id);

            if (menufacturer == null)
            {

                return NotFound();
            }
            menufacturer.id = newMenufacturer.id;
            menufacturer.Title = newMenufacturer.Title;

            return Ok();
       }


        [HttpDelete]
        public async Task<ActionResult<List<menufacturers>>> DeleteMenufacturers(int id) {

            var menufacturer = await _dbcontext.menufacturers.FindAsync(id);

            if (menufacturer == null)
            {

                return NotFound();
            }

            _dbcontext.menufacturers.Remove(menufacturer);

            await _dbcontext.SaveChangesAsync();

            return Ok(menufacturer);

        }


    }
}

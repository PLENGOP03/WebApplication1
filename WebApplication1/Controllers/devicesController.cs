using WebApplication1.Database; // import EF
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class devicesController : ControllerBase
    {

        //Variable
        private readonly DataDbContext _dbcontext;

        //constructor Method
        public devicesController(DataDbContext DbContext)

        {
            _dbcontext = DbContext;
        }


        [HttpGet]
        public async Task<ActionResult<List<devices>>> getdevices()
        {
            var devices = await _dbcontext.devices.ToListAsync();

            if (devices.Count == 0)
            {

                return NotFound();
            }

            return Ok(devices);



        }


        [HttpGet("id")]
        public async Task<ActionResult<List<devices>>> getdevices(int id)
        {
            var device = await _dbcontext.devices.FindAsync(id);

            if (device == null)
            {

                return NotFound();
            }

            return Ok(device);


        }

        [HttpPost]
        public async Task<ActionResult<List<devices>>> postMenudevices(devices device)
        {
            try
            {


                _dbcontext.devices.Add(device);
                await _dbcontext.SaveChangesAsync();


            }
            catch (DbUpdateException)
            {

                return BadRequest();

            }
            return Ok(device);

        }


        [HttpPut]
        public async Task<ActionResult<List<devices>>> putMenudevices(int id, devices newdevice)
        {



            var device = await _dbcontext.devices.FindAsync(id);

            if (device == null)
            {

                return NotFound();
            }
            device.id = newdevice.id;
            device.Title = newdevice.Title;

            return Ok();
        }



        [HttpDelete]
        public async Task<ActionResult<List<devices>>> Deletedevices(int id)
        {

            var device = await _dbcontext.devices.FindAsync(id);

            if (device == null)
            {

                return NotFound();
            }

            _dbcontext.devices.Remove(device);

            await _dbcontext.SaveChangesAsync();

            return Ok(device);

        }

        [HttpGet("Manufacturer/{id}")]
        public async Task<ActionResult<List<devices>>> GetDevicesByManufacturerId(int id) {


            var device = await _dbcontext.devices.Where(e=> e.Menufacturer_id == id).ToListAsync();
            if (device == null)
            {

                return NotFound();
            }

        

            return Ok(device);

        }

    }
}

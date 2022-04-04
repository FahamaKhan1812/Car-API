using CARAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CARAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class MakesController : ControllerBase
    {
        private CarDBContext _db;
        public MakesController(CarDBContext db)
        {
            _db = db;
        }
       
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var makes = _db.Makes.ToList();
            return Ok(makes);
        }

        [HttpGet("GetCarByID/{id}")]
        public IActionResult Get(int id)
        {
            var makes = _db.Makes.Find(id);
            if(makes == null)
            {
                return BadRequest("No data was found with ID: "+ id);
            }
            return Ok(makes);
        }

        [HttpPost("Create")]
        public IActionResult Create(MakeModel model)
        {
            if (string.IsNullOrEmpty(model.Make))
            {
                return BadRequest("Invalid data.");
            }
            Make make   = new Make();
            make.MakeName = model.Make;
            _db.Makes.Add(make);
            _db.SaveChanges();

            return Ok(make);
        }


        [HttpPut("Update")]
        public IActionResult Update(MakeModel model)
        {
            if (model.Id == 0)
            {
                return BadRequest("Invalid ID.");
            }
            if (string.IsNullOrEmpty(model.Make))
            {
                return BadRequest("Invalid data.");
            }
            var make = _db.Makes.Find(model.Id);

            if (make is null)
                return BadRequest("Incorrect ID");

            make.MakeName = model.Make;
            _db.Makes.Attach(make);
            _db.SaveChanges(true);

            return Ok(make);
        }

        [HttpDelete("Delete/{Id}")]
        public IActionResult Delete(int id)
        {
            var make = _db.Makes.Find(id);
            if (make is null)
                return BadRequest("No record was found with an ID: "+ id.ToString());

            _db.Remove(make);
            _db.SaveChanges();

            return Ok("Deleted successfully");
        }
    }
}

using CRUD_Web_API_Creation.Data;
using CRUD_Web_API_Creation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CRUD_Web_API_Creation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public EmpController(ApplicationDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult GetEmp()
        {
            var data=db.Emps.ToList();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult AddEmp(Emp E) 
        {
            db.Emps.Add(E);
            db.SaveChanges();
            return Ok("Employee Added Sucessfully");
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveEmp(int id) 
        {
           var data= db.Emps.Find(id);
            if (data == null)
            {
                return BadRequest();
            }
            else
            {
                db.Emps.Remove(data);
                db.SaveChanges();
                return Ok("Employee Removed Succesfully");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmp(int id,Emp Ep) 
        {
            //var data =  db.Emps.Find(id);
            if(id == null)
            {
                return BadRequest();
            }
            else
            {
                db.Entry(Ep).State = EntityState.Modified;
                db.SaveChanges();
                return Ok("Employee Details Updated Succefully");
            }
        }

        [HttpGet("{name}")]
        public IActionResult SearchByNme(string name) 
        {
            var data = db.Emps.Where(x=>x.Name.Contains(name)).ToList();
            if (data.IsNullOrEmpty())
            {
                return NotFound("no name present");
            }
            else
            {
                return Ok(data);
            }
           
        }

    }
}

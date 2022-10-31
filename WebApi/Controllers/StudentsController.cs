using Microsoft.AspNetCore.Mvc;
using WebApi.Context;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly CrudContext _CrudContext;
        public StudentsController(CrudContext CrudContext)
        {
            _CrudContext = CrudContext;
        }
        
        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _CrudContext.Students;
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}", Name ="Get")]
        public Student Get(int id)
        {
            return _CrudContext.Students.SingleOrDefault(x => x.Id == id);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            _CrudContext.Students.Add(student);
            _CrudContext.SaveChanges();
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put( int id, [FromBody] Student student)
        {
            student.Id = id;
            _CrudContext.Students.Update(student);
            _CrudContext.SaveChanges();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var stud= _CrudContext.Students.FirstOrDefault(x => x.Id == id);
            if(stud!=null)
            {
                _CrudContext.Students.Remove(stud);
                _CrudContext.SaveChanges();
            }
        }
    }
}

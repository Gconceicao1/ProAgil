using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proAgil.Repository;


namespace proAgil.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public  readonly proAgilContext _context;

        public ValuesController(proAgilContext context)
        {
            _context = context;

        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
            
          {
            
            try
            {
              var results = await _context.Eventos.ToListAsync();
                
                if(results == null){
                  return BadRequest("deu ruim");
                }
                
                return Ok(results);  
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Falha ao conectar com a base de dados, tente novamente mais tarde");
            }
          
          }


        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
          try
          { 
              var results = await _context.Eventos.FirstOrDefaultAsync(x => x.id == id);

              if(results == null){
                return this.StatusCode(StatusCodes.Status404NotFound,"Este registro não existe na base de dados");
              }
              
                return Ok(results);  
          }
          catch (System.Exception)
          {
              
              return this.StatusCode(StatusCodes.Status500InternalServerError,"Falha ao conectar com a base de dados, tente novamente mais tarde");
          }
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

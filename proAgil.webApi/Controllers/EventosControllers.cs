using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proAgil.Domain;
using proAgil.Repository;

namespace proAgil.webApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class eventos : ControllerBase
    {
        private readonly IproAgilRepository _repo;

        public eventos(IproAgilRepository repo)
        {
            _repo = repo;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
            
          {
            
            try
            {
              var results = await _repo.getAllEventoAsync(true);

                return Ok(results);    
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Falha ao conectar com a base de dados, tente novamente mais tarde");
              
            }
          
          }

           [HttpGet("{eventoId}")]
        public async Task<IActionResult> Get(int eventoId)
            
          {
            
            try
            {
              var results = await _repo.getAllEventoAsyncByid(eventoId,true);
                return Ok(results);  
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Falha ao conectar com a base de dados, tente novamente mais tarde");
            }
          
          }
             [HttpGet("getByTema{tema}")]
        public async Task<IActionResult> Get(string tema)
            
          {
            
            try
            {
              var results = await _repo.getAllEventoAsyncBytema(tema,true);
                return Ok(results);  
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Falha ao conectar com a base de dados, tente novamente mais tarde");
            }
          
          }

            [HttpPost]
        public async Task<IActionResult> Post(Evento model)
            
          {
            
            try
            {
              _repo.Add(model);

              if(await _repo.SaveChangesAsync()){
                  return Created($"/api/eventos/{model.id}",model);
              }
            
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Falha ao conectar com a base de dados, tente novamente mais tarde");

               
            }
             return BadRequest();
          }
             [HttpPut("{eventoId}")]
        public async Task<IActionResult> Put(int eventoId, Evento model)
            
          {
            
            try
            {
                var evento = await _repo.getAllEventoAsyncByid(eventoId, false);
                if(evento == null){
                    return NotFound();
                }

              _repo.Update(model);

              if(await _repo.SaveChangesAsync()){
                  return Created($"/api/eventos/{model.id}",model);
              }
            
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Falha ao conectar com a base de dados, tente novamente mais tarde");

               
            }
             return BadRequest();
          }

              [HttpDelete]
        public async Task<IActionResult> Delete(int eventoId)
            
          {
            
            try
            {
                var evento = await _repo.getAllEventoAsyncByid(eventoId, false);
                if(evento == null){
                    return NotFound("exclusão falhou");
                }

              _repo.Delete(evento);

              if(await _repo.SaveChangesAsync()){
                  return Ok();
              }
            
            }
            catch (System.Exception)
            {
                
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Falha ao conectar com a base de dados, tente novamente mais tarde");

               
            }
             return BadRequest();
          }
    }
}
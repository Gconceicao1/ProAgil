using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proAgil.Domain;
using proAgil.Repository;
using proAgil.webApi.Dtos;

namespace proAgil.webApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class eventos : ControllerBase
    {
        private readonly IproAgilRepository _repo;
        private readonly IMapper _mapper;

        public eventos(IproAgilRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                var eventos = await _repo.getAllEventoAsync(true);
                var results = _mapper.Map<EventoDto[]>(eventos);
                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha ao conectar com a base de dados, tente novamente mais tarde");

            }

        }

        [HttpGet("{eventoId}")]
        public async Task<IActionResult> Get(int eventoId)

        {

            try
            {
                var evento = await _repo.getAllEventoAsyncByid(eventoId, true);
                var results = _mapper.Map<EventoDto>(evento);
                return Ok(results); 
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha ao conectar com a base de dados, tente novamente mais tarde {ex.Message}" );
            }

        }
        [HttpGet("getByTema{tema}")]
        public async Task<IActionResult> Get(string tema)

        {

            try
            {
                var results = await _repo.getAllEventoAsyncBytema(tema, true);
                return Ok(results);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha ao conectar com a base de dados, tente novamente mais tarde");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(EventoDto model)

        {

            try
            {
                var evento = _mapper.Map<Evento>(model);
                _repo.Add(evento);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/eventos/{model.id}", _mapper.Map<EventoDto>(evento));
                }

            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha ao conectar com a base de dados, tente novamente mais tarde {ex.Message}");


            }
            return BadRequest();
        }
        [HttpPut ("{id}")]
        public async Task<IActionResult> Put(int id, EventoDto model)

        {

            try
            {
                var evento = await _repo.getAllEventoAsyncByid(id, false);
                
            
                if (evento == null)
                {
                    return NotFound();

                }
                _mapper.Map(model, evento);

                _repo.Update(evento);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/eventos/{model.id}", _mapper.Map<EventoDto>(evento));
                } 

            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha ao conectar com a base de dados, tente novamente mais tarde {ex.Message}");


            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)

        {

            try
            {
                var evento = await _repo.getAllEventoAsyncByid(id, false);
                if (evento == null)
                {
                    return NotFound("exclusão falhou");
                }

                _repo.Delete(evento);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok(StatusCode(StatusCodes.Status200OK, "excluido com sucesso"));
                    
                }

            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha ao conectar com a base de dados, tente novamente mais tarde");


            }
            return BadRequest();
        }
    }
}
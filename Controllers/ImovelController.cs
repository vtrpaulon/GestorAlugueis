using System;
using GestorAlugueis.Entities;
using GestorAlugueis.Services;
using Microsoft.AspNetCore.Mvc;
using GestorAlugueis.DTOs;


namespace GestorAlugueis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImovelController : ControllerBase
    {

        private readonly ImovelService _service;

        public ImovelController(ImovelService service)
        {
            _service = service;
        }

        [HttpGet]
        ActionResult<IEnumerable<ImovelDto>> Get()
        {
            var imoveis = _service.ObterTodos();
            return Ok(imoveis);
        }

        [HttpGet("{id}")]
        public ActionResult<Imovel> Get(int id)
        {
            var imovel = _service.ObterPorId(id);
            if (imovel == null)
            {
                return NotFound();
            }
            return Ok(imovel);
        }

        [HttpPost]
        public ActionResult Post([FromBody] ImovelDto dto)
        {
            var id = _service.Criar(dto);
            return CreatedAtAction(nameof(Get), new { id }, null);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ImovelDto dto)
        {
            try
            {
                _service.Atualizar(id, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _service.Deletar(id);
            return NoContent();
        }
    }
}

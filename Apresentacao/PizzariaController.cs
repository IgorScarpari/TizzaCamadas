using Microsoft.AspNetCore.Mvc;
using Servicos;

namespace Apresentacao
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PizzariaController : ControllerBase
    {
        private IServPizzaria _servPizzaria;

        public PizzariaController(IServPizzaria servPizzaria)
        {
            _servPizzaria = servPizzaria;
        }

        [HttpPost]
        public ActionResult Inserir(InserirPizzariaDTO inserirDto)
        {
            try
            {
                _servPizzaria.Inserir(inserirDto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public ActionResult BuscarTodos()
        {
            try
            {
                var pizzarias = _servPizzaria.BuscarTodos();

                var pizzariaEnxuta = pizzarias.Select(p =>
                    new
                    {
                        Id = p.Id,
                        Nome = p.Nome
                    }).ToList();

                return Ok(pizzariaEnxuta);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/[controller]/id")]
        [HttpDelete]
        public ActionResult Remover(int id)
        {
            try
            {
                _servPizzaria.Remover(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

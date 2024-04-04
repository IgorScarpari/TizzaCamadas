using Microsoft.AspNetCore.Mvc;
using Servicos;

namespace Apresentacao
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PromoverController : ControllerBase
    {
        private IServPromover _servPromover;

        public PromoverController(IServPromover servPromover)
        {
            _servPromover = servPromover;
        }

        [HttpPost]
        public ActionResult Inserir(InserirPromoverDTO inserirDto)
        {
            try
            {
                _servPromover.Inserir(inserirDto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Route("/[Controller]/Efetivar/{id}")]
        [HttpPost]
        public ActionResult Efetivar(int id)
        {
            try
            {
                _servPromover.Efetivar(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

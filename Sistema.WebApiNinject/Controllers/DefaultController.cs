using Sistema.BS;

using System.Web.Http;

namespace Sistema.WebApiNinject.Controllers
{
    public class DefaultController : ApiController
    {
        readonly IUsuarioService _usuarioService;

        public DefaultController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_usuarioService.Listar().Count);
        }
    }
}
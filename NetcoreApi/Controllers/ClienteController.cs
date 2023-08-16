using Microsoft.AspNetCore.Mvc;
using NetcoreApi.Models;

namespace NetcoreApi.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public dynamic listarCliente()
        {

            List<Cliente> lista = new List<Cliente> { new Cliente { 
                Id = 1,
                correo = "miguel@gmail.com",
                edad = "20",
                nombre = "Miguel"
            } };

            return lista;
        }

        [HttpGet]
        [Route("listarxid")]
        public dynamic listarClientexid(int codigo)
        {

            return new Cliente
            {
                Id = codigo,
                correo = "miguel@gmail.com",
                edad = "20",
                nombre = "Miguel"
            };
        }

        [HttpPost]
        [Route("guardar")]
        public dynamic guardarCliente(Cliente cliente)
        {
            cliente.Id = 1;
            return new
            {
                success = true,
                message = "Cliente registrado",
                result = cliente
            };
        }

        [HttpPost]
        [Route("eliminar")]
        public dynamic eliminarCliente(Cliente cliente)
        {
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;

            if (token != "marco123.")
            {
                return new
                {
                    success = true,
                    message = "Cliente eliminado",
                    result = ""
                };
            }
            return new
            {
                success = true,
                message = "Cliente eliminado",
                result = cliente
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service.Dtos.Command;
using Service.Dtos.ViewModel.Cliente;
using Service.Interface.Clientes;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ClientesController : ControllerBase
    {
        private IClienteService _clienteService;
        public ClientesController(IClienteService clienteService)
        {
            this._clienteService = clienteService;
        }
        // GET api/cliente
        [HttpGet]
        public ActionResult<IEnumerable<ClienteViewModel>> Get()
        {

            var clientes = _clienteService.GetAll();

            if (clientes != null)
                return Ok(clientes);
            else
                return NotFound();
        }

        // GET api/cliente/5
        [HttpGet("{id}")]
        public ActionResult<ClienteViewModel> Get(long id)
        {
            var cliente = _clienteService.GetById(id);

            if (cliente != null)
                return Ok(cliente);
            else
                return NotFound();
        }

        // POST api/cliente
        [HttpPost]
        public void Post([FromBody] ClientCommand cliente)
        {
            _clienteService.InsertClient(cliente);
        }

        // PUT api/cliente/5
        [HttpPut]
        public void Put([FromBody] ClientCommand cliente)
        {
            _clienteService.UpdateClient(cliente);
        }

        // DELETE api/cliente/5
        [HttpDelete]
        public void Delete([FromBody] ClientCommand cliente)
        {
            _clienteService.DeleteClient(cliente);
        }
    }


}

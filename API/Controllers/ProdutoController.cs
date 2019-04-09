using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos.ViewModel.Produto;
using Service.Interface.Clientes;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            this.produtoService = produtoService;
        }

        [Route("api/[controller]")]
        [HttpGet]
        public ActionResult<IEnumerable<ProdutoViewModel>> Get()
        {
            var produtos = produtoService.GetAll();

            if (produtos != null)
                return Ok(produtos);
            else
                return NotFound();
        }

        [Route("api/[controller]/{id}")]
        [HttpGet]
        public ActionResult<IEnumerable<ProdutoViewModel>> Get(int id)
        {
            List<long> idClients = new List<long>() { id };

            var produtos = produtoService.GetAllByClient(idClients);

            if (produtos != null)
                return Ok(produtos);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("api/[controller]/clients")]
        public ActionResult<IEnumerable<ProdutoViewModel>> Get([FromQuery] List<long> idsClient = null)
        {
            var produtos = produtoService.GetAllByClient(idsClient);

            if (produtos != null)
                return Ok(produtos);
            else
                return NotFound();
        }
    }
}
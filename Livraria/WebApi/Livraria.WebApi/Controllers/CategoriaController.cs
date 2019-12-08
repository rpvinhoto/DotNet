using Livraria.Dominio.Entidades;
using Livraria.Dominio.Exceptions;
using Livraria.WebApi.Interfaces.AppServicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaAppServico _categoriaAppServico;

        public CategoriaController(ICategoriaAppServico categoriaAppServico)
        {
            _categoriaAppServico = categoriaAppServico;
        }

        // GET: api/Categoria
        [HttpGet]
        public IEnumerable<Categoria> ObterCategorias()
        {
            return _categoriaAppServico.ObterTodos();
        }

        // GET: api/Categoria/5
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterCategoria([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoria = await _categoriaAppServico.ObterPorIdAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        // PUT: api/Categoria/5
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCategoria([FromRoute] long id, [FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }

            try
            {
                _categoriaAppServico.Validar(categoria);

                await _categoriaAppServico.AtualizarAsync(categoria);
            }
            catch (DomainException de)
            {
                return BadRequest(de.Message);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExisteCategoria(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Categoria
        [HttpPost]
        public async Task<IActionResult> AdicionarCategoria([FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _categoriaAppServico.Validar(categoria);

                await _categoriaAppServico.AdicionarAsync(categoria);
            }
            catch (DomainException de)
            {
                return BadRequest(de.Message);
            }

            return CreatedAtAction("ObterCategoria", new { id = categoria.CategoriaId }, categoria);
        }

        // DELETE: api/Categoria/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverCategoria([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoria = await _categoriaAppServico.ObterPorIdAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            if (!_categoriaAppServico.Remover(categoria))
            {
                return Conflict("Categoria não pode ser excluída pois existe livro vinculado.");
            }

            return Ok(categoria);
        }

        private bool ExisteCategoria(long id)
        {
            return _categoriaAppServico.ObterTodos().Any(e => e.CategoriaId == id);
        }
    }
}
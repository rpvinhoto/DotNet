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
    public class LivroController : ControllerBase
    {
        private readonly ILivroAppServico _livroAppServico;

        public LivroController(ILivroAppServico livroAppServico)
        {
            _livroAppServico = livroAppServico;
        }

        // GET: api/Livro
        [HttpGet]
        public IEnumerable<Livro> ObterLivros()
        {
            return _livroAppServico.ObterTodosOrdenadosPorTitulo();
        }

        // GET: api/Livro/5
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterLivro([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var livro = await _livroAppServico.ObterPorIdAsync(id);

            if (livro == null)
            {
                return NotFound();
            }

            return Ok(livro);
        }

        // PUT: api/Livro/5
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarLivro([FromRoute] long id, [FromBody] Livro livro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != livro.LivroId)
            {
                return BadRequest();
            }

            try
            {
                _livroAppServico.Validar(livro);

                await _livroAppServico.AtualizarAsync(livro);
            }
            catch(DomainException de)
            {
                return BadRequest(de.Message);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExisteLivro(id))
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

        // POST: api/Livro
        [HttpPost]
        public async Task<IActionResult> AdicionarLivro([FromBody] Livro livro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _livroAppServico.Validar(livro);

                await _livroAppServico.AdicionarAsync(livro);
            }
            catch (DomainException de)
            {
                return BadRequest(de.Message);
            }

            return CreatedAtAction("ObterLivro", new { id = livro.LivroId }, livro);
        }

        // DELETE: api/Livro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverLivro([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var livro = await _livroAppServico.ObterPorIdAsync(id);

            if (livro == null)
            {
                return NotFound();
            }

            _livroAppServico.Remover(livro);

            return Ok(livro);
        }

        private bool ExisteLivro(long id)
        {
            return _livroAppServico.ObterTodos().Any(e => e.LivroId == id);
        }
    }
}
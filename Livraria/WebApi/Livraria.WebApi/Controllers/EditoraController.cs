using Livraria.Dominio.Entidades;
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
    public class EditoraController : ControllerBase
    {
        private readonly IEditoraAppServico _editoraAppServico;

        public EditoraController(IEditoraAppServico editoraAppServico)
        {
            _editoraAppServico = editoraAppServico;
        }

        // GET: api/Editora
        [HttpGet]
        public IEnumerable<Editora> ObterEditoras()
        {
            return _editoraAppServico.ObterTodos();
        }

        // GET: api/Editora/5
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterEditora([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var editora = await _editoraAppServico.ObterPorIdAsync(id);

            if (editora == null)
            {
                return NotFound();
            }

            return Ok(editora);
        }

        // PUT: api/Editora/5
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarEditora([FromRoute] long id, [FromBody] Editora editora)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != editora.EditoraId)
            {
                return BadRequest();
            }

            try
            {
                await _editoraAppServico.AtualizarAsync(editora);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExisteEditora(id))
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

        // POST: api/Editora
        [HttpPost]
        public async Task<IActionResult> AdicionarEditora([FromBody] Editora editora)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _editoraAppServico.AdicionarAsync(editora);

            return CreatedAtAction("ObterEditora", new { id = editora.EditoraId }, editora);
        }

        // DELETE: api/Editora/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverEditora([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var editora = await _editoraAppServico.ObterPorIdAsync(id);

            if (editora == null)
            {
                return NotFound();
            }

            if (!_editoraAppServico.Remover(editora))
            {
                return Conflict("Editora não pode ser excluída pois existe livro vinculado.");
            }

            return Ok(editora);
        }

        private bool ExisteEditora(long id)
        {
            return _editoraAppServico.ObterTodos().Any(e => e.EditoraId == id);
        }
    }
}
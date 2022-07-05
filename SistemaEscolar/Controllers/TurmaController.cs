using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEscolar.Context;
using SistemaEscolar.Models;

namespace SistemaEscolar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly SistemaEscolarContext _context;

        public TurmaController(SistemaEscolarContext context)
        {
            _context = context;
        }

        // GET: api/Turma
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turma>>> GetTurma()
        {
            if (_context.Turma == null || _context.Turma.Count() == 0)
            {
                return NotFound("Não há nenhuma turma cadastrada");
            }

            var listaAlunos = await _context.Aluno.ToListAsync();
            List<Turma> turmasLista = await _context.Turma.ToListAsync();

            List<string> listaAlunosAtivos = new List<string>();

            

            return await _context.Turma.ToListAsync();
        }

        // GET: api/Turma/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Turma>> GetTurma(int id)
        {
            if (_context.Turma == null || _context.Turma.Count() == 0)
            {
                return NotFound("Não há nenhuma turma cadastrada");
            }
            var turma = await _context.Turma.FindAsync(id);

            if (turma == null)
            {
                return NotFound($"A busca não retornou resultados para a turma de ID: {id}");
            }

            return turma;
        }

        // PUT: api/Turma/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTurma(int id, Turma turma)
        {
            if (id != turma.id)
            {
                return BadRequest("Nenhum identificador foi informado para alteração.");
            }

            _context.Entry(turma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurmaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Alteração realizada com sucesso!");
        }

        // POST: api/Turma
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Turma>> PostTurma(Turma turma)
        {
            var listErrors = new List<string>();
            string response = "";
            try
            {
                if (_context.Turma == null)
                {
                    if (turma.nome == string.Empty)
                        listErrors.Add("O campo está em branco. Insira um nome");
                    response = JsonSerializer.Serialize(listErrors);
                }

                else if (!TurmaExists(turma))
                {
                    _context.Turma.Add(turma);
                    await _context.SaveChangesAsync();
                    response = JsonSerializer.Serialize(turma);
                }

                else
                {
                    response = "Essa turma já existe";
                }
            }
            catch (Exception ex)
            {
                response = JsonSerializer.Serialize(ex.Message);
            }

            return CreatedAtAction("GetTurma", new { id = turma.id }, response);
        }

        // DELETE: api/Turma/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurma(int id)
        {
            if (_context.Turma == null)
            {
                return NotFound("Não há nenhum registro desta turma.");
            }
            var turma = await _context.Turma.FindAsync(id);
            if (turma == null)
            {
                return NotFound($"O id {id} não existe no sistema.");
            }

            _context.Turma.Remove(turma);
            await _context.SaveChangesAsync();

            return Ok("A turma foi removida com sucesso!");
        }

        private bool TurmaExists(int id)
        {
            return (_context.Turma?.Any(e => e.id == id)).GetValueOrDefault();
        }
        private bool TurmaExists(Turma turma)
        {
            return (_context.Turma?.Any(c => c.nome == turma.nome)).GetValueOrDefault();
        }
    }
}

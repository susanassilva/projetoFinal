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
    public class AlunoController : ControllerBase
    {
        private readonly SistemaEscolarContext _context;

        public AlunoController(SistemaEscolarContext context)
        {
            _context = context;
        }

        // GET: api/Aluno
        [HttpGet]
        public async Task<JsonResult> GetAluno()
        {
            if (_context.Aluno == null || _context.Aluno.Count() == 0)
            {
                return new JsonResult("Não há nenhum aluno cadastrado");
            }
            var alunoLista = await _context.Aluno.ToListAsync();
            var resultado = new JsonResult(new
            {
                StatusAtivo = alunoLista.FindAll(c => c.Turma.ativo == true),
            });
            return resultado;
        }

        // GET: api/Aluno/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            if (_context.Aluno == null || _context.Aluno.Count() == 0)
            {
                return NotFound("Não há nenhum aluno cadastrado");
            }
            var aluno = await _context.Aluno.FindAsync(id);

            if (aluno == null)
            {
                return NotFound($"A busca não retornou resultados para o aluno de ID: {id}");
            }

            return aluno;
        }

        // PUT: api/Aluno/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(int id, Aluno aluno)
        {
            if (id != aluno.id)
            {
                return BadRequest("Nenhum identificador foi informado para alteração.");
            }

            _context.Entry(aluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
                {
                    return NotFound("Aluno não encontrado");
                }
                else
                {
                    throw;
                }
            }

            return Ok("Alteração realizada com sucesso!");
        }

        // POST: api/Aluno
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
        {
            var listErrors = new List<string>();
            string response = "";
            try
            {
                if (_context.Aluno == null)
                {
                    if (aluno.nome == string.Empty)
                        listErrors.Add("O campo está em branco. Insira um nome");
                    response = JsonSerializer.Serialize(listErrors);
                }

                else if (!AlunoExists(aluno))
                {
                    _context.Aluno.Add(aluno);
                    await _context.SaveChangesAsync();
                    response = JsonSerializer.Serialize(aluno);
                }
                else
                {
                    response = "Esse aluno já existe";
                }
            }
            catch (Exception ex)
            {
                response = JsonSerializer.Serialize(ex.Message);
            }

            return CreatedAtAction("GetAluno", new { id = aluno.id }, response);
        }

        // DELETE: api/Aluno/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            if (_context.Aluno == null)
            {
                return NotFound("Não há nenhum aluno cadastrado");
            }
            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno == null)
            {
                return NotFound($"Esse identificador de aluno, {id}, não existe no sistema");
            }

            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();

            return Ok("O aluno foi removido com sucesso!");
        }

        private bool AlunoExists(int id)
        {
            return (_context.Aluno?.Any(e => e.id == id)).GetValueOrDefault();
        }

        private bool AlunoExists(Aluno aluno)
        {
            return (_context.Aluno?.Any(c => c.nome == aluno.nome)).GetValueOrDefault();
        }
    }
}

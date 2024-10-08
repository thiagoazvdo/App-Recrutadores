﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecrutamentoAPI.Data;
using RecrutamentoAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecrutamentoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatosController : ControllerBase
    {
        private readonly RecrutamentoContext _context;

        public CandidatosController(RecrutamentoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidato>>> GetCandidatos()
        {
            return await _context.Candidatos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Candidato>> GetCandidato(int id)
        {
            var candidato = await _context.Candidatos.FirstOrDefaultAsync(c => c.Id == id);

            if (candidato == null)
            {
                return NotFound();
            }

            return candidato;
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<Candidato>>> GetCandidatosByStatus(bool status)
        {
            return await _context.Candidatos.Where(c => c.Status == status).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Candidato>> PostCandidato(Candidato candidato)
        {
            if (!_context.Empresas.Any(e => e.Id == candidato.EmpresaId))
            {
                return BadRequest("Empresa não encontrada");
            }

            _context.Candidatos.Add(candidato);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCandidato), new { id = candidato.Id }, candidato);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidato(int id, Candidato candidato)
        {
            if (id != candidato.Id)
            {
                return BadRequest();
            }

            if (!_context.Empresas.Any(e => e.Id == candidato.EmpresaId))
            {
                return BadRequest("Empresa não encontrada");
            }

            _context.Entry(candidato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidato(int id)
        {
            var candidato = await _context.Candidatos.FindAsync(id);
            if (candidato == null)
            {
                return NotFound();
            }

            _context.Candidatos.Remove(candidato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CandidatoExists(int id)
        {
            return _context.Candidatos.Any(e => e.Id == id);
        }
    }
}

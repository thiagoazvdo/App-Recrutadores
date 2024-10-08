﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecrutamentoAPI.Data;
using RecrutamentoAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecrutamentoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly RecrutamentoContext _context;

        public EmpresasController(RecrutamentoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresas()
        {
            var empresas = await _context.Empresas.ToListAsync();
            foreach (var empresa in empresas)
            {
                var candidatos = _context.Candidatos.Where(c => c.EmpresaId == empresa.Id);
                empresa.Candidatos = candidatos?.ToListAsync().Result;
            }
            return empresas;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> GetEmpresa(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            
            if (empresa == null)
            {
                return NotFound();
            }
            
            var candidatos = _context.Candidatos.Where(c => c.EmpresaId == empresa.Id);
            empresa.Candidatos = candidatos?.ToListAsync().Result;
            
            return empresa;
        }

        [HttpPost]
        public async Task<ActionResult<Empresa>> PostEmpresa(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmpresa), new { id = empresa.Id }, empresa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpresa(int id, Empresa empresa)
        {
            if (id != empresa.Id)
            {
                return BadRequest();
            }

            _context.Entry(empresa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresaExists(id))
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
        public async Task<IActionResult> DeleteEmpresa(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }

            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpresaExists(int id)
        {
            return _context.Empresas.Any(e => e.Id == id);
        }
    }
}
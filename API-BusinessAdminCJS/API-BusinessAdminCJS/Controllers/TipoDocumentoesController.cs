using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_BusinessAdminCJS.Data;
using API_BusinessAdminCJS.Data.Entities;

namespace API_BusinessAdminCJS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoesController : ControllerBase
    {
        private readonly DataContext _context;

        public TipoDocumentoesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TipoDocumentoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDocumento>>> GetTipoDocumento()
        {
          if (_context.TipoDocumento == null)
          {
              return NotFound();
          }
            return await _context.TipoDocumento.ToListAsync();
        }

        // GET: api/TipoDocumentoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDocumento>> GetTipoDocumento(int id)
        {
          if (_context.TipoDocumento == null)
          {
              return NotFound();
          }
            var tipoDocumento = await _context.TipoDocumento.FindAsync(id);

            if (tipoDocumento == null)
            {
                return NotFound();
            }

            return tipoDocumento;
        }

        // PUT: api/TipoDocumentoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoDocumento(int id, TipoDocumento tipoDocumento)
        {
            if (id != tipoDocumento.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoDocumento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoDocumentoExists(id))
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

        // POST: api/TipoDocumentoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoDocumento>> PostTipoDocumento(TipoDocumento tipoDocumento)
        {
          if (_context.TipoDocumento == null)
          {
              return Problem("Entity set 'DataContext.TipoDocumento'  is null.");
          }
            _context.TipoDocumento.Add(tipoDocumento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoDocumento", new { id = tipoDocumento.Id }, tipoDocumento);
        }

        // DELETE: api/TipoDocumentoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoDocumento(int id)
        {
            if (_context.TipoDocumento == null)
            {
                return NotFound();
            }
            var tipoDocumento = await _context.TipoDocumento.FindAsync(id);
            if (tipoDocumento == null)
            {
                return NotFound();
            }

            _context.TipoDocumento.Remove(tipoDocumento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoDocumentoExists(int id)
        {
            return (_context.TipoDocumento?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

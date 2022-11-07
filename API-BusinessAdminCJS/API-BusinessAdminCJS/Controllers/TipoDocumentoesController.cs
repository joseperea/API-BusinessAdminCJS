using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_BusinessAdminCJS.Data;
using API_BusinessAdminCJS.Data.Entities;
using API_BusinessAdminCJS.IRepository;
using AutoMapper;
using API_BusinessAdminCJS.ModelsView;
using Microsoft.AspNetCore.Authorization;

namespace API_BusinessAdminCJS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<TipoDocumentoesController> _logger;
        private readonly IMapper _mapper;

        public TipoDocumentoesController(IUnitOfWork unitOfWork, ILogger<TipoDocumentoesController> logger,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;  
            _mapper = mapper;
        }

        // GET: api/TipoDocumentoes
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetTipoDocumento()
        {
            try
            {
                var tipoDocumentos = await _unitOfWork.TipoDocumentos.GetAll();
                var resultas = _mapper.Map<IList<TipoDocumentoDTO>>(tipoDocumentos);
                return Ok(resultas);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ocurrio un error al momento de {nameof(GetTipoDocumento)}");
                return StatusCode(500, "Error interno del servidor, inténtalo de nuevo más tarde.");
            }         
        }

        // GET: api/TipoDocumentoes/5
        [Authorize]
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetTipoDocumento(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception($"parametro {id} incorrecto");
                }


                var tipoDocumento = await _unitOfWork.TipoDocumentos.Get(t => t.Id == id/*, new List<string> { nameof(Usuario) }*/);
                var resultado = _mapper.Map<TipoDocumentoDTO>(tipoDocumento);
                return Ok(resultado);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Ocurrio un error al momento de {nameof(GetTipoDocumento)}");
                return StatusCode(500, "Error interno del servidor, inténtalo de nuevo más tarde.");
            }
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

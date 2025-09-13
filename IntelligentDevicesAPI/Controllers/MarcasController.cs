using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using IntelligentDevicesApi.Data;

[ApiController]
[Route("api/[controller]")]
public class MarcasController : ControllerBase
{
    private readonly AppDbContext _context;

    public MarcasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetMarcas()
    {
        var marcas = await _context.Marcas
            .Select(m => new {
                m.Id,
                m.Nombre
            })
            .ToListAsync();

        return Ok(marcas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Marcas>> Get(int id)
    {
        var marca = await _context.Marcas.FindAsync(id);

        if (marca == null) return NotFound(new { mensaje = "Marca no encontrada." });

        var validacion = new Marcas
        {
            Nombre = marca.Nombre,
        };

        return Ok(validacion);
    }

    [HttpPost("crear")]
    public async Task<IActionResult> CrearMarcas([FromBody] MarcasDTO nuevaMarca)
    {
        var nuevo = new Marcas
        {
            Nombre = nuevaMarca.Nombre,
        };

        _context.Marcas.Add(nuevo);
        await _context.SaveChangesAsync();

        return Ok(new { mensaje = "Marca creada exitosamente.", marcas = nuevo });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarMarca(int id, [FromBody] MarcasDTO actualizarMarca)
    {
        var marcas = await _context.Marcas.FindAsync(id);
        if (marcas == null)
            return NotFound(new { mensaje = "Marca no encontrada." });

        marcas.Nombre = actualizarMarca.Nombre;

        await _context.SaveChangesAsync();

        return Ok(new { mensaje = "Marca actualizada correctamente.", marcas });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarMarcas(int id)
    {
        var marca = await _context.Marcas.FindAsync(id);
        if (marca == null)
            return NotFound(new { mensaje = "Marca no encontrada." });

        _context.Marcas.Remove(marca);

        try
        {
            await _context.SaveChangesAsync();
            return Ok(new { mensaje = "Marca eliminada correctamente." });
        }
        catch (DbUpdateException ex)
        {
            // Verifica si el error es por restricción de clave foránea
            if (ex.InnerException?.Message.Contains("FK_Devices_Marcas") == true)
            {
                return BadRequest(new
                {
                    mensaje = "No se puede eliminar la marca porque está asociada a uno o más dispositivos."
                });
            }

            // Otro tipo de error
            return StatusCode(500, new
            {
                mensaje = "Error al eliminar la marca.",
                detalle = ex.Message
            });
        }
    }

}

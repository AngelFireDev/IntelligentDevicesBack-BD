using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using IntelligentDevicesApi.Data;

[ApiController]
[Route("api/[controller]")]
public class DispositivosController : ControllerBase
{
    private readonly AppDbContext _context;

    public DispositivosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Devices>>> GetDispositivos()
    {
        var dispositivos = await _context.Devices
        .Include(d => d.Marcas)
        .Select(d => new {
            d.Id,
            d.Nombre,
            d.Descripcion,
            d.Precio,
            d.Anio,
            Marca = d.Marcas.Nombre,
            d.Imagen
        })
        .ToListAsync();

            return Ok(dispositivos);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Devices>> Get(int id)
    {
        var dispositivo = await _context.Devices
            .Include(d => d.Marcas)
            .Include(d => d.Comentarios)
            .FirstOrDefaultAsync(d => d.Id == id);

        if (dispositivo == null) return NotFound();
        return dispositivo;
    }

    [HttpGet("DevicesName")]
    public async Task<IActionResult> GetDevices()
    {
        var marcas = await _context.Devices
            .Select(m => new {
                m.Id,
                m.Nombre
            })
            .ToListAsync();

        return Ok(marcas);
    }

    [HttpPost("crear")]
    public async Task<IActionResult> CrearDispositivo([FromBody] DispositivoDTO nuevoDispositivo)
    {
        if (nuevoDispositivo == null)
            return BadRequest(new { mensaje = "Datos inválidos." });

        var existe = await _context.Devices.AnyAsync(d => d.Nombre == nuevoDispositivo.Nombre);
        if (existe)
            return Conflict(new { mensaje = "Ya existe un dispositivo con ese nombre." });

        var dispositivo = new Devices
        {
            Nombre = nuevoDispositivo.Nombre,
            Descripcion = nuevoDispositivo.Descripcion,
            Precio = nuevoDispositivo.Precio,
            Anio = nuevoDispositivo.Anio,
            MarcasId = nuevoDispositivo.MarcaId,
            Imagen = nuevoDispositivo.Imagen,
        };

        _context.Devices.Add(dispositivo);
        await _context.SaveChangesAsync();

        return Ok(new { mensaje = "Dispositivo creado exitosamente.", dispositivo });
    }

    [HttpPost("{id}/comments")]
    public async Task<IActionResult> Comentar(int id, [FromBody] Comentarios comentario)
    {
        comentario.DevicesId = id;
        comentario.Fecha = DateTime.Now;

        _context.Comentarios.Add(comentario);
        await _context.SaveChangesAsync();

        return Ok(comentario);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarDispositivo(int id, [FromBody] DispositivoDTO actualizadoDevices)
    {
        if (actualizadoDevices == null)
            return BadRequest(new { mensaje = "Datos inválidos." });

        var dispositivo = await _context.Devices.FindAsync(id);
        if (dispositivo == null)
            return NotFound(new { mensaje = "Dispositivo no encontrado." });

        dispositivo.Nombre = actualizadoDevices.Nombre;
        dispositivo.Descripcion = actualizadoDevices.Descripcion;
        dispositivo.Precio = actualizadoDevices.Precio;
        dispositivo.Anio = actualizadoDevices.Anio;
        dispositivo.Imagen = actualizadoDevices.Imagen;
        dispositivo.MarcasId = actualizadoDevices.MarcaId;

        await _context.SaveChangesAsync();

        return Ok(new { mensaje = "Dispositivo actualizado correctamente.", dispositivo });
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDispositivo(int id)
    {
        var dispositivo = await _context.Devices.FindAsync(id);

        if (dispositivo == null)
        return NotFound(new { mensaje = "Dispositivo no encontrado." });

        _context.Devices.Remove(dispositivo);
        await _context.SaveChangesAsync();

        return Ok(new { mensaje = "Dispositivo eliminado correctamente." });
    }
}

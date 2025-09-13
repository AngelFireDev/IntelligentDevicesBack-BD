using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using IntelligentDevicesApi.Data;

[ApiController]
[Route("api/[controller]")]
public class ComentariosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ComentariosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Comentarios>>> GetComentarios()
    {
        var comentarios = await _context.Comentarios
        .Select(d => new
        {
            d.Id,
            d.Usuario,
            d.Comentario,
            d.Fecha,
            d.DevicesId
        })
        .ToListAsync();

        return Ok(comentarios);
    }

    [HttpGet("dispositivo/{id}")]
    public async Task<IActionResult> GetComentariosPorDispositivo(int id)
    {
        var comentarios = await _context.Comentarios
            .Where(c => c.DevicesId == id)
            .Select(c => new {
                c.Id,
                c.Usuario,
                c.Comentario,
                c.Fecha,
                c.DevicesId
            })
            .ToListAsync();

        return Ok(comentarios);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Comentarios>> Get(int id)
    {
        var comentario = await _context.Comentarios.FindAsync(id);

        if (comentario == null) return NotFound(new { mensaje = "Comentarios no encontrados." });

        var validacion = new Comentarios
        {
            Usuario = comentario.Usuario,
            Comentario = comentario.Comentario,
            Fecha = comentario.Fecha,
            DevicesId = comentario.DevicesId,

        };

        return Ok(validacion);
    }

    [HttpPost("crear")]
    public async Task<IActionResult> CrearComentario([FromBody] ComentariosDTO nuevoComentario)
    {
        if (string.IsNullOrWhiteSpace(nuevoComentario.Comentario))
            return BadRequest(new { mensaje = "El comentario no puede estar vacío." });

        var nuevo = new Comentarios
        {
            Usuario = nuevoComentario.Usuario,
            Comentario = nuevoComentario.Comentario,
            Fecha = DateTime.Now,
            DevicesId = nuevoComentario.DevicesId
        };

        _context.Comentarios.Add(nuevo);
        await _context.SaveChangesAsync();

        return Ok(new { mensaje = "Comentario guardado correctamente.", Comentario = nuevo });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarComentarios(int id, [FromBody] ComentariosDTO actualizarComentario)
    {
        var comentarios = await _context.Comentarios.FindAsync(id);
        if (comentarios == null)
            return NotFound(new { mensaje = "Marca no encontrada." });

        comentarios.Usuario = actualizarComentario.Usuario;
        comentarios.Comentario = actualizarComentario.Comentario;
        comentarios.Fecha = actualizarComentario.Fecha;
        comentarios.DevicesId = actualizarComentario.DevicesId;

        await _context.SaveChangesAsync();

        return Ok(new { mensaje = "Comentario actualizado correctamente.", comentarios });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarComentario(int id)
    {
        var comentario = await _context.Comentarios.FindAsync(id);
        if (comentario == null)
            return NotFound(new { mensaje = "Comentario no encontrado." });

        _context.Comentarios.Remove(comentario);
        await _context.SaveChangesAsync();

        return Ok(new { mensaje = "Comentario eliminado correctamente." });
    }

}
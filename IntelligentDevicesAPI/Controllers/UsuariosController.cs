using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using IntelligentDevicesApi.Data;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsuariosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsuarios()
    {
        var usuarios = await _context.Usuarios
            .Select(u => new {
                u.Id,
                u.TipoDocumento,
                u.NumeroDocumento,
                u.Nombres,
                u.Email,
                u.CreatedDate
            })
            .ToListAsync();

        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Usuarios>> Get(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);

        if (usuario == null) return NotFound(new { mensaje = "Usuario no encontrado." });

        var validacion = new Usuarios
        {
            TipoDocumento = usuario.TipoDocumento,
            NumeroDocumento = usuario.NumeroDocumento,
            Nombres = usuario.Nombres,
            Email = usuario.Email,
            Clave = usuario.Clave 
        };

        return Ok(validacion);
    }

    [HttpPost("crear")]
    public async Task<IActionResult> CrearUsuario([FromBody] Usuarios dto)
    {
        var nuevo = new Usuarios
        {
            TipoDocumento = dto.TipoDocumento,
            NumeroDocumento = dto.NumeroDocumento,
            Nombres = dto.Nombres,
            Email = dto.Email,
            Clave = dto.Clave,
            CreatedDate = DateTime.Now
        };

        _context.Usuarios.Add(nuevo);
        await _context.SaveChangesAsync();

        return Ok(new { mensaje = "Usuario creado exitosamente.", usuario = nuevo });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarUsuario(int id, [FromBody] Usuarios dto)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null)
            return NotFound(new { mensaje = "Usuario no encontrado." });

        usuario.TipoDocumento = dto.TipoDocumento;
        usuario.NumeroDocumento = dto.NumeroDocumento;
        usuario.Nombres = dto.Nombres;
        usuario.Email = dto.Email;
        usuario.Clave = dto.Clave;

        await _context.SaveChangesAsync();

        return Ok(new { mensaje = "Usuario actualizado correctamente.", usuario });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarUsuario(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null)
            return NotFound(new { mensaje = "Usuario no encontrado." });

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();

        return Ok(new { mensaje = "Usuario eliminado correctamente." });
    }
}

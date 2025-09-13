using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using IntelligentDevicesApi.Data;
using System.Security.Cryptography;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public LoginController(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpPost("registrar")]
    public IActionResult Registrar([FromBody] Usuarios nuevoUsuario)
    {
        if (_context.Usuarios.Any(u => u.Email == nuevoUsuario.Email))
            return BadRequest("Ya existe un usuario con ese correo.");

        using var sha = SHA256.Create();
        var hash = Convert.ToBase64String(
            sha.ComputeHash(Encoding.UTF8.GetBytes(nuevoUsuario.Clave))
        );
        nuevoUsuario.Clave = hash;
        nuevoUsuario.CreatedDate = DateTime.Now;

        _context.Usuarios.Add(nuevoUsuario);
        _context.SaveChanges();

        return Ok("Usuario registrado exitosamente.");
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDTO login)
    {
        var usuario = _context.Usuarios
            .FirstOrDefault(u => u.Email == login.Email);

        if (usuario == null)
            return Unauthorized("Usuario no encontrado");

        if (!VerificarClave(login.Clave, usuario.Clave))
            return Unauthorized("Clave incorrecta");

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Name, usuario.Nombres)
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        return Ok(new
        {
            token = tokenString,
            usuario = new
            {
                usuario.Id,
                usuario.Nombres,
                usuario.Email
            }
        });
    }

    private bool VerificarClave(string claveIngresada, string claveAlmacenada)
    {
        using var sha = SHA256.Create();
        var hash = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(claveIngresada)));
        return hash == claveAlmacenada;
    }
}

using System.Linq.Expressions;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using SimpsonsApi.Entities;
using SimpsonsApi.Repositories;

namespace SimpsonsApi.Controllers;
[ApiController]
[Route("api/characters")]
public class CharactersController : ControllerBase
{
    private readonly IQueryRepository _qr;
    private readonly ICommandRepository _cr;
    public CharactersController(IQueryRepository qr, ICommandRepository cr)
    {
        _qr = qr;
        _cr = cr;
    }
    [HttpGet]
    public async Task<IActionResult> GetAsync()
        => Ok(await _qr.GetAllAsync());

    [HttpGet]
    [Route("paged")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Character))] //For Swagger
    [ProducesResponseType(StatusCodes.Status400BadRequest)] //For Swagger
    public async Task<IActionResult> GetAsync(int pageSize, int pageIndex)
    {
        try
        {
            var c = await _qr.GetAsync(pageSize, pageIndex);
            return Ok(c);
        }
        catch (IndexOutOfRangeException)
        {
            return BadRequest();
        }
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Character))] //For Swagger
    [ProducesResponseType(StatusCodes.Status404NotFound)] //For Swagger
    public async Task<IActionResult> GetAsync(Guid id)
    {
        try
        {
            var c = await _qr.GetAsync(id);
            return Ok(c);
        }
        catch (ArgumentNullException)
        {
            return NotFound();
        }
    }
    [HttpPost]
    public async Task<IActionResult> AddCharacter(Character c)
    {
        _cr.Add(c);
        await _cr.SaveChangesAsync();
        return Ok(c);
    }
}
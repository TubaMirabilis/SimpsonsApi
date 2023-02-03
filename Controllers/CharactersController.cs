using System.Linq.Expressions;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using SimpsonsApi.Entities;
using SimpsonsApi.Exceptions;
using SimpsonsApi.Repositories;

namespace SimpsonsApi.Controllers;
[ApiController]
[Route("api/characters")]
public class CharactersController : ControllerBase
{
    private readonly IQueryRepository<Character> _qr;
    private readonly ICommandRepository<Character> _cr;
    public CharactersController(IQueryRepository<Character> qr, ICommandRepository<Character> cr)
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
        catch (IndexOutOfRangeException e)
        {
            return BadRequest(e.Message);
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
    [HttpGet("byoccupation")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Character))] //For Swagger
    [ProducesResponseType(StatusCodes.Status204NoContent)] //For Swagger
    public async Task<IActionResult> GetAsync(string occupation)
    {
        try
        {
            var result = await _qr.GetByExpressionAsync(c => c.Occupation == occupation);
            return Ok(result);
        }
        catch (CollectionEmptyException)
        {
            return NoContent();
        }
    }
    [HttpGet("byoccupationpaged")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Character))] //For Swagger
    [ProducesResponseType(StatusCodes.Status204NoContent)] //For Swagger
    [ProducesResponseType(StatusCodes.Status400BadRequest)] //For Swagger
    public async Task<IActionResult> GetAsync(string occupation, int pageSize, int pageIndex)
    {
        try
        {
            var result = await _qr.GetByExpressionAsync(c => c.Occupation == occupation, pageSize, pageIndex);
            return Ok(result);
        }
        catch (Exception e)
        {
            if (e is CollectionEmptyException)
            {
                return NoContent();
            }
            return BadRequest(e.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> AddCharacter(Character c)
    {
        _cr.Add(c);
        await _cr.SaveChangesAsync();
        return Ok(c);
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Character))] //For Swagger
    [ProducesResponseType(StatusCodes.Status404NotFound)] //For Swagger
    [ProducesResponseType(StatusCodes.Status400BadRequest)] //For Swagger
    public async Task<IActionResult> UpdateAsync(Character c)
    {
        try
        {
            await _cr.UpdateAsync(c);
        }
        catch (Exception e)
        {
            if (e is ArgumentNullException)
            {
                return NotFound();
            }
            return BadRequest(e.Message);
        }
        return Ok(c);
    }
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Character))] //For Swagger
    [ProducesResponseType(StatusCodes.Status404NotFound)] //For Swagger
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var success = await _cr.DeleteAsync(id);
        return success ? Ok($"Entity with id {id} deleted.")
            : NotFound();
    }
}
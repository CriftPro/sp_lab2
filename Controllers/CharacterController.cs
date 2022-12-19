
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Code.Services;
using code.Models;

namespace Code.Models.Controllers;

[ApiController]
[Route("api/characters")]


public class CharacterController : ControllerBase
{
    private readonly ILogger<CharacterController> _logger;
    private readonly CharacterService _characterService;


    public CharacterController(
        ILogger<CharacterController> logger,
        CharacterService characterService)
    {
        _logger = logger;
        _characterService = characterService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Characters>>> GetCharacters()
    {
        var characters = await _characterService.GetCharacters();
        return Ok(characters);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<object>> GetCharacter(Guid id)
    {
        var character = await _characterService.GetCharacter(id);
        return Ok(character);
    }

    [HttpPost]
    public async Task<ActionResult<object>> CreateCharacter(Characters characters)
    {
        
        var character = await _characterService.Create(characters);
        
        
        return  Created(character);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<object>> UpdateCharacter(Guid id,Characters characters)
    {
        var character = await _characterService.Update(id,characters);
        return Ok(character);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<object>> DeleteCharacter(Guid id)
    {
        var character = await _characterService.Delete(id);
        return NoContent();
    }


    private ObjectResult Created(object value)
    {
        return StatusCode(201, value);
    }
}

namespace core_web_api.Controllers;

using core_web_api.Models;
using core_web_api.Services.SuperHero;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class SuperHeroController : ControllerBase
{
    private readonly ISuperHeroService _superHeroService;
    private readonly ILogger<SuperHeroController> _logger;

    public SuperHeroController(ISuperHeroService superHeroService, ILogger<SuperHeroController> logger)
    {
        _superHeroService = superHeroService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<SuperHero>> GetAllHeroes()
    {
        _logger.LogInformation("Getting all heroes");
        return Ok(await _superHeroService.GetAllHeroes());
    }
    
    [Route("{id:int}")]
    [HttpGet]
    public async Task<ActionResult<SuperHero>> GetHeroById(int id)
    {
        var hero = await _superHeroService.GetHeroById(id);
        if (hero == null)
        {
            return NotFound();
        }

        return Ok(hero);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddHero(SuperHero hero)
    {
        var heroId = await _superHeroService.AddHero(hero);
        return Ok(heroId);
    }
    
    [Route("{id:int}")]
    [HttpPut]
    public async Task<IActionResult> UpdateHero(int id, SuperHero request)
    {
        var result = await _superHeroService.UpdateHero(id, request);
        return result
                   ? Ok()
                   : Problem("Update failed");
    }

    [Route("{id:int}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteHero(int id)
    {
        var result = await _superHeroService.DeleteHero(id);
        return result
                   ? Ok()
                   : Problem("Delete failed");
    }
}
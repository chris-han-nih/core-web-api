namespace core_web_api.Controllers;

using core_web_api.Models;
using core_web_api.Services.SuperHero;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class SuperHeroController : ControllerBase
{
    private readonly ISuperHeroService _superHeroService;

    public SuperHeroController(ISuperHeroService superHeroService)
    {
        _superHeroService = superHeroService;
    }

    [HttpGet]
    public async Task<ActionResult<SuperHero>> GetAllHeroes()
    {
        return Ok(_superHeroService.GetAllHeroes());
    }
    
    [Route("{id:int}")]
    [HttpGet]
    public async Task<ActionResult<SuperHero>> GetHeroById(int id)
    {
        var hero = _superHeroService.GetHeroById(id);
        if (hero == null)
        {
            return NotFound();
        }

        return Ok(hero);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddHero(SuperHero hero)
    {
        var heroId = _superHeroService.AddHero(hero);
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
        var result = _superHeroService.DeleteHero(id);
        return result
                   ? Ok()
                   : Problem("Delete failed");
    }
}
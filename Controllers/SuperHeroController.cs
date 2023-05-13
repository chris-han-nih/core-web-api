namespace core_web_api.Controllers;

using core_web_api.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class SuperHeroController : ControllerBase
{
    private static List<SuperHero> _superHeroes = new()
                                                  {
                                                      new SuperHero
                                                      {
                                                          Id = 1,
                                                          Name = "Youngjae",
                                                          FirstName = "Yoo",
                                                          LastName = "Youngjae",
                                                          Place = "Seoul"
                                                      },
                                                      new SuperHero
                                                      {
                                                          Id = 2,
                                                          Name = "Namil",
                                                          FirstName = "Han",
                                                          LastName = "Namil",
                                                          Place = "Seoul"
                                                      }
                                                  };

    public SuperHeroController()
    { }

    [HttpGet]
    public async Task<ActionResult<SuperHero>> GetAllHeroes()
    {
        return Ok(_superHeroes);
    }
    
    [Route("{id:int}")]
    [HttpGet]
    public async Task<ActionResult<SuperHero>> GetHeroById(int id)
    {
        var hero = _superHeroes.FirstOrDefault(h => h.Id == id);
        if (hero == null)
        {
            return NotFound();
        }

        return Ok(hero);
    }
    
    [HttpPost]
    public async Task<ActionResult<int>> AddHero(SuperHero hero)
    {
        SuperHeroController._superHeroes.Add(hero);
        return Ok(hero.Id);
    }
    
    
    [Route("{id:int}")]
    [HttpPut]
    public async Task<IActionResult> UpdateHero(int id, SuperHero hero)
    {
        var info = SuperHeroController._superHeroes.FirstOrDefault(h => h.Id == id);
        if (info == null)
        {
            return NotFound();
        }
        info.Name = hero.Name;
        info.FirstName = hero.FirstName;
        info.LastName = hero.LastName;
        info.Place = hero.Place;
        
        return Ok();
    }
}
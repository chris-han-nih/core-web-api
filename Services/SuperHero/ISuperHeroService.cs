namespace core_web_api.Services.SuperHero;

using core_web_api.Models;

public interface ISuperHeroService
{
    List<SuperHero> GetAllHeroes();

    SuperHero? GetHeroById(int id);

    int AddHero(SuperHero hero);

    Task<bool> UpdateHero(int id, SuperHero request);

    bool DeleteHero(int id);
}
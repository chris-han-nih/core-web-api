namespace core_web_api.Services.SuperHero;

using core_web_api.Models;

public interface ISuperHeroService
{
    Task<List<SuperHero>> GetAllHeroes();

    Task<SuperHero?> GetHeroById(int id);

    Task<int> AddHero(SuperHero hero);

    Task<bool> UpdateHero(int id, SuperHero request);

    Task<bool> DeleteHero(int id);
}
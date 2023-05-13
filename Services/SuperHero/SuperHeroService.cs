namespace core_web_api.Services.SuperHero;

using core_web_api.Data;
using core_web_api.Models;

public class SuperHeroService: ISuperHeroService
{
    private readonly DataContext _context;
    public SuperHeroService(DataContext context)
    {
        _context = context;
    }
    
    public List<SuperHero> GetAllHeroes()
    {
        return _context.SuperHeroes.ToList();
    }

    public SuperHero? GetHeroById(int id)
    {
        return _context.SuperHeroes.FirstOrDefault(h => h.Id == id);
    }

    public int AddHero(SuperHero hero)
    {
        var result = _context.SuperHeroes.Add(hero);
        _context.SaveChanges();
        return result.Entity.Id;
    }

    public async Task<bool> UpdateHero(int id, SuperHero request)
    {
        var hero = _context.SuperHeroes.FirstOrDefault(h => h.Id == id);
        if (hero == null)
        {
            return false;
        }
        
        hero.Name = request.Name;
        hero.FirstName = request.FirstName;
        hero.LastName = request.LastName;
        hero.Place = request.Place;
        await _context.SaveChangesAsync();
        
        return true;
    }

    public bool DeleteHero(int id)
    {
        var hero = _context.SuperHeroes.FirstOrDefault(h => h.Id == id);
        if (hero == null)
        {
            return false;
        }

        _context.SuperHeroes.Remove(hero);
        
        return true;
    }
}
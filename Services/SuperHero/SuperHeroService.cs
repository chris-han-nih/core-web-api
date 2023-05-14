namespace core_web_api.Services.SuperHero;

using core_web_api.Data;
using core_web_api.Models;
using Microsoft.EntityFrameworkCore;

public class SuperHeroService: ISuperHeroService
{
    private readonly DataContext _context;
    public SuperHeroService(DataContext context)
    {
        _context = context;
    }
    
    public async Task<List<SuperHero>> GetAllHeroes()
    {
        return await _context.SuperHeroes.ToListAsync();
    }

    public async Task<SuperHero?> GetHeroById(int id)
    {
        return await _context.SuperHeroes.FindAsync(id);
    }

    public async Task<int> AddHero(SuperHero hero)
    {
        var result = await _context.SuperHeroes.AddAsync(hero);
        await _context.SaveChangesAsync();
        
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

    public async Task<bool> DeleteHero(int id)
    {
        var hero = await _context.SuperHeroes.FindAsync(id);
        if (hero == null)
        {
            return false;
        }

        _context.SuperHeroes.Remove(hero);
        await _context.SaveChangesAsync();
        
        return true;
    }
}
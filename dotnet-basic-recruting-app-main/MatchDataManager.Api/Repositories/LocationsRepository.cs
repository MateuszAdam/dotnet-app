using MatchDataManager.Api.Models;
using MatchDataManager.Api.Interfaces;
using MatchDataManager.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace MatchDataManager.Api.Repositories;


public class LocationsRepository : ILocationsRepository
{
    private readonly MatchDataDbContext _context;

    public LocationsRepository(MatchDataDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddLocation(LocationModel location)
    {
        // added check if location name isnt already there      

        var existingLocation = await _context.Locations.FirstOrDefaultAsync(x => x.Name == location.Name);
        if (existingLocation != null)
        {
            var newLocation = new Location()
            {
                Name = location.Name,
                City = location.City
            };

            await _context.Locations.AddAsync(newLocation);
            await _context.SaveChangesAsync();

            return newLocation.Id;
        }
        return 0;
    }

    public async Task<int> DeleteLocation(int locationId)
    {       
        return await _context.Locations.Where(x => x.Id == locationId).ExecuteDeleteAsync();
    }

    public async Task <ICollection<LocationModel>> GetAllLocations()
    {
        return await _context.Locations.Select(location => new LocationModel()
        {
            Id = location.Id,
            Name = location.Name,
            City = location.City
        }).ToListAsync();
    }

    public async Task<LocationModel> GetLocationById(int id)
    {
        //projecting location from db to the location model class 

        return await _context.Locations.Where(x => x.Id == id)
             .Select(location => new LocationModel()
             {
                 Id = location.Id,
                 Name = location.Name,
                 City = location.City
             }).FirstOrDefaultAsync();
    }

    public async Task<int> UpdateLocation(LocationModel location)
    {
        return await _context.Locations
            .Where(x => x.Id == location.Id)
            .ExecuteUpdateAsync(l => 
                l.SetProperty(x => x.City,location.City)
                .SetProperty(x => x.Name, location.Name));
    }
}
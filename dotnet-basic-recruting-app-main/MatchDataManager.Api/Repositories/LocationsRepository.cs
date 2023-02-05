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

    public void AddLocation(LocationModel location)
    {
        // added check if location name isnt already there      

        var existingLocation = _context.Locations.FirstOrDefault(x => x.Name == location.Name);
        if (existingLocation is null)
        {
            var newLocation = new Location()
            {
                Name = location.Name,
                City = location.City
            };

            _context.Locations.Add(newLocation);
            _context.SaveChanges();
        }

    }

    public void DeleteLocation(int locationId)
    {
        // thanks to linq no need to check if not null as previously, it executes only when condition is met.

        _context.Locations.Where(x => x.Id == locationId).ExecuteDelete();
        _context.SaveChanges();
    }

    public IEnumerable<LocationModel> GetAllLocations()
    {
        return _context.Locations.Select(location => new LocationModel()
        {
            Id = location.Id,
            Name = location.Name,
            City = location.City
        }).ToList();
    }

    public LocationModel GetLocationById(int id)
    {
        //projecting location from db to the location model class 

        return _context.Locations.Where(x => x.Id == id)
             .Select(location => new LocationModel()
             {
                 Id = location.Id,
                 Name = location.Name,
                 City = location.City
             }).FirstOrDefault();
    }

    public void UpdateLocation(LocationModel location)
    {
        var existingLocation = _context.Locations.FirstOrDefault(x => x.Id == location.Id);
        if (existingLocation is null)
        {
            throw new ArgumentException("Location doesn't exist.", nameof(location));
        }

        existingLocation.City = location.City;
        existingLocation.Name = location.Name;

        _context.Locations.Update(existingLocation);
        _context.SaveChanges();
    }
}
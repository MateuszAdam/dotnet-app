using MatchDataManager.Api.Models;
using MatchDataManager.Api.Interfaces;

namespace MatchDataManager.Api.Repositories;


public class LocationsRepository : ILocationsRepository
{
    private readonly List<Location> _locations;
    private readonly Location _location;

    LocationsRepository(Location location)
    {
        _locations = new List<Location>();
        this._location = location;
    }



    public void AddLocation(Location location)
    {
        //sprawdzenie czy dane location o danej nazwie już istnieje i jesli nie to dodanie 
        
        var locationAlreadyExists = _locations.FirstOrDefault(x => x.Name == location.Name);

        if(locationAlreadyExists == null)
        {
            location.Id = Guid.NewGuid();
            _locations.Add(location);
        }
       
    }

    public void DeleteLocation(Guid locationId)
    {
        var location = _locations.FirstOrDefault(x => x.Id == locationId);
        if (location is not null)
        {
            _locations.Remove(location);
        }
    }

    public IEnumerable<Location> GetAllLocations()
    {
        return _locations;
    }

    public Location GetLocationById(Guid id)
    {
        return _locations.FirstOrDefault(x => x.Id == id);
    }

    public void UpdateLocation(Location location)
    {
        var existingLocation = _locations.FirstOrDefault(x => x.Id == location.Id);
        if (existingLocation is null || location is null)
        {
            throw new ArgumentException("Location doesn't exist.", nameof(location));
        }

        existingLocation.City = location.City;
        existingLocation.Name = location.Name;
    }
}


//public static class LocationsRepository
//{
//    private static readonly List<Location> _locations = new();

//    public static void AddLocation(Location location)
//    {
//        location.Id = Guid.NewGuid();
//        _locations.Add(location);
//    }

//    public static void DeleteLocation(Guid locationId)
//    {
//        var location = _locations.FirstOrDefault(x => x.Id == locationId);
//        if (location is not null)
//        {
//            _locations.Remove(location);
//        }
//    }

//    public static IEnumerable<Location> GetAllLocations()
//    {
//        return _locations;
//    }

//    public static Location GetLocationById(Guid id)
//    {
//        return _locations.FirstOrDefault(x => x.Id == id);
//    }

//    public static void UpdateLocation(Location location)
//    {
//        var existingLocation = _locations.FirstOrDefault(x => x.Id == location.Id);
//        if (existingLocation is null || location is null)
//        {
//            throw new ArgumentException("Location doesn't exist.", nameof(location));
//        }

//        existingLocation.City = location.City;
//        existingLocation.Name = location.Name;
//    }
//}
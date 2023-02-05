using MatchDataManager.Api.Models;

namespace MatchDataManager.Api.Interfaces
{
    public interface ILocationsRepository
    {
        void AddLocation(LocationModel location);
        void DeleteLocation(int locationId);
        IEnumerable<LocationModel> GetAllLocations();
        LocationModel GetLocationById(int id);
        void UpdateLocation(LocationModel location);
    }
}

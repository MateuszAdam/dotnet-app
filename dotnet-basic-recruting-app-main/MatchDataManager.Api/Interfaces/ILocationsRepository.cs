using MatchDataManager.Api.Models;

namespace MatchDataManager.Api.Interfaces
{
    public interface ILocationsRepository
    {
        Task<int> AddLocation(LocationModel location);
        Task<int> DeleteLocation(int locationId);
        Task<ICollection<LocationModel>> GetAllLocations();
        Task<LocationModel> GetLocationById(int id);
        Task<int> UpdateLocation(LocationModel location);
    }
}

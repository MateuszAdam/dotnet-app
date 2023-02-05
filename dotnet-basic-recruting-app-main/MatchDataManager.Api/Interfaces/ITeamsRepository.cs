using MatchDataManager.Api.Models;

namespace MatchDataManager.Api.Interfaces
{
    public interface ITeamsRepository
    {
        Task<int> AddTeam(TeamModel team);
        Task<int> DeleteTeam(int teamId);
        Task<ICollection<TeamModel>> GetAllTeams();
        Task<TeamModel> GetTeamById(int id);
        Task<int> UpdateTeam(TeamModel team);
    }
}

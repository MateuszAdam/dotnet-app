using MatchDataManager.Api.Models;

namespace MatchDataManager.Api.Interfaces
{
    public interface ITeamsRepository
    {
        void AddTeam(TeamModel team);
        void DeleteTeam(int teamId);
        IEnumerable<TeamModel> GetAllTeams();
        TeamModel GetTeamById(int id);
        void UpdateTeam(TeamModel team);
    }
}

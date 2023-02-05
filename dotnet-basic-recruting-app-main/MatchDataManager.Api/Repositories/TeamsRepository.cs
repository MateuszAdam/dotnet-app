using MatchDataManager.Api.Data;
using MatchDataManager.Api.Interfaces;
using MatchDataManager.Api.Models;

namespace MatchDataManager.Api.Repositories;

public class TeamsRepository : ITeamsRepository
{
    private readonly MatchDataDbContext _matchDataDbContext;
    
    TeamsRepository(MatchDataDbContext matchDataDbContext)
    {
      _matchDataDbContext = matchDataDbContext;
    }

    public void AddTeam(TeamModel team)
    {
        //var teamAlreadyExists = _teams.FirstOrDefault(x => x.Name == team.Name);

        //if (teamAlreadyExists == null)
        //{
           
        //    _teams.Add(team);
        //}

    }

    public void DeleteTeam(int teamId)
    {
        //var team = _teams.FirstOrDefault(x => x.Id == teamId);
        //if (team is not null)
        //{
        //    _teams.Remove(team);
        //}
    }

    public IEnumerable<TeamModel> GetAllTeams()
    {
       // return _teams;
    }

    public TeamModel GetTeamById(int id)
    {
      //  return _teams.FirstOrDefault(x => x.Id == id);
    }

    public void UpdateTeam(TeamModel team)
    {
        //var existingTeam = _teams.FirstOrDefault(x => x.Id == team.Id);
        //if (existingTeam is null || team is null)
        //{
        //    throw new ArgumentException("Team doesn't exist.", nameof(team));
        //}

        //existingTeam.CoachName = team.CoachName;
        //existingTeam.Name = team.Name;
    }
}












//using MatchDataManager.Api.Models;

//namespace MatchDataManager.Api.Repositories;

//public class TeamsRepository
//{
//    private static readonly List<Team> _teams = new();

//    public static void AddTeam(Team team)
//    {
//        var teamAlreadyExists = _teams.FirstOrDefault(x => x.Name == team.Name);

//        if (teamAlreadyExists == null)
//        {
//            team.Id = Guid.NewGuid();
//            _teams.Add(team);
//        }

//    }

//    public static void DeleteTeam(Guid teamId)
//    {
//        var team = _teams.FirstOrDefault(x => x.Id == teamId);
//        if (team is not null)
//        {
//            _teams.Remove(team);
//        }
//    }

//    public static IEnumerable<Team> GetAllTeams()
//    {
//        return _teams;
//    }

//    public static Team GetTeamById(Guid id)
//    {
//        return _teams.FirstOrDefault(x => x.Id == id);
//    }

//    public static void UpdateTeam(Team team)
//    {
//        var existingTeam = _teams.FirstOrDefault(x => x.Id == team.Id);
//        if (existingTeam is null || team is null)
//        {
//            throw new ArgumentException("Team doesn't exist.", nameof(team));
//        }

//        existingTeam.CoachName = team.CoachName;
//        existingTeam.Name = team.Name;
//    }
//}
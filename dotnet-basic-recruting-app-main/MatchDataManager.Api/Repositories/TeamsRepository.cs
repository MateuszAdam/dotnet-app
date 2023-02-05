using MatchDataManager.Api.Data;
using MatchDataManager.Api.Interfaces;
using MatchDataManager.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchDataManager.Api.Repositories;

public class TeamsRepository : ITeamsRepository
{
    private readonly MatchDataDbContext _context;
    
    TeamsRepository(MatchDataDbContext context)
    {
        _context = context;
    }

    public void AddTeam(TeamModel team)
    {
        var existingTeam = _context.Teams.FirstOrDefault(x => x.Name == team.Name);
        if (existingTeam is null)
        {
            var newTeam = new Team()
            {
                Name = team.Name,
                CoachName = team.CoachName,
            };

            _context.Teams.Add(newTeam);
            _context.SaveChanges();
        }
    }

    public void DeleteTeam(int teamId)
    {
        _context.Teams.Where(x => x.Id == teamId).ExecuteDelete();
        _context.SaveChanges();
    }

    public IEnumerable<TeamModel> GetAllTeams()
    {
        return _context.Teams.Select(team => new TeamModel()
        {
            Id = team.Id,
            Name = team.Name,
            CoachName = team.CoachName
        }).ToList();
    }

    public TeamModel GetTeamById(int id)
    {
        return _context.Teams.Where(x => x.Id == id)
             .Select(team => new TeamModel()
             {
                 Id = team.Id,
                 Name = team.Name,
                 CoachName = team.CoachName,
             }).FirstOrDefault();
    }

    public void UpdateTeam(TeamModel team)
    {
        var existingTeam = _context.Teams.FirstOrDefault(x => x.Id == team.Id);
        if (existingTeam is null)
        {
            throw new ArgumentException("Team doesn't exist.", nameof(team));
        }

        existingTeam.CoachName = team.CoachName;
        existingTeam.Name = team.Name;

        _context.Teams.Update(existingTeam);
        _context.SaveChanges();
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
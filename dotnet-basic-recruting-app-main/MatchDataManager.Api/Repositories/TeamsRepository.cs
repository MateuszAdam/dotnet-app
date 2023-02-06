using MatchDataManager.Api.Data;
using MatchDataManager.Api.Interfaces;
using MatchDataManager.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchDataManager.Api.Repositories;

public class TeamsRepository : ITeamsRepository
{
    private readonly MatchDataDbContext _context;
    
    public TeamsRepository(MatchDataDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddTeam(TeamModel team)
    {
        var existingTeam = await _context.Teams.FirstOrDefaultAsync(x => x.Name == team.Name);
        if (existingTeam is null)
        {
            var newTeam = new Team()
            {
                Name = team.Name,
                CoachName = team.CoachName,
            };

            await _context.Teams.AddAsync(newTeam);
            await _context.SaveChangesAsync();
            
            return newTeam.Id;
        }
        return 0;
    }

    public async Task<int> DeleteTeam(int teamId)
    {
        return await _context.Teams.Where(x => x.Id == teamId).ExecuteDeleteAsync();
    }

    public async Task<ICollection<TeamModel>> GetAllTeams()
    {
        return await _context.Teams.Select(team => new TeamModel()
        {
            Id = team.Id,
            Name = team.Name,
            CoachName = team.CoachName
        }).ToListAsync();
    }

    public async Task<TeamModel> GetTeamById(int id)
    {
        return await _context.Teams.Where(x => x.Id == id)
             .Select(team => new TeamModel()
             {
                 Id = team.Id,
                 Name = team.Name,
                 CoachName = team.CoachName,
             }).FirstOrDefaultAsync();
    }

    public async Task<int> UpdateTeam(TeamModel team)
    {
        return await _context.Teams
           .Where(x => x.Id == team.Id)
           .ExecuteUpdateAsync(l =>
               l.SetProperty(x => x.Name, team.Name)
               .SetProperty(x => x.CoachName, team.CoachName));
    }
}
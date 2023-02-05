﻿using MatchDataManager.Api.Interfaces;
using MatchDataManager.Api.Models;

namespace MatchDataManager.Api.Repositories;

public class TeamsRepository : ITeamsRepository
{   
    private readonly List<Team> _teams;
    private readonly Team _team;

    TeamsRepository(Team team, ITeamsRepository teamsRepository)
    {
        _teams = new List<Team>();
        this._team = team;
    }

    public void AddTeam(Team team)
    {
        var teamAlreadyExists = _teams.FirstOrDefault(x => x.Name == team.Name);

        if (teamAlreadyExists == null)
        {
            team.Id = Guid.NewGuid();
            _teams.Add(team);
        }

    }

    public void DeleteTeam(Guid teamId)
    {
        var team = _teams.FirstOrDefault(x => x.Id == teamId);
        if (team is not null)
        {
            _teams.Remove(team);
        }
    }

    public IEnumerable<Team> GetAllTeams()
    {
        return _teams;
    }

    public Team GetTeamById(Guid id)
    {
        return _teams.FirstOrDefault(x => x.Id == id);
    }

    public void UpdateTeam(Team team)
    {
        var existingTeam = _teams.FirstOrDefault(x => x.Id == team.Id);
        if (existingTeam is null || team is null)
        {
            throw new ArgumentException("Team doesn't exist.", nameof(team));
        }

        existingTeam.CoachName = team.CoachName;
        existingTeam.Name = team.Name;
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
using MatchDataManager.Api.Interfaces;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MatchDataManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TeamsController : ControllerBase
{
    private readonly ITeamsRepository _teamsRepository = null;

    public TeamsController(ITeamsRepository teamsRepository)
    {
        _teamsRepository = teamsRepository;
    }

    [HttpPost]
    public IActionResult AddTeam(TeamModel team)
    {
        //walidacja do dodania - metoda powinna coœ zwróciæ - id i albo createdAtAction i success albo no NotFound()

        _teamsRepository.AddTeam(team);
        return CreatedAtAction(nameof(AddTeam), new {id = team.Id}, team);
    }

    [HttpDelete]
    public IActionResult DeleteTeam(int teamId)
    {
        _teamsRepository.DeleteTeam(teamId);
        return NoContent();
    }

    //changed the action name from Get to GetAllTeams -> to point what the action is actually doing
    [HttpGet]
    public IActionResult GetAllTeams()
    {
        var teams = _teamsRepository.GetAllTeams();

        return CreatedAtAction(nameof(UpdateTeam), teams);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var team = _teamsRepository.GetTeamById(id);
        if (team is null)
        {
            return NotFound();
        }

        return CreatedAtAction(nameof(GetById), team);
    }

    [HttpPut]
    public IActionResult UpdateTeam(TeamModel team)
    {       
        _teamsRepository.UpdateTeam(team);        
        return CreatedAtAction(nameof(UpdateTeam), team);        
    }
}
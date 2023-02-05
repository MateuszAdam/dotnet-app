using MatchDataManager.Api.Interfaces;
using MatchDataManager.Api.Models;
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
    public async Task<IActionResult> AddTeam(TeamModel team)
    {
        if (ModelState.IsValid)
        {
            int id = await _teamsRepository.AddTeam(team);
            if (id > 0)
            {
                return CreatedAtAction(nameof(GetById), new { id = team.Id }, team);
            }
        }
        return BadRequest();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTeam(int teamId)
    {       
        var id = await _teamsRepository.DeleteTeam(teamId);
        if (id > 0)
        {
            return NoContent();
        }

        return NotFound();
    }

    //changed the action name from Get to GetAllTeams -> to point what the action is actually doing
    [HttpGet]
    public async Task<IActionResult> GetAllTeams()
    {
        var teams =  await _teamsRepository.GetAllTeams();

        if (teams is null)
        {
            return NotFound();
        }

        return CreatedAtAction(nameof(UpdateTeam), teams); 
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var team =  await _teamsRepository.GetTeamById(id);
        if (team is null)
        {
            return NotFound();
        }

        return CreatedAtAction(nameof(GetById), team);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTeam(TeamModel team)
    {
        if (ModelState.IsValid)
        {
            var id = await _teamsRepository.UpdateTeam(team);

            if (id > 0)
            {
                return CreatedAtAction(nameof(UpdateTeam), team);
            }
        }
        return NotFound();
    }
}
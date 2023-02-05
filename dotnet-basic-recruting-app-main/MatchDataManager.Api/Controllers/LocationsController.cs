using MatchDataManager.Api.Interfaces;
using MatchDataManager.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace MatchDataManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationsController : ControllerBase
{
    private readonly ILocationsRepository _locationsRepository = null;

    public LocationsController(ILocationsRepository locationsRepository)
    {
        _locationsRepository = locationsRepository;
    }
        
    [HttpPost]
    public async Task<IActionResult> AddLocation(LocationModel location)
    {
        if (ModelState.IsValid)
        {
            int id = await _locationsRepository.AddLocation(location);
            if (id > 0)
            {
                ModelState.Clear();
                return CreatedAtAction(nameof(GetById), new { id = location.Id }, location);
            }
        }
       
        return BadRequest();        
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteLocation(int locationId)
    {
       var id = await _locationsRepository.DeleteLocation(locationId);
        if (id > 0)
        {
            return NoContent();
        }

        return NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllLocations()
    {
        var locations = await _locationsRepository.GetAllLocations();

        if(locations != null && locations.Count > 0)
        {
            return CreatedAtAction(nameof(GetAllLocations), locations);
        }
        return NoContent();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var location = await _locationsRepository.GetLocationById(id);
        if (location is null)
        {
            return NotFound();
        }

        return CreatedAtAction(nameof(GetById), location);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateLocation(LocationModel location)
    {
        if (ModelState.IsValid)
        {
            var id = await _locationsRepository.UpdateLocation(location);

            if (id > 0)
            {
                return CreatedAtAction(nameof(UpdateLocation), location);
            }
        }

        return NotFound();
    }
}
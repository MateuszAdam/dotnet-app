using MatchDataManager.Api.ActionFilters;
using MatchDataManager.Api.Interfaces;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MatchDataManager.Api.Controllers;

[ApiController]
//[LocationActionFilter] 
[Route("[controller]")]
public class LocationsController : ControllerBase
{
    private readonly ILocationsRepository _locationsRepository = null;

    public LocationsController(ILocationsRepository locationsRepository)
    {
        _locationsRepository = locationsRepository;
    }

    // I need to refactor it later making all methods async and returning the result from the methods

    [HttpPost]
    public IActionResult AddLocation(LocationModel location)
    {
        _locationsRepository.AddLocation(location);
        return CreatedAtAction(nameof(AddLocation), new { id = location.Id }, location);
    }

    [HttpDelete]
    public IActionResult DeleteLocation(int locationId)
    {
        _locationsRepository.DeleteLocation(locationId);
        return NoContent();
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var locations = _locationsRepository.GetAllLocations();
        return CreatedAtAction(nameof(GetAll), locations);

    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var location = _locationsRepository.GetLocationById(id);
        if (location is null)
        {
            return NotFound();
        }

        return CreatedAtAction(nameof(GetById), location);
    }

    [HttpPut]
    public IActionResult UpdateLocation(LocationModel location)
    {
        _locationsRepository.UpdateLocation(location);
        return CreatedAtAction(nameof(UpdateLocation), location);
    }
}
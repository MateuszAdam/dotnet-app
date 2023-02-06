using MatchDataManager.Api.Interfaces;
using MatchDataManager.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

    // instead of calling the repository methods here there could be another layer of service
    // which would call the repository methods to proceed with the action
        
    [HttpPost]    
    public async Task<IActionResult> AddLocation(LocationModel location)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError("", "Please check added values for errors");
        }
        else
        {
            int id = await _locationsRepository.AddLocation(location);
            if (id > 0)
            {
                return CreatedAtAction(nameof(GetById), new { id = location.Id }, location);
            }
        }
        ModelState.AddModelError("", "Added name already exists in db");
        return BadRequest(ModelState);        
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
            return Ok(locations);
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

        return Ok(location);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateLocation(LocationModel location)
    {
        if (ModelState.IsValid)
        {
            var id = await _locationsRepository.UpdateLocation(location);

            if (id > 0)
            {
                return Ok(location);
            }
        }
        ModelState.AddModelError("", "Please check added values for errors");

        return NotFound(ModelState);
    }
        
}
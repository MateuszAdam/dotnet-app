using MatchDataManager.Api.ActionFilters;
using MatchDataManager.Api.Models;
using MatchDataManager.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MatchDataManager.Api.Controllers;

[ApiController]
[LocationActionFilter]
[Route("[controller]")]
public class LocationsController : ControllerBase
{
    [HttpPost]
    public IActionResult AddLocation(LocationModel location)
    {
     //   LocationsRepository.AddLocation(location);
        return CreatedAtAction(nameof(GetById), new {id = location.Id}, location);
    }

    [HttpDelete]
    public IActionResult DeleteLocation(int locationId)
    {
      //  LocationsRepository.DeleteLocation(locationId);
        return NoContent();
    }

    [HttpGet]
    public IActionResult Get()
    {
        //   return Ok(LocationsRepository.GetAllLocations());
        return Ok();
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        //var location = LocationsRepository.GetLocationById(id);
        //if (location is null)
        //{
        //    return NotFound();
        //}

        //return Ok(location);
        return Ok();
    }

    [HttpPut]
    public IActionResult UpdateLocation(LocationModel location)
    {
        //LocationsRepository.UpdateLocation(location);
        //return Ok(location);
        return Ok();
    }
}
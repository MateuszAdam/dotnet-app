using System.ComponentModel.DataAnnotations;

namespace MatchDataManager.Api.Models;

public class LocationModel 
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Please enter the location name")]    
    [MaxLength (255)]
    [DataType(DataType.Text)]
    public string Name { get; set; }
    [Required(ErrorMessage = "Please enter the city")]
    [MaxLength(55)]
    [DataType(DataType.Text)]
    public string City { get; set; }
}

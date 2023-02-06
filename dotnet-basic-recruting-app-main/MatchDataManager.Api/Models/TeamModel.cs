using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace MatchDataManager.Api.Models;

public class TeamModel
{    
    public int Id { get; set; }
    [Required(ErrorMessage = "Please enter the team name")]
    [MaxLength(255)]
    [DataType(DataType.Text)]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please enter the coach name")]
    [MaxLength(55)]
    [DataType(DataType.Text)]
    public string CoachName { get; set; }
}
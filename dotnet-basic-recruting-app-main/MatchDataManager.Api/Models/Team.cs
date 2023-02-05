using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace MatchDataManager.Api.Models;

public class Team : Entity
{    
    [Required]
    [MaxLength(255)]
    public string Name { get; set; }
    
    [MaxLength(55)]    
    public string CoachName { get; set; }
}
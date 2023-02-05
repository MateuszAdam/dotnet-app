using System.ComponentModel.DataAnnotations;

namespace MatchDataManager.Api.Data
{
    public class Team
    {
        public int Id { get; set; }       
        public string Name { get; set; }
        public string CoachName { get; set; }
    }
}

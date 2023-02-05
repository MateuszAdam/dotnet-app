using System.ComponentModel.DataAnnotations;

namespace MatchDataManager.Api.Data
{
    public class Location
    {
        public int Id { get; set; }       
        public string Name { get; set; }        
        public string City { get; set; }
    }
}

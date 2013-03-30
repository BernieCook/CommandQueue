using System.ComponentModel.DataAnnotations;

namespace CommandQueue.Web.Models.SimulationModels
{
    public class MovieLookupModel
    {
        [Required]
        public string MovieTitleAndReleaseYear { get; set; }

        [Required]
        public string EmailAddress { get; set; }
    }
}
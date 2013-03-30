using System.ComponentModel.DataAnnotations;

namespace CommandQueue.Web.Models.SimulationModels
{
    public class LeaveReplyModel
    {
        [Required]
        public string Reply { get; set; }

        [Required]
        public string EmailAddress { get; set; }
    }
}
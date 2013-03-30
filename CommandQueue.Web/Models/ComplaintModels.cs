using System.ComponentModel.DataAnnotations;

namespace CommandQueue.Web.Models.SimulationModels
{
    public class SendComplaintModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Complaint { get; set; }

        [Required]
        public string Level { get; set; }
    }
}
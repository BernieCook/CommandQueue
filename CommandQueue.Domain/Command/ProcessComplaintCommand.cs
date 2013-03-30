using CommandQueue.Domain.Interfaces;
using CommandQueue.Domain.Model;

namespace CommandQueue.Domain.Command
{
    public class ProcessComplaintCommand : ICommand
    {
        public ComplaintEntity ComplaintEntity { get; set; }

        public void Execute()
        {
            ComplaintEntity.HandleComplaint();
        }
    }
}

using CommandQueue.Domain.Azure;
using CommandQueue.Domain.Command;
using CommandQueue.Domain.Interfaces;
using CommandQueue.Domain.Model;

namespace CommandQueue.Domain.Services
{
    public class ComplaintService : IComplaintService
    {
        /// <summary>
        /// Save the complaint, for later processing.
        /// </summary>
        /// <param name="fullName">Complaint person's full name.</param>
        /// <param name="complaint">The complaint.</param>
        /// <param name="level">Level of complaint.</param>
        public void ProcessComplaint(
            string fullName, 
            string complaint, 
            string level)
        {
            var complaintEntity = new ComplaintEntity
            {
                FullName = fullName,
                Complaint = complaint,
                Level = level
            };

            var processComplaintCommand = new ProcessComplaintCommand
            {
                ComplaintEntity = complaintEntity
            };

            var queue = new Queue();
            queue.AddMessage(processComplaintCommand);
        }
    }
}

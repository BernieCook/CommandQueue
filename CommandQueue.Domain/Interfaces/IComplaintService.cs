namespace CommandQueue.Domain.Interfaces
{
    public interface IComplaintService
    {
        void ProcessComplaint(string fullName, string complaint, string level);
    }
}

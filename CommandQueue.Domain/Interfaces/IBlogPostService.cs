namespace CommandQueue.Domain.Interfaces
{
    public interface IBlogPostService
    {
        void LeaveReply(string reply, string emailAddress);
    }
}

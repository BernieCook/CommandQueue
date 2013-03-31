using CommandQueue.Domain.Interfaces;
using CommandQueue.Domain.Model;

namespace CommandQueue.Domain.Command
{
    public class NewBlogPostReplyCommand : ICommand
    {
        public BlogPostReplyEntity BlogPostReplyEntity { get; set; }
      
        public void Execute()
        {
            BlogPostReplyEntity.NotifyModerators();
        }
    }
}

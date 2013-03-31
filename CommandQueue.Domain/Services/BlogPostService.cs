using CommandQueue.Domain.Azure;
using CommandQueue.Domain.Command;
using CommandQueue.Domain.Interfaces;
using CommandQueue.Domain.Model;

namespace CommandQueue.Domain.Services
{
    public class BlogPostService : IBlogPostService
    {
        /// <summary>
        /// Leave a reply for the designated recipients.
        /// </summary>
        /// <param name="reply">Reply to be left.</param>
        /// <param name="emailAddress">User's email address.</param>
        public void LeaveReply(
            string reply,
            string emailAddress)
        {
            // Persist the data to table storage.
            var blogPostReplyEntity = new BlogPostReplyEntity
                {
                    Reply = reply,
                    EmailAddress = emailAddress
                };

            var table = new Table();
            table.AddEntity(blogPostReplyEntity);

            // Create the command object.
            var dispatchMessageCommand = new NewBlogPostReplyCommand
                {  
                    BlogPostReplyEntity = blogPostReplyEntity
                };

            // Add the command into queue storage, for later processing.
            var queue = new Queue();
            queue.AddMessage(dispatchMessageCommand);
        }
    }
}

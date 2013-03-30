using CommandQueue.Domain.Interfaces;
using CommandQueue.Domain.Services;
using CommandQueue.Web.Models.SimulationModels;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CommandQueue.Web.ApiControllers
{
    public class BlogPostController : ApiController
    {
        private readonly IBlogPostService _blogPost;

        public BlogPostController()
        {
            // Use DI here. 
            _blogPost = new BlogPostService();
        }

        //
        // POST: /api/blog-post/leave-reply/

        [ActionName("leave-reply")]
        public HttpResponseMessage Post(
            LeaveReplyModel leaveReplyModel)
        {
            if (ModelState.IsValid)
            {
                _blogPost.LeaveReply(
                    leaveReplyModel.Reply,
                    leaveReplyModel.EmailAddress);

                return new HttpResponseMessage(HttpStatusCode.OK);
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}

using CommandQueue.Domain.Interfaces;
using CommandQueue.Domain.Model;

namespace CommandQueue.Domain.Command
{
    public class MovieLookupCommand : ICommand
    {
        public MovieEntity MovieEntity { get; set; }

        public void Execute()
        {
            MovieEntity.SendTotalMovieReviewsToRecipient();
        }
    }
}

using CommandQueue.Domain.Azure;
using CommandQueue.Domain.Command;
using CommandQueue.Domain.Interfaces;
using CommandQueue.Domain.Model;

namespace CommandQueue.Domain.Services
{
    public class MovieService : IMovieService
    {
        /// <summary>
        /// Email the total movie reviews to the noted address.
        /// </summary>
        /// <param name="movieTitleAndReleaseYear">Movie title and release year.</param>
        /// <param name="emailAddress">The email address to send the results to.</param>
        public void EmailTotalReviews(
            string movieTitleAndReleaseYear,
            string emailAddress)
        {
            var movieEntity = new MovieEntity
            {
                MovieTitleAndReleaseYear = movieTitleAndReleaseYear,
                EmailAddress = emailAddress
            };

            var movieLookupCommand = new MovieLookupCommand
            {
                MovieEntity = movieEntity
            };

            var queue = new Queue();
            queue.AddMessage(movieLookupCommand);
        }
    }
}

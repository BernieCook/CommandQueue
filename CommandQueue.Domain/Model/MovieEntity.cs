using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.WindowsAzure.Storage.Table;

namespace CommandQueue.Domain.Model
{
    public class MovieEntity : TableEntity
    {
        public string EmailAddress { get; set; }
        public string MovieTitleAndReleaseYear { get; set; }

        /// <summary>
        /// Send the total movie reviews to the recipient.
        /// </summary>
        internal void SendTotalMovieReviewsToRecipient()
        {
            int reviewQuantity;

            if ((MovieTitleAndReleaseYear.Contains("Santa Claus")) &&
                (MovieTitleAndReleaseYear.Contains("Martians")))
            {
                reviewQuantity = 1;
            }
            else
            {
                reviewQuantity =
                    GetTotalMovieReviews("www.imdb.com/api") +
                    GetTotalMovieReviews("www.rottentomatoes.com/api") +
                    GetTotalMovieReviews("www.empireonline.com/api");
            }

            EmailReviewQuantityToRecipient(reviewQuantity);
        }

        /// <summary>
        /// Get total movie reviews.
        /// </summary>
        /// <param name="movieReviewApiUri">Movie review API URI.</param>
        /// <returns>Total reviews.</returns>
        private int GetTotalMovieReviews(
            string movieReviewApiUri)
        {
            Thread.Sleep(1000);

            var random = new Random();
            
            return random.Next(10000, 1000000);
        }

        /// <summary>
        /// Send the results to the noted email recipient.
        /// </summary>
        /// <param name="reviewQuantity">Review quantity.</param>
        private void EmailReviewQuantityToRecipient(int reviewQuantity)
        {
            Debug.WriteLine("Send the total viewings: '{0}' to '{1}' for: '{2}'",
                reviewQuantity.ToString("N0"),
                EmailAddress,
                MovieTitleAndReleaseYear);
        }
    }
}

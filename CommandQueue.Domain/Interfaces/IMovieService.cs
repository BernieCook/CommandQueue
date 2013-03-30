namespace CommandQueue.Domain.Interfaces
{
    public interface IMovieService
    {
        void EmailTotalReviews(string movieTitleAndReleaseYear, string emailAddress);
    }
}

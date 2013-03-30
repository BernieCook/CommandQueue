using CommandQueue.Domain.Interfaces;
using CommandQueue.Domain.Services;
using CommandQueue.Web.Models.SimulationModels;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CommandQueue.Web.ApiControllers
{
    public class MovieController : ApiController
    {
        private readonly IMovieService _movieService;

        public MovieController()
        {
            // Use DI here. 
            _movieService = new MovieService();
        }

        //
        // POST: /api/movie/lookup/

        [ActionName("lookup")]
        public HttpResponseMessage Post(
            MovieLookupModel movieLookupModel)
        {
            if (ModelState.IsValid)
            {
                _movieService.EmailTotalReviews(
                    movieLookupModel.MovieTitleAndReleaseYear,
                    movieLookupModel.EmailAddress);

                return new HttpResponseMessage(HttpStatusCode.OK);
            }

            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}

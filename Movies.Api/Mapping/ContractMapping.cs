using Microsoft.AspNetCore.Http.Features;
using Movies.Application.Models;
using Movies.Contracts.Requests;
using Movies.Contracts.Responses;

namespace Movies.Api.Mapping
{
    public static class ContractMapping
    {
        public static Movie MapToMovie (this CreateMovieRequest request)
        {
            return new Movie
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Genres = request.Genres.ToList(),
                YearOfRelease = request.YearOfRelease,

            };
        }

        public static MovieResponse MapToResponse (this Movie movie)
        {
            return new MovieResponse
            {
                Id = movie.Id,
                Title = movie.Title,
                Genres = movie.Genres.ToList(),
                YearOfRelease = movie.YearOfRelease,

            };
        }


        public static MoviesResponse MapToResponse(this IEnumerable<Movie> movies)
        {
            return new MoviesResponse { Items = movies.Select(MapToResponse) };
           
        }
    }
}

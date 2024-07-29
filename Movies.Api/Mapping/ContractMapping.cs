﻿using Microsoft.AspNetCore.Http.Features;
using Movies.Application.Models;
using Movies.Contracts.Requests;
using Movies.Contracts.Responses;
using static Movies.Api.ApiEndpoint;

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
                Slug = movie.Slug,
                Genres = movie.Genres.ToList(),
                YearOfRelease = movie.YearOfRelease,

            };
        }


        public static MoviesResponse MapToResponse(this IEnumerable<Movie> movies)
        {
            return new MoviesResponse { Items = movies.Select(MapToResponse) };
           
        }

        public static Movie MapToMovie(this UpdateMovieRequest request,Guid id)
        {
            return new Movie
            {
                Id=id,
                Title = request.Title,
                Genres = request.Genres.ToList(),
                YearOfRelease = request.YearOfRelease,

            };
        }
    }
}

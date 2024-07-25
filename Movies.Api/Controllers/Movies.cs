﻿using Microsoft.AspNetCore.Mvc;
using Movies.Api.Mapping;
using Movies.Application.Models;
using Movies.Application.Repositories;
using Movies.Contracts.Requests;

namespace Movies.Api.Controllers
{
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        { 
            _movieRepository = movieRepository;
        }
        [HttpPost(ApiEndpoint.Movies.Create)]
        public async Task<IActionResult> Create([FromBody] CreateMovieRequest request)
        {
            var movie = request.MapToMovie();
             await _movieRepository.CreateAsync(movie);
            return Created($"{ApiEndpoint.Movies.Create}/{movie.Id}", movie);
        }

        [HttpPost(ApiEndpoint.Movies.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if(movie is null)
            {
                return NotFound();
            }
            return Ok(movie.MapToResponse());
        }

        [HttpPost(ApiEndpoint.Movies.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var movies = await _movieRepository.GetAllAsync();
           
            return Ok(movies.MapToResponse());
        }
    }
}

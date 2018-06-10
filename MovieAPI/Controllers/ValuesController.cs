
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieAPI.Models;
using System.Web.Http.Results;

namespace MovieAPI.Controllers
{
    public class ValuesController : ApiController
    {

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        public List<Movies> GetMovies()
        {
            MoviesEntities1 db = new MoviesEntities1();
            List<Movies> movies = db.Movies.ToList();

            return movies;
        }

        public List<Movies> GetMovieByGenre(string id)
        {
            MoviesEntities1 db = new MoviesEntities1();
            List<Movies> movie = (from m in db.Movies
                                   where m.Genre.Contains(id)
                                   select m).ToList();
            return movie;
        }

        public Movies GetRandomMovie()
        {
            MoviesEntities1 db = new MoviesEntities1();
            Random movie = new Random();
            int RandMovie = movie.Next(0, db.Movies.Count());

            Movies moovie = (from m in db.Movies
                            where m.ID == RandMovie
                            select m).Single();

            return moovie;
        }

        public Movies GetRandomMovieByGenre(string id)
        {
            Random movy = new Random();
            MoviesEntities1 db = new MoviesEntities1();
            List<Movies> movie = (from m in db.Movies
                                  where m.Genre == id
                                  select m).ToList();

            int RandMovie = movy.Next(0, movie.Count());
            return movie[RandMovie];
        }

        public List<Movies> GetRandomMovieList(int num)
        {
            Random rnd = new Random();
            MoviesEntities1 db = new MoviesEntities1();
            List<Movies> randomMovieList = new List<Movies>();
            List<Movies> fullMovieList = db.Movies.ToList();

            for (int i = 0; i < num; i++)
            {
                int randomNumber = rnd.Next(0, fullMovieList.Count());
                randomMovieList.Add(fullMovieList[randomNumber]);
            }

            return randomMovieList;
        }
    
        public List<Movies> GetMovieInfo(string id)
        {
            MoviesEntities1 db = new MoviesEntities1();
            List<Movies> movie = (from m in db.Movies
                                  where m.Title == id
                                  select m).ToList();

            return movie;
        }

        public List<Movies> GetMovieByKey(string keyword)
        {
            MoviesEntities1 db = new MoviesEntities1();
            List<Movies> movie = (from m in db.Movies
                                  where m.Title.Contains(keyword)
                                  select m).ToList();

            return movie;
        }
    }
}

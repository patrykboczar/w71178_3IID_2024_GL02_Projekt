using System;
using System.Collections.Generic;
using Kino.Models;

namespace Kino.Services
{
    public class MovieService
    {
        private List<Movie> movies = new List<Movie>
        {
            new Movie { Title = "Zimna wojna", Genre = "Dramat", ShowTimes = new List<string> { "10:00", "14:00", "18:00" } },
            new Movie { Title = "Bogowie", Genre = "Biograficzny", ShowTimes = new List<string> { "12:00", "16:00", "20:00" } },
            new Movie { Title = "Incepcja", Genre = "Sci-Fi", ShowTimes = new List<string> { "11:00", "15:00", "19:00" } },
            new Movie { Title = "Zielona mila", Genre = "Dramat", ShowTimes = new List<string> { "13:00", "17:00", "21:00" } },
            new Movie { Title = "Forrest Gump", Genre = "Dramat", ShowTimes = new List<string> { "09:00", "13:00", "17:00" } },
            new Movie { Title = "Władca Pierścieni: Drużyna Pierścienia", Genre = "Fantasy", ShowTimes = new List<string> { "10:30", "14:30", "18:30" } },
            new Movie { Title = "Matrix", Genre = "Sci-Fi", ShowTimes = new List<string> { "12:30", "16:30", "20:30" } }
        };
        
        public void ShowMovies()
        {
            for (int i = 0; i < movies.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {movies[i].Title} ({movies[i].Genre})");
            }
        }

        public Movie GetMovie(int index)
        {
            return movies[index];
        }

        public int GetMoviesCount()
        {
            return movies.Count;
        }
    }
}
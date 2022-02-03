using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext (DbContextOptions<MovieContext> options) : base(options)
        {
            //We're just gonna leave this blank for now
        }
        public DbSet<AddMovieResponse> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<AddMovieResponse>().HasData(
                new AddMovieResponse
                {
                    MovieId = 1,
                    Category = "Science Fiction",
                    Title = "Interstellar",
                    Year = "2014",
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new AddMovieResponse
                {
                    MovieId = 2,
                    Category = "Family",
                    Title = "How to Train Your Dragon",
                    Year = "2010",
                    Director = "Chris Sanders, Dean DeBlois",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new AddMovieResponse
                {
                    MovieId = 3,
                    Category = "Action",
                    Title = "Spider-Man: No Way Home",
                    Year = "2021",
                    Director = "Jon Watts",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }

            );
        }

    }
}

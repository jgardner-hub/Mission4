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
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Science Fiction"},
                new Category { CategoryId = 2, CategoryName = "Family" },
                new Category { CategoryId = 3, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 4, CategoryName = "Comedy" },
                new Category { CategoryId = 5, CategoryName = "Drama" },
                new Category { CategoryId = 6, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 7, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 8, CategoryName = "Television" },
                new Category { CategoryId = 9, CategoryName = "VHS" }
                );


            mb.Entity<AddMovieResponse>().HasData(
                new AddMovieResponse
                {
                    MovieId = 1,
                    CategoryId = 1,
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
                    CategoryId = 2,
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
                    CategoryId = 3,
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

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MoviesApp.Entities
{
    public class Genre
    {
        public string GenreId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
    
    /// <summary>
    /// This is a class of objects representing the primary domain 
    /// object for this simple App - i.e. they represent basic movies.
    /// Objects of this class will be mapped to rows in a DB table 
    /// by EF Core.
    /// 
    /// Note: it's typically best to make entity props be nullable.
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// This property stoes the primary key (PK) for movie entities
        /// in the DB. Because it is of type int, MS SQL server will auto-increment
        /// (and therefore autogenerate) the PK for us. Also, this is EF Core's
        /// default naming convetion for PK's.
        /// </summary>
        public int MovieId { get; set; }

        // the movie's name:
        [Required(ErrorMessage = "Please a name for the movie.")]
        public string? Name { get; set; }

        // the Year it was made:
        [Required(ErrorMessage = "Please a year for the movie.")]
        [Range(1830, int.MaxValue, ErrorMessage = "The year of the movie must be later than 1830.")]
        public int? Year { get; set; }

        // its rating between 1 and 5:
        [Required(ErrorMessage = "Please a rating for the movie.")]
        [Range(1, 5, ErrorMessage = "Movie ratings must be between 1 and 5.")]
        public int? Rating { get; set; }
        
        // movie genre
        [ValidateNever]
        public Genre Genre { get; set; } = null!;
        
        [Required(ErrorMessage = "Please a genre for the movie.")]
        public string GenreId { get; set; } = string.Empty;
        
        public string Slug => Name?.Replace(' ', '-').ToLower() + '-' +  Year?.ToString();
        
    }
}

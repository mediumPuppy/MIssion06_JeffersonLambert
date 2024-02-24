﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace JoelsMoviesJeffersonLambert.Models
{
    public class Movie
    {
        //all getters and setters for the various items

        public int MovieId { get; set; }
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }

        public string Title { get; set; }

       // [Range(1888,2024)]
        public int Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }

        public bool Edited { get; set; } = false;
        public string? LentTo { get; set; }
 
        public int CopiedToPlex { get; set; }
        public string? Notes { get; set; }
    }

}

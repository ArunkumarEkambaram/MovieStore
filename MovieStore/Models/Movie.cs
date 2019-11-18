using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Models
{
    public class Movie
    {        
        public int Id { get; set; }
        public string MovieName { get; set; }        
        public string DirectorName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}

using MovieStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.ViewModel
{
    public class MovieViewModel
    {        
        public int Id { get; set; }

        [Required, StringLength(100), Display(Name ="Movie Name")]        
        public string MovieName { get; set; }

        [Required, StringLength(100), Display(Name ="Director Name")]
        public string DirectorName { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public Movie Movie{ get; set; }
    }
}

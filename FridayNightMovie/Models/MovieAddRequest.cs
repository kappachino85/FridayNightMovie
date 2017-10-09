using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FridayNightMovie.Models
{
    public class MovieAddRequest
    {
        [Required]
        public string Title { get; set; }

        public string Genre { get; set; }
    }
}
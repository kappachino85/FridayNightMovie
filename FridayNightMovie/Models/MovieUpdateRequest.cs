using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FridayNightMovie.Models
{
    public class MovieUpdateRequest : MovieAddRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
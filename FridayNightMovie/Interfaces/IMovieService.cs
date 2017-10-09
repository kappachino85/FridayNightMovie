using FridayNightMovie.Domain;
using FridayNightMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridayNightMovie.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<Movies> ReadAll();
        IEnumerable<Movies> ReadRandom();
        Movies ReadById(int Id);
        int Insert(MovieAddRequest model);
        void Delete(int id);
        void Update(MovieUpdateRequest model);
    }
}

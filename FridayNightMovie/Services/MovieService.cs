using DbConnector.Adapter;
using DbConnector.Tools;
using FridayNightMovie.Domain;
using FridayNightMovie.Interfaces;
using FridayNightMovie.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FridayNightMovie.Services
{
    public class MovieService : IMovieService
    {
        IBaseService _baseService;

        public MovieService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public IEnumerable<Movies> ReadAll()
        {
            return _baseService.SqlAdapter.LoadObject<Movies>(new DbCommandDef
            {
                DbCommandText = "dbo.MovieList_SelectAll",
                DbCommandType = System.Data.CommandType.StoredProcedure
            });
        }

        public IEnumerable<Movies> ReadRandom()
        {
            return _baseService.SqlAdapter.LoadObject<Movies>(new DbCommandDef
            {
                DbCommandText = "dbo.MovieList_SelectRandom",
                DbCommandType = System.Data.CommandType.StoredProcedure
            });
        }

        public Movies ReadById(int id)
        {
            return _baseService.SqlAdapter.LoadObject<Movies>(new DbCommandDef
            {
                DbCommandText = "dbo.MovieList_SelectById",
                DbCommandType = System.Data.CommandType.StoredProcedure,
                DbParameters = new SqlParameter[]
                {
                    new SqlParameter("@Id", id)
                }
            }).FirstOrDefault();
        }

        public int Insert(MovieAddRequest model)
        {
            SqlParameter id = SqlDbParameter.Instance.BuildParam("@Id", 0, System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Output);
            _baseService.SqlAdapter.ExecuteQuery(new DbCommandDef
            {
                DbCommandText = "dbo.MovieList_Insert",
                DbCommandType = System.Data.CommandType.StoredProcedure,
                DbParameters = new SqlParameter[]
                {
                    new SqlParameter("@Title", model.Title),
                    new SqlParameter("@Genre", model.Genre),
                    id
                }
            });
            return id.Value.ToInt32();
        }

        public void Update(MovieUpdateRequest model)
        {
            _baseService.SqlAdapter.ExecuteQuery(new DbCommandDef
            {
                DbCommandText = "dbo.MovieList_UpdateById",
                DbCommandType = System.Data.CommandType.StoredProcedure,
                DbParameters = new SqlParameter[]
                {
                    new SqlParameter("@Id", model.Id),
                    new SqlParameter("@Title", model.Title),
                    new SqlParameter("@Genre", model.Genre)
                }
            });
        }

        public void Delete(int id)
        {
            _baseService.SqlAdapter.ExecuteQuery(new DbCommandDef
            {
                DbCommandText = "dbo.MovieList_DeleteById",
                DbCommandType = System.Data.CommandType.StoredProcedure,
                DbParameters = new SqlParameter[]
                {
                    new SqlParameter("@Id", id)
                }
            });
        }
    }
}
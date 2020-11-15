using DesafioGamaAvanade.Business.Interfaces;
using DesafioGamaAvanade.Business.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGamaAvanade.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task<User> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByLoginAsync(string login)
        {
            try
            {
                using (var con = new SqlConnection(_configuration["ConnectionString"]))
                {
                    var sqlCmd = @$"SELECT U.Id,
                                           U.Login,
                                           U.Password,
                                           P.Id as idProfile,
                                           P.Description 
                                        FROM USERS U
                                    JOIN PROFILE P ON U.ProfileId = P.Id
                                    WHERE U.Login='{login}'";

                    using (SqlCommand cmd = new SqlCommand(sqlCmd, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();

                        var reader = await cmd
                                            .ExecuteReaderAsync()
                                            .ConfigureAwait(false);

                        while (reader.Read())
                        {
                            var user = new User(Guid.Parse(reader["id"].ToString()),
                                                new Profile(Guid.Parse(reader["idProfile"].ToString()),
                                                            reader["Description"].ToString()));

                            user.InformationLoginUser(reader["Login"].ToString(), reader["Password"].ToString());
                            return user;
                        }

                        return default;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<String> InsertAsync(User user)
        {
            try
            {
                using (var con = new SqlConnection(_configuration["ConnectionString"]))
                {
                    var sqlCmd = @" declare @id uniqueidentifier
                                    set @id  = NEWID()
                                    INSERT INTO 
                                    USERS (Id, ProfileId, 
                                            Login, 
                                            Password, 
                                            Created) 
                               VALUES (@id, @profile, 
                                        @login, 
                                        @password,
                                        @created); select @id;";

                    using (SqlCommand cmd = new SqlCommand(sqlCmd, con))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("profile", user.Profile.Id.ToString());
                        cmd.Parameters.AddWithValue("login", user.Login);
                        cmd.Parameters.AddWithValue("password", user.Password);
                        cmd.Parameters.AddWithValue("created", user.Created);

                        con.Open();
                        var id = await cmd
                                       .ExecuteScalarAsync()
                                       .ConfigureAwait(false);

                        

                        return id.ToString();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}

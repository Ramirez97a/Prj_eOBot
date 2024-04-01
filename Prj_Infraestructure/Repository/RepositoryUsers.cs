using Prj_Infraestructure.Models;
using Prj_Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prj_Infraestructure.Repositorys
{
    public class RepositoryUsers : IRepositoryUsers
    {
        public async Task<IEnumerable<RI_Users>> getAll()
        {
            IEnumerable<RI_Users> list = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                   

                }

                return list;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "Error en la base de datos: \n" + dbEx.Message;
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "Error en el servidor: \n" + ex.Message;
                throw;
            }
        }

        public async Task<RI_Users> Login(string userName, string userPassword)
        {
            try
            {
                RI_Users user = null;

                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;

                    using (var connection = new SqlConnection(ctx.Database.Connection.ConnectionString))
                    {
                        await connection.OpenAsync();

                        using (var command = new SqlCommand("Sp_GetUserAutenticacion", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@userName", userName);
                            command.Parameters.AddWithValue("@userPassword", userPassword);

                            using (var reader = await command.ExecuteReaderAsync())
                            {
                                if (await reader.ReadAsync())
                                {
                                    user = new RI_Users
                                    {
                                        ID = Convert.ToInt32(reader["ID"]),
                                        Name = reader["Name"].ToString(),
                                        Surname = reader["Surname"].ToString(),
                                        Email = reader["Email"].ToString(),
                                        UserName = reader["UserName"].ToString(),
                                        Password = reader["Password"].ToString(),
                                        Role = reader["Role"] != DBNull.Value ? Convert.ToInt32(reader["Role"]) : (int?)null,
                                        Status = reader["Status"] != DBNull.Value ? Convert.ToInt32(reader["Status"]) : (int?)null
                                    };
                                }
                            }
                        }
                    }
                }

                return user;
            }
            catch (SqlException sqlEx) when (sqlEx.Number == 4060) // Controlar error de conexión
            {
                throw new Exception("Error de conexión a la base de datos. Por favor, inténtalo de nuevo más tarde.");
            }
            catch (SqlException sqlEx) // Controlar otros errores de SQL
            {
                throw new Exception($"Error de SQL: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en el servidor: {ex.Message}");
            }
        }

    }
}
    
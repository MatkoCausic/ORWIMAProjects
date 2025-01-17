using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskJunction.Models;
using TaskJunction.Repository.Common;

namespace TaskJunction.Repository
{
    public class WorkerRepository : IWorkerRepository
    {
        private const string connectionString = "Host=localhost:5432;Username=postgres;Password=postgres;Database=Task_Junction";

        //C
        public async Task<bool> PostWorkerAsync(Worker worker)
        {
            try
            {
                using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                string commandText = $"INSERT INTO \"Worker\" VALUES (@Id, @FirstName, @LastName, @Email, @IsActive, @Address, @DepartmentId, @DateCreated, @DateUpdated);";
                using var command = new NpgsqlCommand(commandText, connection);

                command.Parameters.AddWithValue("@Id", NpgsqlTypes.NpgsqlDbType.Uuid, worker.Id);
                command.Parameters.AddWithValue("@FirstName", worker.FirstName);
                command.Parameters.AddWithValue("@LastName", worker.LastName);
                command.Parameters.AddWithValue("@Email", worker.Email);
                command.Parameters.AddWithValue("@IsActive", true);
                command.Parameters.AddWithValue("@Address", worker.Address ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@DepartmentId", NpgsqlTypes.NpgsqlDbType.Uuid, 
                    worker.DepartmentId == null ? (object)DBNull.Value : worker.DepartmentId);
                command.Parameters.AddWithValue("@DateCreated", worker.DateCreated);
                command.Parameters.AddWithValue("@DateUpdated", worker.DateUpdated);

                connection.Open();

                var numberOfCommits = await command.ExecuteNonQueryAsync();

                connection.Close();
                if (numberOfCommits == 0)
                    return false;
                return true;
            }
            catch
            {
                Console.WriteLine("(-) WorkerRepository error");
                throw new Exception("Error with creating a new department.");
            }
        }
        //R
        public async Task<List<Worker>> GetAllWorkersAsync()
        {
            try
            {
                List<Worker> workers = new List<Worker>();

                using var connection = new NpgsqlConnection(connectionString);
                string commandText = "SELECT \"Id\",\"FirstName\",\"LastName\",\"Email\",\"Address\",\"DepartmentId\",\"DateCreated\" FROM \"Worker\";";
                using var command = new NpgsqlCommand(commandText, connection);

                connection.Open();

                using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while(await reader.ReadAsync())
                    {
                        Worker worker = new Worker
                            (
                                Guid.Parse(reader["Id"].ToString()),
                                reader["FirstName"].ToString(),
                                reader["LastName"].ToString(),
                                reader["Email"].ToString(),
                                reader["Address"].ToString(),
                                Guid.TryParse(reader["DepartmentId"].ToString(),out var result) ? result : null,
                                DateTime.Parse(reader["DateCreated"].ToString())
                            );
                        workers.Add(worker);
                    }
                }
                else
                    return null;
                return workers;
            }
            catch(Exception ex)
            {
                Console.WriteLine("(-) WorkerRepository error");
                throw new Exception(ex.Message);
            }
        }

        public async Task<NpgsqlTransaction> BeginTransactionAsync()
        {
            var connection = new NpgsqlConnection(connectionString);
            await connection.OpenAsync();
            return await connection.BeginTransactionAsync();
        }
    }
}

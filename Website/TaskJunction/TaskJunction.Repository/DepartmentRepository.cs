using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using TaskJunction.Models;
using TaskJunction.Repository.Common;

namespace TaskJunction.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private const string connectionString = "Host=localhost:5432;Username=postgres;Password=postgres;Database=Task_Junction";

        //C
        public async Task<bool> PostDepartmentAsync(Department department)
        {
            try
            {
                using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                string commandText = $"INSERT INTO \"Department\" VALUES(@Id, @Name);";
                using var command = new NpgsqlCommand(commandText, connection);

                command.Parameters.AddWithValue("@Id", NpgsqlTypes.NpgsqlDbType.Uuid, department.Id);
                command.Parameters.AddWithValue("@Name", department.Name);

                connection.Open();

                var numberOfCommits = await command.ExecuteNonQueryAsync();

                connection.Close();
                if (numberOfCommits == 0)
                    return false;
                return true;
            }
            catch
            {
                Console.WriteLine("(-) DepartmentRepository error");
                throw new Exception("Error with creating a new department.");
            }
        }
        //R
        public async Task<Department> GetExistingDepartmentAsync(Department department)
        {
            try
            {
                using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                string commandText = $"SELECT * FROM \"Department\" WHERE \"Name\" = @Name";
                using var command = new NpgsqlCommand(commandText, connection);

                command.Parameters.AddWithValue("@Name", department.Name);

                connection.Open();
                using var reader = await command.ExecuteReaderAsync();
                if(await reader.ReadAsync())
                {
                    Department existingDepartment = new Department
                        (
                            reader.GetGuid(reader.GetOrdinal("Id")),
                            reader["Name"].ToString()
                        );
                    return existingDepartment;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("(-) DepartmentRepository error");
                throw new Exception(ex.Message);
            }
        }
        public async Task<Department> GetExistingDepartmentAsync(Guid departmentId)
        {
            try
            {
                using NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                string commandText = $"SELECT * FROM \"Department\" WHERE \"IsActive\" = true AND \"Id\" = @Id";
                using var command = new NpgsqlCommand(commandText, connection);

                command.Parameters.AddWithValue("@Id", departmentId);

                connection.Open();
                using var reader = await command.ExecuteReaderAsync();
                if(await reader.ReadAsync())
                {
                    Department existingDepartment = new Department
                        (
                            reader.GetGuid(reader.GetOrdinal("Id")),
                            reader["Name"].ToString()
                        );
                    return existingDepartment;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("(-) DepartmentRepository error");
                throw new Exception(ex.Message);
            }
        }
        public async  Task<List<Department>> GetAllDepartmentsAsync()
        {
            try
            {
                List<Department> departments = new List<Department>();

                using var connection = new NpgsqlConnection(connectionString);
                string commandText = "SELECT \"Id\",\"Name\" FROM \"Department\";";
                using var command = new NpgsqlCommand(commandText, connection);

                connection.Open();

                using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        Department department = new Department
                            (
                                Guid.Parse(reader["Id"].ToString()),
                                reader["Name"].ToString()
                            );
                        departments.Add(department);
                    }
                }
                else
                    return null;
                return departments;
            }
            catch(Exception ex)
            {
                Console.WriteLine("(-) DepartmentRepository error");
                throw new Exception(ex.Message);
            }
        }
        //U

        //D

        public async Task<NpgsqlTransaction> BeginTransactionAsync()
        {
            var connection = new NpgsqlConnection(connectionString);
            await connection.OpenAsync();
            return await connection.BeginTransactionAsync();
        }
    }
}

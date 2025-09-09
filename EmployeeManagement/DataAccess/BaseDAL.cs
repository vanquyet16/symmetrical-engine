using MySql.Data.MySqlClient;
using EmployeeManagement.Config;
using System.Data;

namespace EmployeeManagement.DataAccess
{
    public abstract class BaseDAL
    {
        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(DatabaseConfig.ConnectionString);
        }

        protected async Task<MySqlConnection> GetConnectionAsync()
        {
            var connection = new MySqlConnection(DatabaseConfig.ConnectionString);
            await connection.OpenAsync();
            return connection;
        }

        protected DataTable ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            using var connection = GetConnection();
            using var command = new MySqlCommand(query, connection);
            
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            using var adapter = new MySqlDataAdapter(command);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        protected async Task<DataTable> ExecuteQueryAsync(string query, params MySqlParameter[] parameters)
        {
            using var connection = await GetConnectionAsync();
            using var command = new MySqlCommand(query, connection);
            
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            using var adapter = new MySqlDataAdapter(command);
            var dataTable = new DataTable();
            await Task.Run(() => adapter.Fill(dataTable));
            return dataTable;
        }

        protected int ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            using var connection = GetConnection();
            connection.Open();
            using var command = new MySqlCommand(query, connection);
            
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            return command.ExecuteNonQuery();
        }

        protected async Task<int> ExecuteNonQueryAsync(string query, params MySqlParameter[] parameters)
        {
            using var connection = await GetConnectionAsync();
            using var command = new MySqlCommand(query, connection);
            
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            return await command.ExecuteNonQueryAsync();
        }

        protected object ExecuteScalar(string query, params MySqlParameter[] parameters)
        {
            using var connection = GetConnection();
            connection.Open();
            using var command = new MySqlCommand(query, connection);
            
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            return command.ExecuteScalar();
        }

        protected async Task<object> ExecuteScalarAsync(string query, params MySqlParameter[] parameters)
        {
            using var connection = await GetConnectionAsync();
            using var command = new MySqlCommand(query, connection);
            
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            return await command.ExecuteScalarAsync();
        }
    }
}

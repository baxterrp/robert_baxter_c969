﻿using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace robert_baxter_c969.Data
{
    public class DataReader : IDataReader
    {
        private string _connectionString;
        private TableConfiguration _tableConfiguration;

        public DataReader(TableConfiguration tableConfiguration)
        {
            _connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            _tableConfiguration = tableConfiguration;
        }

        public async Task Delete(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var deleteStatement = GetDeleteStatement();
                var command = connection.CreateCommand();

                command.CommandText = deleteStatement;
                command.Parameters.AddWithValue("@Id", id);

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<IEnumerable<TDataEntity>> Get<TDataEntity>(IDictionary<string, string> searchCriteria = null)
            where TDataEntity : DataEntity, new()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var selectStatement = GetSelectStatement(searchCriteria.Select(criterion => criterion.Key));
                var query = connection.CreateCommand();
                query.CommandText = selectStatement;

                foreach (var criterion in searchCriteria ?? new Dictionary<string, string>())
                {
                    query.Parameters.AddWithValue($"@{criterion.Key}", criterion.Value);
                }

                var result = new List<TDataEntity>();

                using (var reader = await query.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        result.Add(MapEntity<TDataEntity>(reader));
                    }

                    return result;
                }
            }
        }

        public async Task<TDataEntity> GetById<TDataEntity>(int id) where TDataEntity : DataEntity, new()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var selectStatement = GetSelectStatement(new List<string> { "Id" });
                var query = connection.CreateCommand();
                query.CommandText = selectStatement;

                using (var reader = await query.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        return MapEntity<TDataEntity>(reader);
                    }
                }
            }

            return default;
        }

        public async Task<TDataEntity> Insert<TDataEntity>(TDataEntity entity) where TDataEntity : DataEntity, new()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var entityProps = entity.GetType().GetProperties().Where(prop => prop.Name != "Id");
                var insertStatement = GetInsertStatement(entity.GetType().GetProperties().Where(prop => prop.Name != "Id"));
                var command = connection.CreateCommand();
                command.CommandText = insertStatement;

                foreach(var prop in entityProps)
                {
                    command.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(entity));
                }

                var newId = await command.ExecuteScalarAsync() as int?;

                entity.Id = newId.Value;

                return entity;
            }
        }

        private string GetInsertStatement(IEnumerable<PropertyInfo> props) 
        {
            var builder = new StringBuilder($"INSERT INTO {_tableConfiguration.TableName}");
            var columns = $" ({string.Join(",", props.Select(p => p.Name))})";
            var values = $" ({string.Join(",", props.Select(p => $"@{p.Name}"))})";

            builder.Append(columns);
            builder.Append(" VALUES ");
            builder.Append(values);
            builder.Append(" SELECT LAST_INSERT_ID();");

            return builder.ToString();
        }

        public async Task<TDataEntity> Update<TDataEntity>(TDataEntity entity) where TDataEntity : DataEntity, new()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var entityProps = entity.GetType().GetProperties().Where(prop => prop.Name != "Id");
                var updateStatement = GetUpdateStatement(entityProps);
                var updateCommand = connection.CreateCommand();
                updateCommand.CommandText = updateStatement;

                foreach(var prop in entityProps)
                {
                    updateCommand.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(entity));
                }

                await updateCommand.ExecuteNonQueryAsync();

                return entity;
            }
        }

        private string GetUpdateStatement(IEnumerable<PropertyInfo> entityProps)
        {
            var builder = new StringBuilder($"UPDATE {_tableConfiguration.TableName} SET ");
            builder.Append(string.Join(",", entityProps.Select(prop => $"{prop.Name}=@{prop.Name}")));
            builder.Append(" WHERE Id = @Id");

            return builder.ToString();
        }

        private string GetSelectStatement(IEnumerable<string> searchCriteria)
        {
            var builder = new StringBuilder($"SELECT * FROM {_tableConfiguration.TableName}");

            if (searchCriteria?.Any() ?? false)
            {
                builder.Append(" WHERE ");
                builder.Append(
                    string.Join(" AND ", searchCriteria.Select(criterion => $"{criterion}=@{criterion}")));
            }

            return builder.ToString();
        }

        private string GetDeleteStatement()
        {
            return $"DELETE FROM {_tableConfiguration.TableName} WHERE ID = @Id";
        }

        private static TDataEntity MapEntity<TDataEntity>(DbDataReader reader) where TDataEntity : DataEntity, new()
        {
            var entity = new TDataEntity();

            foreach (var prop in entity.GetType().GetProperties())
            {
                var name = prop.Name;
                var value = reader[name];

                prop.SetValue(entity, value);
            }

            return entity;
        }
    }
}

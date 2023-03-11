using MySql.Data.MySqlClient;
using robert_baxter_c969.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace robert_baxter_c969.Data
{
    public class DataRepository : IDataRepository
    {
        private DbConfiguration _connectionConfig;

        public DataRepository(DbConfiguration connectionConfig)
        {
            _connectionConfig = connectionConfig;
        }

        public async Task Delete<TDataEntity>(TDataEntity entity) where TDataEntity : DataEntity, new()
        {
            using (var connection = new MySqlConnection(_connectionConfig.ConnectionString))
            {

                var tableName = typeof(TDataEntity).Name.ToLower();
                var deleteStatement = GetDeleteStatement(tableName);
                var command = connection.CreateCommand();

                command.CommandText = deleteStatement;
                command.Parameters.AddWithValue("@Id", entity.Id);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<IEnumerable<TDataEntity>> Get<TDataEntity>(IDictionary<string, string> searchCriteria = null)
            where TDataEntity : DataEntity, new()
        {
            using (var connection = new MySqlConnection(_connectionConfig.ConnectionString))
            {
                // use .Select here to fetch a new IEnumerable object of just the Key value provided in searchCriteria
                var selectStatement = GetSelectStatement(searchCriteria?.Select(criterion => criterion.Key) ?? new List<string>(), typeof(TDataEntity).Name.ToLower());
                var query = connection.CreateCommand();
                query.CommandText = selectStatement;

                foreach (var criterion in searchCriteria ?? new Dictionary<string, string>())
                {
                    query.Parameters.AddWithValue($"@{criterion.Key}", criterion.Value);
                }

                var result = new List<TDataEntity>();

                await connection.OpenAsync();
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
            using (var connection = new MySqlConnection(_connectionConfig.ConnectionString))
            {
                var selectStatement = GetSelectStatement(new List<string> { "Id" }, typeof(TDataEntity).Name.ToLower());
                var query = connection.CreateCommand();
                query.CommandText = selectStatement;
                query.Parameters.AddWithValue("@Id", id);

                await connection.OpenAsync();
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
            using (var connection = new MySqlConnection(_connectionConfig.ConnectionString))
            {
                // use .Where here to fetch new IEnumerable object not containing the DataEntity.Id property
                var entityProps = entity.GetType().GetProperties().Where(prop => prop.Name != "Id");
                var insertStatement = GetInsertStatement(entityProps, entity.GetType().Name);
                var command = connection.CreateCommand();
                command.CommandText = insertStatement;

                foreach (var prop in entityProps)
                {
                    command.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(entity));
                }

                await connection.OpenAsync();
                var newId = await command.ExecuteScalarAsync();

                entity.Id = int.Parse(newId.ToString());

                return entity;
            }
        }

        public async Task<TDataEntity> Update<TDataEntity>(TDataEntity entity) where TDataEntity : DataEntity, new()
        {
            using (var connection = new MySqlConnection(_connectionConfig.ConnectionString))
            {
                // use .Where here to fetch new IEnumerable object not containing the DataEntity.Id property
                var entityProps = entity.GetType().GetProperties().Where(prop => prop.Name != "Id");
                var updateStatement = GetUpdateStatement(entityProps, entity.GetType().Name);
                var updateCommand = connection.CreateCommand();
                updateCommand.CommandText = updateStatement;

                foreach (var prop in entityProps)
                {
                    updateCommand.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(entity));
                }

                updateCommand.Parameters.AddWithValue("@Id", entity.Id);

                await connection.OpenAsync();
                await updateCommand.ExecuteNonQueryAsync();

                return entity;
            }
        }

        public async Task<IEnumerable<TAggregateDataEntity>> ExecuteCustomQuery<TAggregateDataEntity>(
            string sql,
            IDictionary<string, object> parameters)
            where TAggregateDataEntity : new()
        {
            using (var connection = new MySqlConnection(_connectionConfig.ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = sql;

                foreach (var param in parameters)
                {
                    command.Parameters.AddWithValue($"@{param.Key}", param.Value);
                }

                var result = new List<TAggregateDataEntity>();

                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    result.Add(MapEntity<TAggregateDataEntity>(reader));
                }

                return result;
            }
        }

        private static string GetInsertStatement(IEnumerable<PropertyInfo> props, string tableName)
        {
            var builder = new StringBuilder($"INSERT INTO {tableName}");
            var columns = $" ({string.Join(",", props.Select(p => p.Name))})";
            var values = $" ({string.Join(",", props.Select(p => $"@{p.Name}"))});";

            builder.Append(columns);
            builder.Append(" VALUES ");
            builder.Append(values);
            builder.Append(" SELECT LAST_INSERT_ID();");

            return builder.ToString();
        }

        private static string GetUpdateStatement(IEnumerable<PropertyInfo> entityProps, string tableName)
        {
            var builder = new StringBuilder($"UPDATE {tableName} SET ");
            builder.Append(string.Join(",", entityProps.Select(prop => $"{prop.Name}=@{prop.Name}")));
            builder.Append(" WHERE Id = @Id");

            return builder.ToString();
        }

        private static string GetSelectStatement(IEnumerable<string> searchCriteria, string tableName)
        {
            var builder = new StringBuilder($"SELECT * FROM {tableName}");

            if (searchCriteria?.Any() ?? false)
            {
                builder.Append(" WHERE ");
                builder.Append(
                    string.Join(" AND ", searchCriteria.Select(criterion => $"{criterion}=@{criterion}")));
            }

            return builder.ToString();
        }

        private static string GetDeleteStatement(string tableName)
        {
            return $"DELETE FROM {tableName} WHERE ID = @Id";
        }

        private static TDataEntity MapEntity<TDataEntity>(DbDataReader reader) where TDataEntity : new()
        {
            var entity = new TDataEntity();

            foreach (var prop in entity.GetType().GetProperties())
            {
                var name = prop.Name;
                var value = reader[name];

                switch (value)
                {
                    case int intValue:
                        prop.SetValue(entity, intValue);
                        break;
                    case string stringValue:
                        prop.SetValue(entity, stringValue);
                        break;
                    case DateTime dateTimeValue:
                        prop.SetValue(entity, dateTimeValue);
                        break;

                    // was getting a format exception converting the TINYINT value to boolean so i'm just comparing it to 0
                    case sbyte booleanValue:
                        prop.SetValue(entity, booleanValue > 0);
                        break;
                }
            }

            return entity;
        }
    }
}

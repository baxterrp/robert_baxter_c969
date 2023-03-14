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
        private readonly DbConfiguration _connectionConfig;

        public DataRepository(DbConfiguration connectionConfig)
        {
            _connectionConfig = connectionConfig;
        }

        public async Task Delete<TDataEntity>(TDataEntity entity) where TDataEntity : DataEntity, new()
        {
            using (var connection = new MySqlConnection(_connectionConfig.ConnectionString))
            {
                var tableName = typeof(TDataEntity).Name.ToLower();
                var deleteStatement = GetDeleteStatement<TDataEntity>(tableName);
                var command = connection.CreateCommand();

                command.CommandText = deleteStatement;
                command.Parameters.AddWithValue($"@Id", entity.Id);

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
                var selectStatement = GetSelectStatement<TDataEntity>(searchCriteria?.Select(criterion => criterion.Key) ?? new List<string>(), typeof(TDataEntity).Name.ToLower());
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
                var selectStatement = GetSelectStatement<TDataEntity>(new List<string> { "Id" }, typeof(TDataEntity).Name.ToLower());
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
                // update audit data
                SetDataEntityValues(entity);

                // use .Where here to fetch new IEnumerable object not containing the DataEntity.Id property
                var entityProps = entity.GetType().GetProperties().Where(prop => prop.Name != "Id" && prop.GetCustomAttribute<ColumnNameAttribute>() != null);
                var insertStatement = GetInsertStatement<TDataEntity>(entityProps, entity.GetType().Name);
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
                // update audit data
                SetDataEntityValues(entity);

                // use .Where here to fetch new IEnumerable object not containing the DataEntity.Id property
                var entityProps = entity.GetType().GetProperties().Where(prop => prop.Name != "Id" && prop.GetCustomAttribute<ColumnNameAttribute>() != null);
                var updateStatement = GetUpdateStatement<TDataEntity>(entityProps, entity.GetType().Name);
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

                foreach (var param in parameters ?? new Dictionary<string, object>())
                {
                    command.Parameters.AddWithValue($"@{param.Key}", param.Value);
                }

                var result = new List<TAggregateDataEntity>();

                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        result.Add(MapEntity<TAggregateDataEntity>(reader));
                    }
                }

                return result;
            }
        }

        public async Task<int> ExecuteScalar(string sql, IDictionary<string, object> parameters)
        {
            using (var connection = new MySqlConnection(_connectionConfig.ConnectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = sql;

                foreach (var param in parameters ?? new Dictionary<string, object>())
                {
                    command.Parameters.AddWithValue($"@{param.Key}", param.Value);
                }

                await connection.OpenAsync();
                var result = await command.ExecuteScalarAsync();

                if(int.TryParse(result?.ToString() ?? string.Empty, out int parsedValue))
                {
                    return parsedValue; 
                }

                return 0;
            }
        }

        private static void SetDataEntityValues<TDataEntity>(TDataEntity dataEntity) where TDataEntity : DataEntity
        {
            // don't update created by values if already set
            dataEntity.CreateDate = dataEntity.CreateDate == null ? DateTime.UtcNow : dataEntity.CreateDate;
            dataEntity.CreatedBy = string.IsNullOrWhiteSpace(dataEntity.CreatedBy) ? Constants.SystemName : dataEntity.CreatedBy;

            // always update the updated by values
            dataEntity.LastUpdateBy = Constants.SystemName;
            dataEntity.LastUpdate = DateTime.UtcNow;
        }

        private static string GetColumnName<TDataEntity>(string propertyName)
        {
            return typeof(TDataEntity).GetProperty(propertyName)
                .GetCustomAttribute<ColumnNameAttribute>().Column;
        }

        private static string GetInsertStatement<TDataEntity>(IEnumerable<PropertyInfo> props, string tableName)
        {
            var builder = new StringBuilder($"INSERT INTO {tableName}");
            var columns = $" ({string.Join(",", props.Select(p => GetColumnName<TDataEntity>(p.Name)))})";
            var values = $" ({string.Join(",", props.Select(p => $"@{p.Name}"))});";

            builder.Append(columns);
            builder.Append(" VALUES ");
            builder.Append(values);
            builder.Append(" SELECT LAST_INSERT_ID();");

            return builder.ToString();
        }

        private static string GetUpdateStatement<TDataEntity>(IEnumerable<PropertyInfo> entityProps, string tableName)
        {
            var builder = new StringBuilder($"UPDATE {tableName} SET ");
            builder.Append(string.Join(",", entityProps.Select(prop => $"{GetColumnName<TDataEntity>(prop.Name)}=@{prop.Name}")));
            builder.Append($" WHERE {GetColumnName<TDataEntity>("Id")} = @Id");

            return builder.ToString();
        }

        private static string GetSelectStatement<TDataEntity>(IEnumerable<string> searchCriteria, string tableName)
        {
            var builder = new StringBuilder($"SELECT * FROM {tableName}");

            if (searchCriteria?.Any() ?? false)
            {
                builder.Append(" WHERE ");
                builder.Append(
                    string.Join(
                        " AND ",
                        searchCriteria.Select(criterion => $"{GetColumnName<TDataEntity>(criterion)}=@{criterion}")));
            }

            return builder.ToString();
        }

        private static string GetDeleteStatement<TDataEntity>(string tableName)
        {
            return $"DELETE FROM {tableName} WHERE {GetColumnName<TDataEntity>("Id")} = @Id";
        }

        private static TDataEntity MapEntity<TDataEntity>(DbDataReader reader) where TDataEntity : new()
        {
            var entity = new TDataEntity();

            foreach (var prop in entity.GetType().GetProperties().Where(prop => prop.GetCustomAttribute<ColumnNameAttribute>() != null))
            {
                var name = prop.Name;
                var columName = GetColumnName<TDataEntity>(name);
                var value = reader[columName];

                switch (value)
                {
                    case int intValue:
                        prop.SetValue(entity, intValue);
                        break;
                    case string stringValue:
                        prop.SetValue(entity, stringValue);
                        break;
                    case DateTime dateTimeValue:
                        prop.SetValue(entity, dateTimeValue.ToLocalTime());
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

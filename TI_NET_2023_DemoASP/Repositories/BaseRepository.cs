using Microsoft.Data.SqlClient;
using System.Data;

namespace TI_NET_2023_DemoASP.Repositories
{
    public abstract class BaseRepository<TKey, TEntity> : IBaseRepository<TKey, TEntity> where TEntity : class
    {
        protected readonly IDbConnection _connection;
        protected readonly string _tableName;
        protected readonly string _columnIdName;

        public BaseRepository(IDbConnection connection, string tableName, string columnIdName)
        {
            _connection = connection;
            _tableName = tableName;
            _columnIdName = columnIdName;
        }

        public void OpenConnection(IDbConnection connection)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            connection.Open();
        }

        protected void GenerateParameter(IDbCommand cmd, string paramName, object? value)
        {
            IDataParameter parameter = cmd.CreateParameter();
            parameter.ParameterName = paramName;
            parameter.Value = value ?? DBNull.Value;
            cmd.Parameters.Add(parameter);
        }

        protected abstract TEntity Convert(IDataRecord record);

        public abstract TEntity Create(TEntity entity);

        public IEnumerable<TEntity> ReadAll()
        {
            using (IDbCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = $"SELECT * FROM {_tableName}";
                OpenConnection(_connection);
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    yield return Convert(reader);
                }
            }

        }

        public TEntity ReadOne(TKey id)
        {
            using (IDbCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = $"SELECT * FROM {_tableName} WHERE {_columnIdName} = @id";
                GenerateParameter(cmd, "@id", id);
                OpenConnection(_connection);
                IDataReader reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    throw new KeyNotFoundException();
                }

                TEntity entity = Convert(reader);
                _connection.Close();
                return entity;
            }
        }

        public abstract bool Update(TKey id, TEntity entity);

        public bool Delete(TKey id)
        {
            using (IDbCommand cmd = _connection.CreateCommand())
            {
                cmd.CommandText = $"DELETE FROM {_tableName} " +
                                  $"WHERE {_columnIdName} = @id";
                GenerateParameter(cmd, "@id", id);

                OpenConnection(_connection);

                int nbRow = cmd.ExecuteNonQuery();

                _connection.Close();

                return nbRow == 1;
            }
        }
    }
}

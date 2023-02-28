using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Core.Lib.Adapters;

public sealed class DbAdapter
{
    #region [Declarations]

    private readonly SqlConnection _sqlConnection;

    #endregion [Declarations]

    /// <summary>
    /// Initialises the dbAdapter and opens the dbconnection
    /// </summary>
    /// <param name="connectionString">The database connection string</param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public DbAdapter(string connectionString)
    {
        ArgumentException.ThrowIfNullOrEmpty(connectionString);

        _sqlConnection = new SqlConnection(connectionString);
        _sqlConnection.Open();
    }

    /// <summary>
    /// Closes the connection when the object is destroyed
    /// </summary>
    ~DbAdapter()
    {
        if (_sqlConnection != null)
        {
            // Don't close the connection if the conection is already closed or broken
            if (_sqlConnection.State != ConnectionState.Closed || _sqlConnection.State != ConnectionState.Broken)
            {
                try
                {
                    _sqlConnection.Close();
                }
                catch
                {
                }
            }
        }
    }

    /// <summary>
    /// Returns the dbcommand for stored procedure
    /// </summary>
    /// <param name="name">Name of the stored procedure</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public SqlCommand GetStoredProcedure(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        if (_sqlConnection.State != ConnectionState.Open)
        {
            _sqlConnection.Open();
        }

        var dbCommand = new SqlCommand(name, _sqlConnection)
        {
            CommandType = CommandType.StoredProcedure
        };
        return dbCommand;
    }

    /// <summary>
    /// Execute the query in scalar and closes the connection
    /// </summary>
    /// <param name="dbCommand">SQL Command after adding parameters</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public object ExecuteScalar(SqlCommand dbCommand)
    {
        ArgumentNullException.ThrowIfNull(dbCommand);

        var result = dbCommand.ExecuteScalar();
        return result;
    }

    /// <summary>
    /// Execute the query and returns <see cref="IDataReader"/>
    /// </summary>
    /// <param name="dbCommand">SQL Command after adding parameters</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public IDataReader ExecuteReader(SqlCommand dbCommand)
    {
        ArgumentNullException.ThrowIfNull(dbCommand);

        var result = dbCommand.ExecuteReader();
        return result;
    }

    /// <summary>
    /// Execute the command with ExecuteNonQuery
    /// </summary>
    /// <param name="dbCommand">SQL Command after adding parameters</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public int ExecuteNonQuery(SqlCommand dbCommand)
    {
        ArgumentNullException.ThrowIfNull(dbCommand);

        var result = dbCommand.ExecuteNonQuery();
        return result;
    }
}

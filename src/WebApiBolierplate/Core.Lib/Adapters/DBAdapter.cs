using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Core.Lib.Adapters;

public class DBAdapter
{
    #region [Declarations]

    private readonly SqlConnection connection;

    #endregion [Declarations]

    /// <summary>
    /// Initialises the dbAdapter and opens the dbconnection
    /// </summary>
    /// <param name="connectionString">The database connection string</param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public DBAdapter(string connectionString)
    {
        ArgumentException.ThrowIfNullOrEmpty(connectionString);

        connection = new SqlConnection(connectionString);
        connection.Open();
    }

    /// <summary>
    /// Closes the connection when the object is destroyed
    /// </summary>
    ~DBAdapter()
    {
        if (connection != null)
        {
            // Don't close the connection if the conection is already closed or broken
            if (connection.State != ConnectionState.Closed || connection.State != ConnectionState.Broken)
            {
                try
                {
                    connection.Close();
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
        if (connection.State != ConnectionState.Open)
        {
            connection.Open();
        }

        var dbCommand = new SqlCommand(name, connection)
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

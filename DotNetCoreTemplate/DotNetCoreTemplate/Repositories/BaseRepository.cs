using System.Data;
using System.Data.SqlClient;
using Dapper;
using DotNetCore.Enums;
using DotNetCore.Exceptions;
using DotNetCore.Service.Interfaces;
using Newtonsoft.Json;

namespace DotNetCore.Repositories;

public class BaseRepository
{
    private readonly ILoggerService _logger;
    private readonly IConfiguration _configuration;

    protected BaseRepository(ILoggerService logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    protected IEnumerable<T> Query<T>(string spName, object parameters = null, string database = "Main")
    {
        try
        {
            var cnnString = _configuration.GetConnectionString(database);
            using var conn = new SqlConnection(cnnString);
            var sql = conn.Query<T>(spName, parameters, null, true, 180, CommandType.StoredProcedure);
            return sql;
        }
        catch (Exception ex)
        {
            _logger.Error(
                $"Db Exception on SP : {spName}, {ex.Message}, Parameters : {JsonConvert.SerializeObject(parameters)}.", ex);
            throw new ApiException(ApiErrorEnum.GeneralError, "An exception occurred in database.");
        }
    }

    protected Tuple<IEnumerable<Result1>, IEnumerable<Result2>> QueryMultiple<Result1, Result2>(
        string spName, object parameters = null, string database = "CustomerAgentManagementDB")
    {
        try
        {
            var cnnString = _configuration.GetConnectionString(database);
            using var conn = new SqlConnection(cnnString);
            var sql = conn.QueryMultiple(spName, parameters, null, 180, CommandType.StoredProcedure);
            return new Tuple<IEnumerable<Result1>, IEnumerable<Result2>>(sql.Read<Result1>(), sql.Read<Result2>());
        }
        catch (Exception ex)
        {
            _logger.Error(
                $"Db Exception on SP : {spName}, {ex.Message}, Parameters : {JsonConvert.SerializeObject(parameters)}.",
                ex);
            throw new ApiException(ApiErrorEnum.GeneralError, "An exception occurred in database.");
        }
    }
}
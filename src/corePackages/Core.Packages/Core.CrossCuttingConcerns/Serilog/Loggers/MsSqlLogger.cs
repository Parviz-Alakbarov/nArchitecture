using Core.CrossCuttingConcerns.Serilog.ConfigurationModels;
using Core.CrossCuttingConcerns.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace Core.CrossCuttingConcerns.Serilog.Loggers;

public class MsSqlLogger : LoggerServiceBase
{
    public MsSqlLogger(IConfiguration configuration)
    {
        MsSqlConfiguration msSqlConfiguration =  configuration
            .GetSection("SeriLogConfigurations:MsSqlonfiguration")
            .Get<MsSqlConfiguration>() ?? throw new Exception(SerilogMessages.NullOptionsMessage);

        MSSqlServerSinkOptions sinkOptions = new()
        {
            TableName = msSqlConfiguration.TableName,
            AutoCreateSqlDatabase = msSqlConfiguration.AutoCreateSqlTable,
        };

        ColumnOptions columnOptions = new();

        Logger = new LoggerConfiguration().WriteTo.MSSqlServer(
                connectionString:msSqlConfiguration.ConnectionString,
                sinkOptions:sinkOptions,
                columnOptions: columnOptions
            ).CreateLogger();
    }
}

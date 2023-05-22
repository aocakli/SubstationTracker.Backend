using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NpgsqlTypes;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.PostgreSQL;

namespace SubstationTracker.Infrastructure.Loggers.SeriLog;

public static class SerilogExtensions
{
    public static void AddSerilogDependencies(this IServiceCollection services)
    {
        services.AddLogging(x => x.AddSerilog());
    }

    public static void IncludeLogger(this WebApplicationBuilder builder)
    {
        IDictionary<string, ColumnWriterBase> columnWriters = new Dictionary<string, ColumnWriterBase>
        {
            { "message", new RenderedMessageColumnWriter(NpgsqlDbType.Text) },
            { "message_template", new MessageTemplateColumnWriter(NpgsqlDbType.Text) },
            { "level", new LevelColumnWriter(true, NpgsqlDbType.Varchar) },
            { "raise_date", new TimestampColumnWriter(NpgsqlDbType.Timestamp) },
            { "exception", new ExceptionColumnWriter(NpgsqlDbType.Text) },
            { "properties", new LogEventSerializedColumnWriter(NpgsqlDbType.Jsonb) },
            { "props_test", new PropertiesColumnWriter(NpgsqlDbType.Jsonb) },
            {
                "machine_name",
                new SinglePropertyColumnWriter("MachineName", PropertyWriteMethod.ToString, NpgsqlDbType.Text, "l")
            }
        };
        
        var logger = new LoggerConfiguration()
            .WriteTo.PostgreSQL(
                connectionString: builder.Configuration.GetConnectionString("PostgreSql")!,
                tableName: "SeriLogs",
                columnOptions: columnWriters,
                needAutoCreateTable: true,
                restrictedToMinimumLevel: LogEventLevel.Error)
            .CreateLogger();

        builder.Logging.AddSerilog(logger);
    }
}
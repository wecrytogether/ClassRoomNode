namespace PrimaryDbSqlServer.Settings;

public record PrimaryDbSqlServerSettings
{
    public required string ConnectionStr { get; init; }
}
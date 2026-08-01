using System.Net;

namespace CSBank.Domain.Entities;

public class AuditLogs
{
    public Guid Id { get; private set; }
    public EntityNames EntityName { get; private set; }
    public Guid? EntityId { get; private set; }
    public Actions Action { get; private set; }
    public Guid PerformedBy { get; private set; }
    public DateTime PerformedAt { get; private set; }
    public Dictionary<string, object>? OldValues { get; private set; }
    public Dictionary<string, object>? NewValues { get; private set; }
    public IPAddress? IpAddress { get; private set; }
    public string? UserAgent { get; private set; }

    private AuditLogs() { }

    public AuditLogs(
        EntityNames entityName,
        Guid? entityId,
        Actions action,
        Guid performedBy,
        Dictionary<string, object>? oldValues,
        Dictionary<string, object>? newValues,
        string? userAgent
    )
    {
        EntityName = entityName;
        EntityId =entityId;
        Action = action;
        PerformedBy = performedBy;
        PerformedAt = PerformedAt;
        OldValues = oldValues;
        NewValues = newValues;
        UserAgent = userAgent;
    }
}
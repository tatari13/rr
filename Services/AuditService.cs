
using System.Collections.Concurrent;

namespace LAPS_WebUI.Services

{
    public class AuditService
    {
        private readonly ConcurrentBag<AuditEntry> _entries = new();

        public void Log(string username, string action, string target)
        {
            _entries.Add(new AuditEntry
            {
                Username = username,
                Action = action,
                Target = target,
                Timestamp = DateTime.Now
            });
        }

        public IEnumerable<AuditEntry> GetEntries()
        {
            return _entries.OrderByDescending(e => e.Timestamp);
        }
    }

    public class AuditEntry
    {
        public string Username { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public string Target { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
    }
}

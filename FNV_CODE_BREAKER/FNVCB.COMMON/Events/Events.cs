using FNVCB.COMMON.Interfaces;

namespace FNVCB.COMMON.Events
{
    public class GuessAddedEvent : IEvent
    {
        public required string Value { get; set; }
        public required string Score { get; set; }
    }
    public class ComparisonAddedEvent : IEvent
    {
        public required string Value { get; set; }
    }
    public class UpdateOutputEvent : IEvent
    { 
        public required string NewLine { get; set; }
    }

    public class ClearCacheEvent : IEvent
    { }
}

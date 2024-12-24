using FNVCG.COMMON.Interfaces;

namespace FNVCG.COMMON.Events
{
    public class SelectionMadeEvent : IEvent
    {
        public required string Value { get; set; }
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

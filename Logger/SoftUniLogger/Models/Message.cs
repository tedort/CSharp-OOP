namespace SoftUniLogger.Models
{
    public class Message
    {
        public Message(DateTime dateTime, LogEntryLevel logEntryLevel, string logMessage)
        {
            DateTime = dateTime;
            LogEntryLevel = logEntryLevel;
            LogMessage = logMessage;
        }

        public DateTime DateTime { get; set; }
        public LogEntryLevel LogEntryLevel { get; set; }
        public string LogMessage { get; set; }
    }
}

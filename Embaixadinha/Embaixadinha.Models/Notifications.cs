namespace Embaixadinha.Models
{
    public class Notifications
    {
        public Notifications(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; }
        public string Value { get; }
    }
}

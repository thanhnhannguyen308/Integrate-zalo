namespace Zalo.Model
{
    public class MessageTextModel
    {
        public Data DataMessageTextModel { get; set; }
        public int Error { get; set; }
        public string Message { get; set; }
    }

    public class DataMessageTextModel
    {
        public string MessageId { get; set; }
        public string UserId { get; set; }
    }
}
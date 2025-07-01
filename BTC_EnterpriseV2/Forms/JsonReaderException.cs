
namespace BTC_EnterpriseV2.Forms
{
    [Serializable]
    internal class JsonReaderException : Exception
    {
        public JsonReaderException()
        {
        }

        public JsonReaderException(string? message) : base(message)
        {
        }

        public JsonReaderException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
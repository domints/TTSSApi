using TTSSApi.Web.Enums;

namespace TTSSApi.Web.Models.Internal
{
    internal class Response
    {
        private readonly string _data;
        private readonly ResponseReason _reason;

        public Response(string data, ResponseReason reason = ResponseReason.Correct)
        {
            _data = data;
            _reason = reason;
        }

        public string Data { get { return _data; } }
        public ResponseReason Reason { get { return _reason; } }
    }
}
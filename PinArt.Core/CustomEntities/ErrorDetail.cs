using Newtonsoft.Json;

namespace PinArt.Core.CustomEntities
{
    public class ErrorDetail
    {
        public int Status { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

        public ErrorDetail()
        { }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

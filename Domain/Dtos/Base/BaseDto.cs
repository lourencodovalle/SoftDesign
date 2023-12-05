using System.Net;

namespace Domain.Dtos.Base
{
    public class BaseDto
    {
        public BaseDto()
        {
            Status = HttpStatusCode.OK;
        }

        public HttpStatusCode Status { get; set; }
        public string Message { get; set; } 
    }
}

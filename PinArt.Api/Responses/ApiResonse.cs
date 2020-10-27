using PinArt.Core.CustomEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PinArt.Api.Responses
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
        }

        public bool success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public Metadata Metadata { get; set; } 

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PAS.Application.Dto
{
    public class Response<T>
    { 
        public bool IsSuccess { get; set; }

        public string Code { get; set; }

        public string? Message { get; set; }

        public object? Result { get; set; }

        public T? Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

    }
}

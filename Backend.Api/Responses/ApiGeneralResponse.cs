using Backend.Core.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Api.Responses
{
    public class ApiGeneralResponse<T>
    {
        public ApiGeneralResponse(T data)
        {
            Data = data;
        }

        public T Data { get; private set; }
        public Metadata Metadata { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FiboInfraStructure.Common
{
    public class ResponseData
    {
        public bool Success { get; set; }
        public ResponseTypeOption ResponseType { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

    public class ResponseData<T> : ResponseData
    {
        public T RespData { get; set; }
    }

    public enum ResponseTypeOption
    {
        Success = 1,
        Failed = 2,
        Exception = 3,
        ModelValidationError = 4,
        DuplicateData = 5,
        NoContent = 6
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Model
{
    public class AppResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public AppResponse(bool isSucess, string message)
        {
            IsSuccess = isSucess;
            Message = message;
        }
        public AppResponse(bool isSucess, string message, object data)
        {
            IsSuccess = isSucess;
            Message = message;
            Data = data;
        }
    }
}

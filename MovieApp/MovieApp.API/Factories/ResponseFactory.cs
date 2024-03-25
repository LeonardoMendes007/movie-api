using Microsoft.AspNetCore.Mvc;
using MovieApp.API.Response;
using System.Net;

namespace MovieApp.API.Extensions;

public static class ResponseFactory
{
    public static ResponseBase<T> ResponseBase<T>(this ControllerBase controller,T data, HttpStatusCode httpStatusCode)
    {
        return new ResponseBase<T>(data, httpStatusCode);
    }
    public static ResponseBase ResponseBase(this ControllerBase controller, HttpStatusCode httpStatusCode, string message)
    {
        return new ResponseBase(httpStatusCode, message);
    }
    public static ResponseBase ResponseBase(this ControllerBase controller, HttpStatusCode httpStatusCode)
    {
        return new ResponseBase(httpStatusCode);
    }
}

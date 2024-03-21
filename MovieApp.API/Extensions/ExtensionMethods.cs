using Microsoft.AspNetCore.Mvc;
using MovieApp.API.Response;
using System.Net;

namespace MovieApp.API.Extensions;

public static class ExtensionMethods
{
    public static ResponseBase<T> ResponseBaseFactory<T>(this ControllerBase controllerBase, T data, HttpStatusCode httpStatusCode)
    {
        return new ResponseBase<T>(data, httpStatusCode);
    }
}

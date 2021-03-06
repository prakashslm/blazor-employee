﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BlazorCrud.Server
{
  public class ErrorHandlingMiddleware
  {
    private readonly RequestDelegate next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
      this.next = next;
    }
    public async Task Invoke(HttpContext context)
    {
      try
      {
        await next(context);
      }
      catch (Exception ex)
      {
        await HandleExceptionAsync(context, ex);
      }
    }
    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
      var code = HttpStatusCode.InternalServerError;
      //if (exception is Exception)
      //{
      //  code = HttpStatusCode.BadRequest;
      //}
      //if (exception is MyNotFoundException) code = HttpStatusCode.NotFound;
      //else if (exception is MyUnauthorizedException) code = HttpStatusCode.Unauthorized;
      //else if (exception is MyException) code = HttpStatusCode.BadRequest;
      var result = JsonConvert.SerializeObject(new { error = exception.Message });
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)code;
      return context.Response.WriteAsync(result);
    }
  }
}

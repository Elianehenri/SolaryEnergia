using SolaryEnergia.Domain.DTOs;
using SolaryEnergia.Domain.Exceptions;
using System.Net;

namespace SolaryEnergia.API.Config
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ExceptionTreatment(context, ex);
            }
        }
        private Task ExceptionTreatment(HttpContext context, Exception ex)
        {
            HttpStatusCode status;
            string message;

            if (ex is DataCadastradaException)
            {
                status = HttpStatusCode.NotAcceptable;
                message = ex.Message;
            }
            else if(ex is UnidadeInativaException)
            {
                status = HttpStatusCode.NotAcceptable;
                message = ex.Message;
            }
            else if( ex is UserNaoCadastradoException)
            {
                status = HttpStatusCode.Forbidden;
                message = ex.Message;
            }
            else
            {
                status = HttpStatusCode.InternalServerError;
                message = " Estamos passando por instabilidades, tente novamente em alguns instantes.";
            }
            var response = new ErrorDto(message);
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsJsonAsync(response);


        }
    }
}

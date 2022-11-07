using System;
namespace apiJuanXXIII.Helper
{
    public class ErrorResponse
    {
        public string tipo { get; set; }
        public string mensaje { get; set; }
        public string traza { get; set; }

        public ErrorResponse(Exception ex)
        {
            tipo = ex.GetType().Name;
            mensaje = ex.Message;
            traza = ex.ToString();
        }
    }
}


using System;
namespace Comander.Dto
{
    public class ErrorResponseDto
    {
        public ErrorResponseDto(Exception pException, bool pTrace = false)
        {
            Mensagem = pException.Message;
            StackTraceInfo = pTrace ? pException.StackTrace : null;
        }
        public string Mensagem { get; internal set; }
        public string StackTraceInfo { get; internal set; }
    }
}
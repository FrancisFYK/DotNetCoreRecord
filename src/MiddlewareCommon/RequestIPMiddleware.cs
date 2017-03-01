using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using log4net.Repository;
using log4net;
using System.IO;
using log4net.Config;

namespace MiddlewareCommon
{
    /// <summary>
    /// 记录用户IP中间件 Middleward
    /// </summary>
    public class RequestIPMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ILogger _logger;

        private readonly ILog _log;
        public RequestIPMiddleware(RequestDelegate next/*, ILog log*/)
        {
            this._next = next;
            //this._logger = loggerFactory.CreateLogger<RequestIPMiddleware>();

            //创建Log4net
            var _repository = LogManager.CreateRepository("RequestIPMiddleware");
            XmlConfigurator.Configure(_repository, new FileInfo("log4net.config"));
            _log = LogManager.GetLogger(_repository.Name, typeof(RequestIPMiddleware));
        }
        public async Task Invoke(HttpContext context)
        {
            //_logger.LogInformation($"User IP:{context.Connection.RemoteIpAddress}");
            _log.Info($"User IP:{context.Connection.RemoteIpAddress}| _log.HashCode:{_log.GetHashCode()} ");
            await _next.Invoke(context);
        }
    }

    /// <summary>
    /// 扩展方法 注册中间件
    /// </summary>
    public static class RequestIPExtensions
    {
        public static IApplicationBuilder UseRequestIP(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestIPMiddleware>();
        }
    }
}

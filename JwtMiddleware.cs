using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;
using ShareBucket.JwtMiddlewareClient.Helpers;
using Microsoft.EntityFrameworkCore;
using ShareBucket.DataAccessLayer.Data;
using ShareBucket.JwtMiddlewareClient.Services;

namespace ShareBucket.JwtMiddlewareClient
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IJwtUtils _jwtUtils;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
            _jwtUtils = new JwtUtils();
        }

        public async Task Invoke(HttpContext context, DataContext dbContext)
        {
            // Deprecated
            // var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            // if(token == null)
            // {
            //     token = context.Request.Cookies["X-Access-Token"];
            // }
            var token = context.Request.Cookies["X-Access-Token"];
            var userId = _jwtUtils.ValidateToken(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                // Make a simple _context get user by id
                context.Items["User"] = dbContext.Users.Find(userId.Value);
                    //.GetById(userId.Value);
            }

            await _next(context);
        }
    }
}
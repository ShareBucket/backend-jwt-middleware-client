using System;

namespace ShareBucket.JwtMiddlewareClient.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttribute : Attribute
    { }
}
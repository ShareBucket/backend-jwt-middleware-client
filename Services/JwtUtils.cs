using Grpc.Net.Client;
using ShareBucket.JwtMiddlewareClient.GrpServices;

namespace ShareBucket.JwtMiddlewareClient.Services
{
    public interface IJwtUtils
    {
        public int? ValidateToken(string token);
    }

    public class JwtUtils : IJwtUtils
    {

        public JwtUtils()
        {
        }
            
        public int? ValidateToken(string token)
        {
            // Make the request to the auth service through grpc
            var channel = GrpcChannel.ForAddress("https://localhost:7001");
            var client = new TokenService.TokenServiceClient(channel);


            var reply = client.TokenValidationRequest(new TokenRequest { Token = token });

            if (reply.IsValid)
            {
                return reply.UserId;
            }
            else
            {
                return null;
            }


        }
    }
}
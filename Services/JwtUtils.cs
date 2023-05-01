using Grpc.Net.Client;
using ShareBucket.JwtMiddlewareClient.GrpServices;

namespace ShareBucket.JwtMiddlewareClient.Services
{
    public interface IJwtUtils
    {
        public int? ValidateToken(string token);
        public string GenerateToken(int userId);
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


            if (token != null)
            {
                var reply = client.TokenValidationRequest(new TokenParam { Token = token });

                if (reply.IsValid)
                {
                    return reply.UserId;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        public string GenerateToken(int userId)
        {
            // Make the request to the auth service through grpc
            var channel = GrpcChannel.ForAddress("https://localhost:7001");
            var client = new TokenService.TokenServiceClient(channel);

            var reply = client.TokenGenerationRequest(new IdUserParam { Id = userId });

            return reply.Token;
        }
    }
}
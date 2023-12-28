using CustomersApi.Repositories;
using Serilog;

namespace CustomersApi
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IJwtService _jwtService;

        public AuthService(IAuthRepository authRepository, IJwtService jwtService)
        {
            _authRepository = authRepository;
            _jwtService = jwtService;
        }

        public async Task<Auth> Auth(string username, string password)
        {
            Auth auth = new Auth();
            var entity = await _authRepository.Auth(username, password);

            if(entity != null)
            {
                auth.usuario = entity.User_name;
                auth.token = _jwtService.generateToken(username);

                Log.Information("El usuario {@username} se autentifico correctamente", username);

            }
            else
            {
                auth.usuario = "Credenciales incorrectos";

                Log.Information("El usuario {@username} fallo en autentificarse", username);
            }
            return auth;
        }
    }
}

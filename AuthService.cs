using CustomersApi.Repositories;

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

            }
            else
            {
                auth.usuario = "Credenciales incorrectos";
            }
            return auth;
        }
    }
}

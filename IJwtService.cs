namespace CustomersApi
{
    public interface IJwtService
    {
        public string generateToken(string user);
    }
}

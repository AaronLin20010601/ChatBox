namespace ChatBox_User.Services.Interfaces.Token
{
    public interface IJwtTokenService
    {
        string CreateJwtToken(Models.Entities.User user);
    }
}

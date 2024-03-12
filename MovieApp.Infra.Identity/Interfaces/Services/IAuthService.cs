using MovieApp.Infra.Identity.Model;

namespace MovieApp.Infra.Identity.Interfaces.Services;
public interface IAuthService
{
    public Task<AuthResult> RegisterAccount(string userName, string email, string password);
    public Task<AuthResult> SignInAsync(string email, string password);

}

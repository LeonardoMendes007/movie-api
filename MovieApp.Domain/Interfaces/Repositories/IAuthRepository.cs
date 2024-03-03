using MovieApp.Domain.Dtos.Account;
using MovieApp.Domain.Dtos.Credentials;

namespace MovieApp.Domain.Interfaces.Repository;
public interface IAuthRepository
{
    Task<CredentialsDto> RegisterAsync(CreateAccountDto createUserDto, string password);
    Task<CredentialsDto> SignInAsync(string userName, string password);
}

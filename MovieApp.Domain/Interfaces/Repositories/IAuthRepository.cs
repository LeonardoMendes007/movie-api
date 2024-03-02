using MovieApp.Domain.Dtos;

namespace MovieApp.Domain.Interfaces.Repository;
public interface IAuthRepository
{
    Task<bool> RegisterAsync(CreateUserDto createUserDto, string password);
    Task<bool> SignInAsync(string userName, string password);
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Dtos.Account;
using MovieApp.Domain.Dtos.Credentials;
using MovieApp.Domain.Interfaces.Repository;
using MovieApp.Infra.Identity.Identity;

namespace MovieApp.Infra.Identity.Persistence.Repositories;
public class AuthRepository : IAuthRepository
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;

    public AuthRepository(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task<CredentialsDto> RegisterAsync(CreateAccountDto createUserDto, string password)
    {
        var applicationUser = new ApplicationUser() {
            UserName = createUserDto.UserName,
            Email = createUserDto.Email
        };

        var identityResult = await _userManager.CreateAsync(applicationUser, password);

        if (identityResult.Succeeded)
        {
            var applicationUserPersist = await _userManager.FindByNameAsync(applicationUser.UserName);

            return new CredentialsDto()
            {
                id = Guid.Parse(applicationUserPersist.Id),
                UserName = applicationUserPersist.UserName,
                Email = applicationUserPersist.Email
            };
        }
        
        return null;
    }

    public async Task<CredentialsDto> SignInAsync(string userName, string password)
    {
        var applicationUserPersist = await _userManager.FindByNameAsync(userName);
        if(applicationUserPersist != null && await _userManager.CheckPasswordAsync(applicationUserPersist, password))
        {
            return new CredentialsDto()
            {
                id = Guid.Parse(applicationUserPersist.Id),
                UserName = applicationUserPersist.UserName,
                Email = applicationUserPersist.Email
            };
        }

        return null;
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public async Task Rollback()
    {
        await _context.DisposeAsync();
    }


}
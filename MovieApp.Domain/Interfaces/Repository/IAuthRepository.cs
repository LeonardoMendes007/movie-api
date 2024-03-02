using Microsoft.AspNetCore.Identity;
using MovieApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Domain.Interfaces.Repository;
public interface IAuthRepository
{
    Task<ApplicationUser> RegisterAsync(ApplicationUser appUser, string password);
    Task<ApplicationUser> SignInAsync(string userName, string password);
    Task<IdentityResult> UpdateAsync(ApplicationUser appUser);
    Task<IdentityResult> ChangePassword(ApplicationUser appUser, string currentPassword, string newPassword);

}

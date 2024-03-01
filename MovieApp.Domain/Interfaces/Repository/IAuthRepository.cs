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
    Task<IdentityResult> RegisterAsync(ApplicationUser authUser, string password);
    Task<bool> LoginAsync(string userName, string password);
    Task<IdentityResult> UpdateAsync(ApplicationUser authUser);
    Task<IdentityResult> ChangePassword(ApplicationUser authUser, string currentPassword, string newPassword);

}

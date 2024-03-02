using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Domain.Dtos;
public class CreateUserDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
}

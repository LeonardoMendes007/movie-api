﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Domain.Entities;

public class ApplicationUser 
{
    public User User { get; set; }
    public Guid UserId { get; set; }
}

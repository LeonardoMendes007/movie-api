﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Domain.Entities.@base;
public abstract class Entity
{
    public Guid Id { get; private set; }
}
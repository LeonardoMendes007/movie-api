using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Domain.Exceptions;
public class ResourceNotFoundException : Exception
{
    public Guid Id { get; set; }

    public ResourceNotFoundException()
    {
    }

    public ResourceNotFoundException(Guid id)
    {
        Id = id;
    }
}

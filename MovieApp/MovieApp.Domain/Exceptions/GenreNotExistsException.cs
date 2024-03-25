using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Domain.Exceptions;
public class GenreNotExistsException : Exception
{
    public Guid Id { get; private set; }
    public GenreNotExistsException(Guid id) : base($"The Genre with id = {id} does not exists")
    {
        Id = id;
       
    }
}

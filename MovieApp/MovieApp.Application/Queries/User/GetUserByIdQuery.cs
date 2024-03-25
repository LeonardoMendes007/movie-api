using MediatR;
using MovieApp.Application.Responses.User;

namespace MovieApp.Application.Queries.User;
public class GetUserByIdQuery : IRequest<UserResponse>
{
    public Guid Id { get; set; }

    public GetUserByIdQuery(Guid id)
    {
        Id = id;
    }
}

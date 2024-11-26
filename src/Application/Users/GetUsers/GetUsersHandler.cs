using Application.Common.Interfaces.Users;
using AutoMapper;
using Domain.Infrastructure.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.GetUsers;

public class GetUsersHandler : IRequestHandler<GetUsersQuery, GetUsersDto>
{
    private readonly IUsersClient _usersClient;
    private readonly IMapper _mapper;

    public GetUsersHandler(IUsersClient usersClient,
        IMapper mapper)
    {
        this._usersClient = usersClient;
        this._mapper = mapper;
    }

    public async Task<GetUsersDto> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var users = await _usersClient.GetUsers(request.page);
            var response = _mapper.Map<GetUsersResponse, GetUsersDto>(users);
            return response;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}

using Domain.Infrastructure.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Users;

public interface IUsersClient
{
    Task<GetUsersResponse> GetUsers(int page);
}

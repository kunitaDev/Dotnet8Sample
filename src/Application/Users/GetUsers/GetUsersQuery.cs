﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.GetUsers;

public class GetUsersQuery : IRequest<GetUsersDto>
{
    public int page { get; set; }
}

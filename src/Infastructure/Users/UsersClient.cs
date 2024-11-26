using Application.Common.Extensions;
using Application.Common.Interfaces.Users;
using Domain.Infrastructure.Users;
using Infastructure.Common.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Users;
public class UsersClient : IUsersClient
{
    private readonly HttpClient _httpClient;
    private readonly UsersClientOptions _options;

    public UsersClient(HttpClient  httpClient,
        IOptions<UsersClientOptions> options)
    {
        this._httpClient = httpClient;
        this._options = options.Value;
    }

    public async Task<GetUsersResponse> GetUsers(int page)
	{
		try
		{
            var url = _options.GetListUser.Replace("{pageNo}", page.ToString());
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAs<GetUsersResponse>();
            return result;
        }
		catch (Exception ex)
		{
			throw ex;
		}
	}
}

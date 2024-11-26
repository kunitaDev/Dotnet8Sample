using System.Text.Json;

namespace Application.Common.Extensions;

public static class HttpContentExtensions
{
    public static async Task<T> ReadAs<T>(this HttpContent httpContent)
    {
        var json = await httpContent.ReadAsStringAsync();

        if (string.IsNullOrWhiteSpace(json))
        {
            return default;
        }

        return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }
}

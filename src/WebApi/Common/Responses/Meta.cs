using Application.Common.Queryable;

namespace WebApi.Common.Responses;

public class Meta
{
    /// <summary>
    /// Временый токен
    /// </summary>
    public string TemporaryToken { get; set; }

    /// <summary>
    /// Токен доступа 
    /// </summary>
    public string AccessToken { get; set; }

    /// <summary>
    /// Токен для обновления токена доступа
    /// </summary>
    public string RefreshToken { get; set; }

    /// <summary>
    /// Параметры пагинации
    /// </summary>
    public PaginateParam Pagination { get; set; }

    /// <summary>
    /// Хост для получения файлов
    /// </summary>
    public string FileUrl { get; set; }
}

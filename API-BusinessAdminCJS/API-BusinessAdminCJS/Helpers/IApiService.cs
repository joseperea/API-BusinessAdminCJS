using API_BusinessAdminCJS.ModelsView;

namespace API_BusinessAdminCJS.Helpers
{
    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string servicePrefix, string controller);
    }
}

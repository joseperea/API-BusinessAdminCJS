using API_BusinessAdminCJS.ModelsView;

namespace API_BusinessAdminCJS.Services
{
    public interface  IAuthManager
    {
        Task<bool> ValidateUser(LoginUserDTO loginUserDTO);
        Task<string> CreateToken();
    }
}

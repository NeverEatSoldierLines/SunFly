using NovelRepositories.IRepositories;
using NovelServices.IServices;

namespace NovelServices.Services;

public class AdminService : IAdminService
{
    public IAdminRepository AdminRepository { get;}

    public AdminService(IAdminRepository adminRepository)
    {
        AdminRepository = adminRepository;
    }
}
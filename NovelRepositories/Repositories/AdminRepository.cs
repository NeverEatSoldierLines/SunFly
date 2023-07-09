using NovelRepositories.Contexts;
using NovelRepositories.IRepositories;

namespace NovelRepositories.Repositories;

public class AdminRepository : IAdminRepository
{
    public AdminContext AdminContext { get; set; }

    public AdminRepository(AdminContext adminContext)
    {
        AdminContext = adminContext;
    }
}
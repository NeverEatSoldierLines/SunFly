using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NovelRepositories.Contexts;
using NovelServices.IServices;

namespace NovelControllers.Controllers;


/// <summary>
/// 暂时只允许本地访问,等上线之后允许更多人访问管理员接口
/// </summary>
[EnableCors]
[Route("api/[controller]/[action]")]
[ApiController]
public class AdminController : ControllerBase
{
    public IAdminService AdminService { get;}
    public ILogger<AdminController> Logger { get; set; }
    public AdminController(IAdminService adminService, ILogger<AdminController> logger)
    {
        Logger = logger;
        AdminService = adminService;
    }
    
}
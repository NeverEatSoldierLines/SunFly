using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NovelRepositories.ViewModel;
using NovelServices.IServices;

namespace NovelControllers.Controllers;
/// <summary>
/// 开发规范待做
/// 简易版规范:
/// 1、复杂请求、密集请求、数据量大的请求使用async和await
/// 2、复杂逻辑交给service层
/// 3、与网络进行交互的数据量尽量少
/// 4、service层动词使用get、set等, repository层使用find,add等
///
/// OK : 200
/// NoContent: 204
/// Conflict: 409
/// BadRequest: 400
/// </summary>
[Route("api/[controller]/[action]")]
[EnableCors("allowAllPolicy")]
[ApiController]
public class UserController: ControllerBase
{
    private IUserService UserService { get; }
    public ILogger<UserController> Logger { get; }
    public UserController(IUserService userService, ILogger<UserController> logger)
    {
        Logger = logger;
        UserService = userService;
    }

    [HttpPost]
    public IActionResult Register(string username, string email,string headLink, string selfIntroduction,string pwdToken, string ip)
    {
        var res = UserService.UserRegAsync(new UserViewModel
        {
            Username = username,
            Email = email,
            HeadLink = headLink,
            SelfIntroduction = selfIntroduction
        }, ip,pwdToken).Result;//ip不属于UserViewModel

        return res switch
        {
            -2 or -1 => Conflict(),// 冲突409 "Username or Email already exists"
            1 => Ok(),
            var _ => BadRequest()//400 坏请求  "Network error! Insert defeat!"
        };
    }

    [HttpPost]
    public IActionResult Login(string username, string pwdToken)//前端加密密码传给一个序列
    {
        var isSuccess = UserService.CheckUserLogin(username,pwdToken);
        return isSuccess switch
        {
            true => Ok(),
            false => BadRequest()
        };
    }

    /// <summary>
    /// 该方法用于查询其他用户,只查询非敏感信息
    /// action会自动去掉Async后缀,访问时不要加Async
    /// </summary>
    /// <param name="page"></param>
    /// <param name="condition"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetUsersAsync(int page, string? condition)
    {
        if (string.IsNullOrEmpty(condition))
        {
            condition = "";
        }
        var userViewModels = await UserService.GetUsersByCondition(page,condition);
        if (userViewModels.Equals(null) || userViewModels.Count == 0)
        {
            return NoContent(); //204 
        }
        return Ok(new JsonResult(userViewModels));
    }
}
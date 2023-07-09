using NovelRepositories.Entities;
using NovelRepositories.ViewModel;

namespace NovelRepositories.IRepositories;

public interface IUserRepository
{
    /// <summary>
    /// 添加用户
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public Task<int> AddUser(User user);

    /// <summary>
    /// 只查询username,email和status,减少网络I/O
    /// </summary>
    /// <returns>用户名,电子邮箱,用户状态(若为旧用户则不允许登陆)</returns>
    public (string?, string?) FindUsernamesEmails(string username, string email);
    
    /// <summary>
    /// 通过用户名查询用户
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    public Task<User?> FindUserByUsernameAsync(string username);

    public string? FindPwdTokenByUsername(string username);
    Task<List<UserViewModel>> FindUserViewModelByConditions(int page, string conditions);
}
using NovelRepositories.Contexts;
using NovelRepositories.DataInMemory;
using NovelRepositories.Entities;
using NovelRepositories.IRepositories;
using NovelRepositories.Utils;
using NovelRepositories.ViewModel;
using NovelServices.IServices;

namespace NovelServices.Services;

public class UserService :IUserService
{
    private IUserRepository UserRepository { get;}

    public UserService(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    /// <summary>
    /// -2代表用户名已存在, 注销后该账户依然存在,只是软删除
    /// -1表示邮箱已存在
    /// 0表示插入失败
    /// >0 成功
    /// </summary>
    /// <param name="viewModel"></param>
    /// <param name="ipStr"></param>
    /// <param name="pwdToken"></param>
    /// <returns></returns>
    public async Task<int> UserRegAsync(UserViewModel viewModel, string ipStr,string pwdToken)
    {
        //user检查
        var checkTarget = UserRepository.FindUsernamesEmails(viewModel.Username, viewModel.Email ?? throw new InvalidOperationException());
        
        if (checkTarget.Item1 != null) //-2代表用户名已存在, 注销后该账户依然存在,只是软删除
        {
            return -2;
        }

        if (checkTarget.Item2 != null) // -1表示邮箱已存在
        {
            return -1;
        } 
        //可以注册,不用再做检查
        var user = new User
        {
            Username = viewModel.Username,
            Email = viewModel.Email,
            HeadLink = viewModel.HeadLink,
            RegisterTime = DateTime.Now,
            LastLoginTime = DateTime.Now,
            LastIp = IpUtils.Ip2Int(ipStr),
            Role = 8,
            Status = 0,
            Level = 0,
            IsVip = false,
            SelfIntroduction = viewModel.SelfIntroduction,
            TagList = $"{Tag.NewUser}",
            WearTag = Tag.NewUser,
            Collections = "",
            Followed = "",
            Follows = "",
            ColorStone = 0,
            Feather = 0,
            PwdToken = pwdToken
        };
        return await UserRepository.AddUser(user);
    }

    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        return await UserRepository.FindUserByUsernameAsync(username);
    }

    /// <summary>
    /// 只判断是否成功,提示信息只需要为:登陆成功 or 登陆失败,请检查您的用户名或密码是否输入错误
    /// </summary>
    /// <param name="username"></param>
    /// <param name="pwdToken"></param>
    /// <returns></returns>
    public bool CheckUserLogin(string username, string pwdToken)
    {
        var realPwdToken = UserRepository.FindPwdTokenByUsername(username);
        if (string.IsNullOrEmpty(realPwdToken))
        {
            return false;
        }
        return pwdToken == realPwdToken;
    }

    public async Task<List<UserViewModel>> GetUsersByCondition(int page, string condition)
    {
        return await UserRepository.FindUserViewModelByConditions(page, condition);
    }
}
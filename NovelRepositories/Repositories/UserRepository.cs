using Microsoft.EntityFrameworkCore;
using NovelRepositories.Contexts;
using NovelRepositories.Entities;
using NovelRepositories.IRepositories;
using NovelRepositories.ViewModel;

namespace NovelRepositories.Repositories;

public class UserRepository:IUserRepository
{
    private UserContext UserContext { get; }

    public UserRepository(UserContext userContext)
    {
        UserContext = userContext;
    }
    public async Task<int> AddUser(User user)
    {
        await UserContext.Users!.AddAsync(user);
        return await UserContext.SaveChangesAsync();
    }

    public (string?, string?) FindUsernamesEmails(string username, string email)
    {
        var res =  UserContext.Users!.Select(user  
            => new 
            {
                user.Username,
                user.Email
            }
        ).FirstOrDefault(res1 => res1.Username == username || res1.Email == email);
        return res != null ? ("","") : (res?.Username,res?.Email);
    }

    public async Task<User?> FindUserByUsernameAsync(string username)
    {
         var user = UserContext.Users!.FirstOrDefaultAsync(u => u.Username == username);
         return await user;
    }

    public string? FindPwdTokenByUsername(string username)
    {
        return UserContext.Users!.Select(user => user.PwdToken).FirstOrDefault(user => user == username);
    }

    public async Task<List<UserViewModel>> FindUserViewModelByConditions(int page, string condition)
    {
        var userViewModels = await (UserContext.Users ?? throw new InvalidOperationException()).Select(user => new UserViewModel
            {
                Username = user.Username!,
                SelfIntroduction = user.SelfIntroduction!,
                HeadLink = user.HeadLink!,
                Email = ""
            }).Where(
                arg => arg.Username.Contains(condition)
                       || arg.SelfIntroduction.Contains(condition))
            .Skip((page - 1) * 15).Take(15).ToListAsync();
        return userViewModels;
    }
}
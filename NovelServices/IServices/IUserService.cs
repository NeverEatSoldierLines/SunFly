

using NovelRepositories.DataInMemory;
using NovelRepositories.Entities;
using NovelRepositories.ViewModel;

namespace NovelServices.IServices;
public interface IUserService
{
    public Task<int> UserRegAsync(UserViewModel viewModel, string ipv4InString, string pwdToken);

    public Task<User?> GetUserByUsernameAsync(string username);
    public bool CheckUserLogin(string username, string pwdToken);
    public Task<List<UserViewModel>> GetUsersByCondition(int page, string conditions);
}
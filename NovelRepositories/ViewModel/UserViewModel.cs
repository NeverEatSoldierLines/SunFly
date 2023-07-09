using NovelRepositories.DataInMemory;

namespace NovelRepositories.ViewModel;

public class UserViewModel
{
    public string Username { get; set; } = null!;
    public string? Email { get; set; }
    
    /// <summary>
    /// 头像图片链接
    /// </summary>
    public string HeadLink { get; set; } = null!;

    
    /// <summary>
    /// 自我描述,可为空
    /// </summary>
    public string SelfIntroduction { get; set; } = null!;

}
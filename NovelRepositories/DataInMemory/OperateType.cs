using System.ComponentModel.DataAnnotations;

namespace NovelRepositories.DataInMemory;

/// <summary>
/// 管理员操作类型
/// </summary>
public enum AdminOperateType
{
    [Display(Name = "RecommendNewAdmin",Description = "推荐新的管理员")]
    RecommendNewAdmin,
    
    [Display(Name = "AddNewEditor", Description = "添加新的编辑")]
    AddNewEditor,
    
    [Display(Name = "BanEditor", Description = "封禁违规的管理员")]
    BanEditor,
    
    [Display(Name = "BanUser",Description = "封禁违规的用户")]
    BanUser,
    
    [Display(Name = "AlterUser", Description = "合法修改用户信息")]
    AlterUser,
    
    [Display(Name = "RestoreUser", Description = "恢复用户成正常状态")]
    RestoreUser,
    
    [Display(Name = "Resign", Description = "辞职")]
    Resign
}

/// <summary>
/// 编辑操作类型
/// </summary>
public enum EditorOperatorType
{
    [Display(Name = "RecommendNewEditor", Description = "推荐新的编辑")]
    RecommendNewEditor,
    
    [Display(Name = "RecommendNewNovel", Description = "推荐小说,被推荐的小说可以进入首页,并且获得推荐标志")]
    RecommendNovel,
    
    [Display(Name = "RecommendNewEditor", Description = "推荐帖子,被推荐的帖子可以进入首页,并且获得推荐标志")]
    RecommendPost,
    
    [Display(Name = "Resign", Description = "辞职")]
    Resign
}